using Entities.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class GetImageDto
    {
        public int Id { set; get; }
        public string UserId { set; get; }
        public string UserName { set; get; }
        public string Name { set; get; }
        public string Url { set; get; }
        public string Desciption { set; get; }
        public DateTime DateCreate { set; get; }
        public int LikeCount { set; get; }
        public int CommentCount { set; get; }
        public int ViewsCount { set; get; }
        public bool ImageStatus { set; get; }
        public bool IsApproval { set; get; }
        public int CategoryId { set; get; }
        public bool IsLike { set; get; }

    }
}
