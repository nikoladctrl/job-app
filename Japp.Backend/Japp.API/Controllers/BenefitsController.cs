using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Japp.BusinessLayer.Services.Benefits;
using Japp.Core.DTOs.Benefit;
using Japp.Core.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Japp.API.Controllers
{
    public class BenefitsController : BaseApiController
    {
        private readonly IBenefitService _benefitService;
        public BenefitsController(IBenefitService benefitService)
        {
            _benefitService = benefitService;
        }

        [HttpPost]
        public async Task<ActionResult<BenefitDto>> CreateBenefit([FromBody] CreateBenefitDto createBenefitDto)
        {
            var benefit = await _benefitService.CreateBenefit(createBenefitDto);

            return (benefit == null) ?
                NotFound() :
                Created("Benefit is successfully created!", benefit);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BenefitDto>> UpdateBenefit([FromRoute] int id, [FromBody] UpdateBenefitDto updateBenefitDto)
        {
            if (id != updateBenefitDto.Id) {
                return BadRequest("Ids are not the same!");
            }
            var benefit = await _benefitService.UpdateBenefit(updateBenefitDto);

            return (benefit == null) ?
                NotFound() :
                Ok(benefit);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBenefit([FromRoute] int id)
        {
            await _benefitService.DeleteBenefit(id);

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<BenefitDto>>> GetBenefits([FromQuery] Params<BenefitFilterParamsDto> @params)
        {
            var benefits = await _benefitService.GetBenefits(@params);

            return (benefits == null) ?
                NotFound() :
                Ok(benefits);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BenefitDto>> GetBenefit([FromRoute] int id)
        {
            var benefit = await _benefitService.GetBenefit(id);

            return (benefit == null) ?
                NotFound() :
                Ok(benefit); 
        }

        [HttpGet("/{companyId}/company")]
        public async Task<ActionResult<PaginationResult<BenefitDto, BenefitFilterParamsDto>>> GetCompanyBenefit([FromRoute] int companyId)
        {
            var benefits = await _benefitService.GetCompanyBenefits(companyId);

            return (benefits == null) ?
                NotFound() :
                Ok(benefits);
        }
    }
}