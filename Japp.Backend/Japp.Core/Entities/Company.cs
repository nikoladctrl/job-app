using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Japp.Core.Keys;

namespace Japp.Core.Entities
{
    [Table("Companies")]
    public class Company
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Introduction { get; set; }

        [Required]
        public string Address { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Website { get; set; }
        
        [Required]
        public string Phone { get; set; }
        
        public bool IsPremium { get; set; }

        public int Likes { get; set; }
        
        public int Stars { get; set; }

        public byte[] ThumbnailImage { get; set; }
        
        public byte[] Video { get; set; }
        
        public List<Job> Jobs { get; set; }
        
        public List<Comment> Comments { get; set; }
        
        public List<Benefit> Benefits { get; set; }
        
        public List<CompanyTechnology> CompanyTechnologies { get; set; }
        
    }
}