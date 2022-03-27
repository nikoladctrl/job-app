using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Japp.Core.DTOs.Benefit
{
    public class UpdateBenefitDto : CreateBenefitDto
    {
        [Required]
        public int Id { get; set; }
    }
}