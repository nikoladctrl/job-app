using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Japp.Core.DTOs.Company;
using Japp.Core.Entities;
using Japp.Core.Helpers;
using Japp.EFCore.Repositories.Companies;
using Microsoft.EntityFrameworkCore;

namespace Japp.BusinessLayer.Services.Companies
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
        }

        public async Task<CompanyDto> CreateCompany(CreateCompanyDto createCompanyDto)
        {
            return _mapper.Map<CompanyDto>(await _companyRepository.CreateCompany(_mapper.Map<Company>(createCompanyDto)));
        }

        public async Task<CompanyDto> UpdateCompany(UpdateCompanyDto updateCompanyDto)
        {
            var company = await _companyRepository.GetCompany(updateCompanyDto.Id);
            var companyToUpdate = _mapper.Map<UpdateCompanyDto, Company>(updateCompanyDto, company);
            return _mapper.Map<CompanyDto>(await _companyRepository.UpdateCompany(companyToUpdate));
        }

        public async Task DeleteCompany(int id)
        {
            await _companyRepository.DeleteCompany(id);
        }
        
        public async Task<PaginationResult<CompanyDto, CompanyFilterParamsDto>> GetCompanies(Params<CompanyFilterParamsDto> @params)
        {
            return _mapper.Map<PaginationResult<CompanyDto, CompanyFilterParamsDto>>(await _companyRepository.GetCompanies(@params));
        }

        public async Task<CompanyDto> GetCompany(int id)
        {
            return _mapper.Map<CompanyDto>(await _companyRepository.GetCompany(id));
        }
    }
}