using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Japp.Core.DTOs.Company;
using Japp.Core.Entities;
using Japp.Core.Helpers;

namespace Japp.EFCore.Repositories.Companies
{
    public interface ICompanyRepository
    {
        Task<Company> CreateCompany(Company company);
        Task<Company> UpdateCompany(Company company);
        Task DeleteCompany(int id);
        Task<PaginationResult<Company, CompanyFilterParamsDto>> GetCompanies(Params<CompanyFilterParamsDto> @params);
        Task<Company> GetCompany(int id);
    }
}