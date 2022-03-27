using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Japp.Core.DTOs.Benefit;
using Japp.Core.Entities;
using Japp.Core.Helpers;

namespace Japp.EFCore.Repositories.Benefits
{
    public interface IBenefitRepository
    {
        Task<Benefit> CreateBenefit(Benefit benefit);
        Task<Benefit> UpdateBenefit(Benefit benefit);
        Task DeleteBenefit(int id);
        Task<List<Benefit>> GetBenefits(Params<BenefitFilterParamsDto> @params);
        Task<Benefit> GetBenefit(int id);
        Task<List<Benefit>> GetBenefitBenefits(int companyId);
    }
}