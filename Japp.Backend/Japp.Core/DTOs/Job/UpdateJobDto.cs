using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Japp.Core.DTOs.Job
{
    public class UpdateJobDto : CreateJobDto
    {
        [Required]
        public int Id { get; set; }
        public List<int> Technologies { get; set; }
    }
}