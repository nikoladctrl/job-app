using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Japp.Core.DTOs.Benefit;
using Japp.Core.Entities;
using Japp.Core.Helpers;
using Japp.EFCore.Repositories.Benefits;

namespace Japp.BusinessLayer.Services.Benefits
{
    public class BenefitService : IBenefitService
    {
        private readonly IBenefitRepository _benefitRepository;
        private readonly IMapper _mapper;
        public BenefitService(IBenefitRepository benefitRepository, IMapper mapper)
        {
            _benefitRepository = benefitRepository;
            _mapper = mapper;
        }

        public async Task<BenefitDto> CreateBenefit(CreateBenefitDto createBenefitDto)
        {
            return _mapper.Map<BenefitDto>(await _benefitRepository.CreateBenefit(_mapper.Map<Benefit>(createBenefitDto)));
        }

        public async Task<BenefitDto> UpdateBenefit(UpdateBenefitDto updateBenefitDto)
        {
            var benefit = await _benefitRepository.GetBenefit(updateBenefitDto.Id);

            var benefitToUpdate = _mapper.Map<UpdateBenefitDto, Benefit>(updateBenefitDto, benefit);

            var updatedBenefit = await _benefitRepository.UpdateBenefit(benefitToUpdate);

            return _mapper.Map<BenefitDto>(updatedBenefit);
        }

        public async Task DeleteBenefit(int id)
        {
            await _benefitRepository.DeleteBenefit(id);
        }


        public async Task<List<BenefitDto>> GetBenefits(Params<BenefitFilterParamsDto> @params)
        {
            return _mapper.Map<List<BenefitDto>>(await _benefitRepository.GetBenefits(@params));
        }

        public async Task<BenefitDto> GetBenefit(int id)
        {
            return _mapper.Map<BenefitDto>(await _benefitRepository.GetBenefit(id));
        }

        public async Task<List<BenefitDto>> GetCompanyBenefits(int companyId)
        {
            return _mapper.Map<List<BenefitDto>>(await _benefitRepository.GetBenefitBenefits(companyId));
        }
    }
}