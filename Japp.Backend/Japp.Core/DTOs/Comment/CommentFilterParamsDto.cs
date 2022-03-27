using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Japp.Core.DTOs.Comment
{
    public class CommentFilterParamsDto
    {
        public string Position { get; set; }
        public string CompanyName { get; set; }
        public string Town { get; set; }
        public string CommentType { get; set; }
    }
}