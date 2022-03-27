using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Japp.Core.DTOs.Company;
using Japp.Core.Helpers;

namespace Japp.BusinessLayer.Services.Companies
{
    public interface ICompanyService
    {
        Task<CompanyDto> CreateCompany(CreateCompanyDto createCompanyDto);
        Task<CompanyDto> UpdateCompany(UpdateCompanyDto updateCompanyDto);
        Task DeleteCompany(int id);
        Task<PaginationResult<CompanyDto, CompanyFilterParamsDto>> GetCompanies(Params<CompanyFilterParamsDto> @params);
        Task<CompanyDto> GetCompany(int id);
    }
}