using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Like
    {
        /*public int LikeCount { set; get; }*/
        public bool IsLike { set; get; }
        public int ImageId { set; get; }
        public Image Image { set; get; }
        public string UserId { set; get; }
        public User User { set; get; }
    }
}
