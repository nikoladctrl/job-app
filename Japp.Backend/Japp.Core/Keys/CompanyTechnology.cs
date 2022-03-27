using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Japp.Core.Entities;

namespace Japp.Core.Keys
{
    [Table("CompanyTechnologies")]
    public class CompanyTechnology
    {   
        public int CompanyId { get; set; }
        
        public Company Company { get; set; }

        public int TechnologyId { get; set; }
        
        public Technology Technology { get; set; }
    }
}