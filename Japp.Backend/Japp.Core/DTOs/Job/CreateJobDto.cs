using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Japp.Core.Enums;

namespace Japp.Core.DTOs.Job
{
    public class CreateJobDto
    {
        [Required]
        public string Headline { get; set; }
        
        [Required]
        public string Content { get; set; }
        
        public string Description { get; set; }
        
        [Required]
        public DateTime ExpiresOn { get; set; }
        
        [Required]
        public Seniority Seniority { get; set; }

        public bool? IsRemote { get; set; }
        
        public bool? IsOnlineInterview { get; set; }
        
        public int? SalaryFrom { get; set; }
        
        public int? SalaryTo { get; set; }

        public SalaryType? SalaryType { get; set; }

        [Required]
        public int CompanyId { get; set; }
    }
}