using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Japp.Core.DTOs.Company
{
    public class CompanyFilterParamsDto
    {
        public bool IsITSelected { get; set; } = true;
        public bool? NumberOfJobsSelected { get; set; }
        public bool? IsGradeSelected { get; set; }
        public bool? IsUpSelected { get; set; }
        public bool? IsDownSelected { get; set; }
    }
}