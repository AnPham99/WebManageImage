using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DTO
{
    public class CommentForCreateDto
    {
        [Required(ErrorMessage = "chưa nhập bình luận.")]
        public string Content { set; get; }
    }
}
