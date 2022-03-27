using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Japp.Core.DTOs.Company
{
    public class UpdateCompanyDto : CreateCompanyDto
    {
        public int Id { get; set; }

        public bool IsPremium { get; set; }

        public int Likes { get; set; }
        
        public int Stars { get; set; }

        public string ThumbnailImage { get; set; }
        
        public string Video { get; set; }
        
        public List<int> Jobs { get; set; }
        
        public List<int> Comments { get; set; }
        
        public List<int> Benefits { get; set; }
        
        public List<int> CompanyTechnologies { get; set; }
    }
}