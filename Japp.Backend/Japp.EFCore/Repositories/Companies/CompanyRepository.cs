using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Japp.Core.DTOs.Company;
using Japp.Core.Entities;
using Japp.Core.Helpers;
using Japp.EFCore.Context;
using Microsoft.EntityFrameworkCore;

namespace Japp.EFCore.Repositories.Companies
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DataContext _context;
        public CompanyRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Company> CreateCompany(Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();

            return await GetCompany(company.Id);
        }

        public async Task<Company> UpdateCompany(Company company)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();

            return await GetCompany(company.Id);
        }

        public async Task DeleteCompany(int id)
        {
            var company = await GetCompany(id);

            _context.Remove(company);
            await _context.SaveChangesAsync();
        }

        public async Task<PaginationResult<Company, CompanyFilterParamsDto>> GetCompanies(Params<CompanyFilterParamsDto> @params)
        {
            var query = MakeQuery(@params);

            var total = query.Count();

            var companies = await Paginate(query, @params.Page, @params.Size).ToListAsync();

            return new PaginationResult<Company, CompanyFilterParamsDto>(companies, @params.Page, @params.Size, total, @params.FilteringParams);
        }

        public async Task<Company> GetCompany(int id)
        {
            return await _context.Companies.FirstOrDefaultAsync(c => c.Id == id);
        }
        
        private IQueryable<Company> MakeQuery(Params<CompanyFilterParamsDto> @params)
        {
            var query = _context.Companies
                                .Include(c => c.Benefits)
                                .Include(c => c.Comments)
                                .Include(c => c.Jobs).ThenInclude(j => j.Category)
                                .Include(c => c.CompanyTechnologies).ThenInclude(ct => ct.Technology)
                                .OrderBy(o => o.Id)
                                .AsQueryable();

            if (@params.FilteringParams?.IsITSelected != null) {
                query = query.Where(c => c.Jobs.Any(c => c.Category.Name.Contains("IT")));
            }
            
            if (!@params.FilteringParams?.IsITSelected != null) {
                query = query.Where(c => c.Jobs.Any(c => !c.Category.Name.Contains("IT")));
            }

            if (@params.FilteringParams?.NumberOfJobsSelected != null) {
                if (@params.FilteringParams?.IsDownSelected != null) {
                    query = query.OrderByDescending(c => c.Jobs.Count).ThenBy(c => c.Id);
                }
                else {
                    query = query.OrderBy(c => c.Jobs.Count).ThenBy(c => c.Id);
                }
            }
            
            if (@params.FilteringParams?.IsGradeSelected != null) {
                if (@params.FilteringParams?.IsDownSelected != null) {
                    query = query.OrderByDescending(c => c.Stars).ThenBy(c => c.Id);
                }
                else {
                    query = query.OrderBy(c => c.Stars).ThenBy(c => c.Id);
                }
            }

            return query;
        }

        private IQueryable<Company> Paginate(IQueryable<Company> query, int page, int size)
        {
            return query
                    .Skip((page - 1) * size)
                    .Take(size)
                    .AsSingleQuery();
        }

    }
}