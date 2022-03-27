using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Japp.Core.DTOs.Job
{
    public class JobFilterParamsDto
    {
        public string KeyWord { get; set; }
        public string Technology { get; set; }
        public string Place { get; set; }
        public string Seniority { get; set; }
        public string Employer { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? IsRemote { get; set; }
        public bool? IsOnlineInterview { get; set; }
    }
}