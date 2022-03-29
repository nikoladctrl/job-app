using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Japp.Core.DTOs.Benefit;
using Japp.Core.Entities;
using Japp.Core.Helpers;
using Japp.EFCore.Context;
using Japp.EFCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Japp.EFCore.Repositories.Benefits
{
    public class BenefitRepository : BaseRepository<Benefit>, IBenefitRepository
    {
        private readonly IUnitOfWork<Benefit> _unitOfWork;
        public BenefitRepository(DataContext context, IUnitOfWork<Benefit> unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Benefit> CreateBenefit(Benefit benefit)
        {
            return await _unitOfWork.Add(benefit);
        }

        public async Task<Benefit> UpdateBenefit(Benefit benefit)
        {
            return await _unitOfWork.Update(benefit);
        }
        
        public async Task DeleteBenefit(int id)
        {
            await _unitOfWork.Delete(await GetBenefit(id));
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