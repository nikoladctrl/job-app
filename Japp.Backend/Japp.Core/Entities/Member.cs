using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Japp.Core.Entities
{
    [Table("Members")]
    public class Member : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }  
        
        [Required]
        public string LastName { get; set; }  
        
        public string KnownAs { get; set; }
        
        public bool IsAdmin { get; set; } 

        public List<Job> Jobs { get; set; } 
        
    }
}