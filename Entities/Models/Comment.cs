using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class Comment
    {
        [Key]
        public int Id { set; get; }
        public int ImageId { set; get; }
        public Image Image { set; get; }
        public string UserId { set; get; }
        public User User { set; get; }
        public string Content { set; get; }

    }
}
