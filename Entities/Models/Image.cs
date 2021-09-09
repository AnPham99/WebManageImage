using Entities.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Image
    {
        [Key]
        [Column("ImageId")]
        public int Id { set; get; }

        [Required(ErrorMessage = "Tên ảnh cần phải có.")]
        [MaxLength(20, ErrorMessage = "Tên ảnh tối đa 20 ký tự.")]
        public string Name { set; get; }

        [Required(ErrorMessage = "Cần phải có địa chỉ ảnh.")]
        public string Url { set; get; }

        [Required(ErrorMessage = "Cần phải có mô tả.")]
        [MaxLength(500, ErrorMessage = "Mô tả tối đa 500 ký tự.")]
        public string Desciption { set; get; }

        public DateTime DateCreate { set; get; }
        public int LikeCount { set; get; }
        public int CommentCount { set; get; }
        public int ViewsCount { set; get; }

        [Required(ErrorMessage = "Xin hãy chọn trạng thái ảnh.")]
        public bool ImageStatus { set; get; }
        public bool IsApproval { set; get; }
        public bool IsDeny { set; get; }  
        public string UserName { set; get; }
        public int CategoryId { set; get; }
        public Category Category { set; get; }

        public string UserId { set; get; }
        public User User { set; get; }

        public List<Like> Likes { set; get; }
        public List<Comment> Comments { set; get; }

    }
}
