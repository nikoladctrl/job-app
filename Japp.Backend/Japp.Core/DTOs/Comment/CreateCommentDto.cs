using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Japp.Core.Enums;

namespace Japp.Core.DTOs.Comment
{
    public class CreateCommentDto
    {
        [Required]
        [StringLength(50, ErrorMessage = "Title is required!")]
        public string Title { get; set; }
        
        [Required]
        [StringLength(5000, ErrorMessage = "Content is required!")]
        public string Content { get; set; }

        [Required]
        public CommentType CommentType { get; set; }
        
        [Required]
        public int CompanyId { get; set; }
    }
}