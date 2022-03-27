using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Japp.BusinessLayer.Services.Companies;
using Japp.Core.DTOs.Company;
using Japp.Core.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Japp.API.Controllers
{
    public class CompaniesController : BaseApiController
    {
        private readonly ICompanyService _companyService;
        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        public async Task<ActionResult<CompanyDto>> CreateCompany([FromBody] CreateCompanyDto createCompanyDto)
        {
            var company = await _companyService.CreateCompany(createCompanyDto);

            return (company == null) ?
                NotFound() :
                Created("Company is successfully created!", company);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CompanyDto>> UpdateCompany([FromRoute] int id, [FromBody] UpdateCompanyDto updateCompanyDto)
        {
            if (id != updateCompanyDto.Id) {
                return BadRequest("Ids are not the same!");
            }
            var company = await _companyService.UpdateCompany(updateCompanyDto);

            return (company == null) ?
                NotFound() :
                Ok(company);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany([FromRoute] int id)
        {
            await _companyService.DeleteCompany(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<PaginationResult<CompanyDto, CompanyFilterParamsDto>>> GetCompanies([FromQuery] Params<CompanyFilterParamsDto> @params)
        {
            var companies = await _companyService.GetCompanies(@params);

            return (companies == null) ?
                NotFound() :
                Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDto>> GetCompany(int id)
        {
            var company = await _companyService.GetCompany(id);

            return (company == null) ?
                NotFound() :
                Ok(company);
        }
    }
}