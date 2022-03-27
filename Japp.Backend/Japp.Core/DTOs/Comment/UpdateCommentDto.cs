using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Japp.Core.DTOs.Comment
{
    public class UpdateCommentDto : CreateCommentDto
    {
        public int Id { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}