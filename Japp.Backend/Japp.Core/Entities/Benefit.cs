using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Japp.Core.Entities
{
    [Table("Benefits")]
    public class Benefit
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        public int CompanyId { get; set; }
        
        public Company Company { get; set; }
    }
}