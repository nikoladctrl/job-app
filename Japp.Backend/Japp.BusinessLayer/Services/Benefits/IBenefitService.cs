using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Japp.Core.DTOs.Benefit;
using Japp.Core.Helpers;

namespace Japp.BusinessLayer.Services.Benefits
{
    public interface IBenefitService
    {
        Task<BenefitDto> CreateBenefit(CreateBenefitDto createBenefitDto);
        Task<BenefitDto> UpdateBenefit(UpdateBenefitDto updateBenefitDto);
        Task DeleteBenefit(int id);
        Task<List<BenefitDto>> GetBenefits(Params<BenefitFilterParamsDto> @params);
        Task<BenefitDto> GetBenefit(int id);
        Task<List<BenefitDto>> GetCompanyBenefits(int companyId);
    }
}