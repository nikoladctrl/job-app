using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Japp.Core.DTOs.Company
{
    public class CreateCompanyDto
    {
        [Required]
        [StringLength(45, ErrorMessage = "Company's name is unique/required!")]
        public string Name { get; set; }

        [Required]
        [StringLength(1500, ErrorMessage = "Introduction is required!")]
        public string Introduction { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Address is required!")]
        public string Address { get; set; }
        
        [Required]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "Email is required!")]
        public string Email { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage = "Website is required!")]
        public string Website { get; set; }

        [Required]
        [Phone]
        [StringLength(100, ErrorMessage = "Phone is required!")]
        public string Phone { get; set; }
    }
}