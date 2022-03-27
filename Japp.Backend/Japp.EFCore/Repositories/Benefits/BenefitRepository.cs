using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Japp.Core.DTOs.Benefit;
using Japp.Core.Entities;
using Japp.Core.Helpers;
using Japp.EFCore.Context;
using Microsoft.EntityFrameworkCore;

namespace Japp.EFCore.Repositories.Benefits
{
    public class BenefitRepository : IBenefitRepository
    {
        private readonly DataContext _context;
        public BenefitRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Benefit> CreateBenefit(Benefit benefit)
        {
            _context.Benefits.Add(benefit);
            await _context.SaveChangesAsync();

            return benefit;
        }

        public async Task<Benefit> UpdateBenefit(Benefit benefit)
        {
            _context.Benefits.Update(benefit);
            await _context.SaveChangesAsync();

            return benefit;
        }
        
        public async Task DeleteBenefit(int id)
        {
            var benefit = await GetBenefit(id);
            _context.Benefits.Remove(benefit);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Benefit>> GetBenefits(Params<BenefitFilterParamsDto> @params)
        {
            return await _context.Benefits.ToListAsync();
        }

        public async Task<Benefit> GetBenefit(int id)
        {
            return await _context.Benefits.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<Benefit>> GetBenefitBenefits(int companyId)
        {
            return await _context.Benefits.Where(b => b.CompanyId == companyId).ToListAsync();
        }
    }
}