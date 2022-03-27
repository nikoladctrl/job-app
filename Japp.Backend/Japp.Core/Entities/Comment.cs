using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Japp.Core.Enums;

namespace Japp.Core.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Content { get; set; }
        
        [Required]
        public DateTime CreatedOn { get; set; }

        public CommentType CommentType { get; set; }
        
        public int Likes { get; set; }
        
        public int Dislikes { get; set; }
        
        public int CompanyId { get; set; }
        
        public Company Company { get; set; }
    }
}