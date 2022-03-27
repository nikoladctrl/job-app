using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Japp.Core.Enums;

namespace Japp.Core.Entities
{
    [Table("Jobs")]
    public class Job
    {
        public int Id { get; set; }
        
        [Required]
        public string Headline { get; set; }
        
        [Required]
        public string Content { get; set; }
        
        public string Description { get; set; }
        
        [Required]
        public DateTime CreatedOn { get; set; }
        
        [Required]
        public DateTime ExpiresOn { get; set; }
        
        public Seniority Seniority { get; set; }

        public bool? IsRemote { get; set; }
        
        public bool? IsOnlineInterview { get; set; }
        
        public int? SalaryFrom { get; set; }
        
        public int? SalaryTo { get; set; }

        public SalaryType? SalaryType { get; set; }

        public int CompanyId { get; set; }
        
        public Company Company { get; set; }

        public int CategoryId { get; set; }
        
        public Category Category { get; set; }

        public List<Technology> Technologies { get; set; }
    }
}