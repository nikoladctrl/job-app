using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Japp.Core.Entities
{
    [Table("Categories")]
    public class Category
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage = "Name is required!")]
        public string Name { get; set; }
        
        public List<Job> Jobs { get; set; }
    }
}