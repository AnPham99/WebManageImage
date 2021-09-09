using Entities.Models;
using Entities.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasOne(i => i.User).WithMany(u => u.Images).HasForeignKey(i => i.UserId);
            builder.HasOne(i => i.Category).WithMany(c => c.Images).HasForeignKey(i => i.CategoryId);

            builder.HasData
                (
                    new Image()
                    {
                        Id = 1,
                        Name = "Chó Corgi",
                        Url = "../../assets/Img/chocogri.jpeg",
                        Desciption = "Chó corgi đang chơi đùa ngoài vườn",
                        ImageStatus = true,
                        DateCreate = new DateTime(2021, 06, 28),
                        LikeCount = 48,
                        CommentCount = 0,
                        ViewsCount = 61,
                        UserId = null,
                        UserName = "Ân Phạm",
                        CategoryId = 3,
                        IsApproval = true,
                        IsDeny = false
                    },

                    new Image()
                    {
                        Id = 2,
                        Name = "Rừng nhiệt đới",
                        Url = "../../assets/Img/rungnhietdoi.jpeg",
                        Desciption = "Rừng nhiệt đới với những tán cây xanh mát đang phát triển vào mùa mưa",
                        ImageStatus = true,
                        DateCreate = new DateTime(2021, 06, 28),
                        LikeCount = 24,
                        CommentCount = 0,
                        ViewsCount = 36,
                        UserId = null,
                        UserName = "Ân Phạm",
                        CategoryId = 1,
                        IsApproval = true,
                        IsDeny = false
                    },

                    new Image()
                    {
                        Id = 3,
                        Name = "Con gái miền tây",
                        Url = "../../assets/Img/congaimientay.jpeg",
                        Desciption = "Cô gái miền tây trong chiếc áo bà ba thước tha",
                        ImageStatus = true,
                        DateCreate = new DateTime(2021, 06, 28),
                        LikeCount = 46,
                        CommentCount = 0,
                        ViewsCount = 55,
                        UserId = null,
                        UserName = "Ân Phạm",
                        CategoryId = 2,
                        IsApproval = true,
                        IsDeny = false

                    },
                    new Image()
                    {
                        Id = 4,
                        Name = "Mèo",
                        Url = "../../assets/Img/meo.jpeg",
                        Desciption = "Vẻ mặt chú mèo trông ngây thơ khi đòi ăn",
                        ImageStatus = true,
                        DateCreate = new DateTime(2021, 06, 28),
                        LikeCount = 109,
                        CommentCount = 5,
                        ViewsCount = 111,
                        UserId = null,
                        UserName = "Ân Phạm",
                        CategoryId = 3,
                        IsApproval = true,
                        IsDeny = false
                    },

                    new Image()
                    {
                        Id = 5,
                        Name = "Hoàng hôn",
                        Url = "../../assets/Img/hoanghon.jpeg",
                        Desciption = "Hoàng hôn đang buông xuống vào buổi chiều trông thật đẹp",
                        ImageStatus = true,
                        DateCreate = new DateTime(2021, 06, 28),
                        LikeCount = 27,
                        CommentCount = 0,
                        ViewsCount = 37,
                        UserId = null,
                        UserName = "Ân Phạm",
                        CategoryId = 1,
                        IsApproval = true,
                        IsDeny = false
                    },

                    new Image()
                    {
                        Id = 6,
                        Name = "Ảnh thẻ",
                        Url = "../../assets/Img/anhthe.jpeg",
                        Desciption = "Ảnh thẻ thời học sinh",
                        ImageStatus = true,
                        DateCreate = new DateTime(2021, 06, 28),
                        LikeCount = 0,
                        CommentCount = 0,
                        ViewsCount = 0,
                        UserId = null,
                        UserName = "Ân Phạm",
                        CategoryId = 5,
                        IsApproval = true,
                        IsDeny = false


                    },


                    new Image()
                    {
                        Id = 7,
                        Name = "Chim cánh cụt",
                        Url = "../../assets/Img/chimcanhcut.jpeg",
                        Desciption = "Chim cánh cụt tập trung theo đàn nghỉ mát trên bờ biển",
                        ImageStatus = true,
                        DateCreate = new DateTime(2021, 06, 28),
                        LikeCount = 23,
                        CommentCount = 0,
                        ViewsCount = 732,
                        UserId = null,
                        UserName = "Ân Phạm",
                        CategoryId = 3,
                        IsApproval = true,
                        IsDeny = false
                    },

                    new Image()
                    {
                        Id = 8,
                        Name = "Dòng sông quê em",
                        Url = "../../assets/Img/dongsongqueem.jpeg",
                        Desciption = "Dòng sông quê em lúc nào cũng mênh mông con nước, cá tôm rất nhiều",
                        ImageStatus = true,
                        DateCreate = new DateTime(2021, 06, 28),
                        LikeCount = 54,
                        CommentCount = 0,
                        ViewsCount = 77,
                        UserId = null,
                        UserName = "Ân Phạm",
                        CategoryId = 1,
                        IsApproval = true,
                        IsDeny = false
                    },

                    new Image()
                    {
                        Id = 9,
                        Name = "Bikini",
                        Url = "../../assets/Img/bikini.jpeg",
                        Desciption = "Cô gái nóng bỏng trong bộ bikini",
                        ImageStatus = true,
                        DateCreate = new DateTime(2021, 06, 28),
                        LikeCount = 299,
                        CommentCount = 0,
                        ViewsCount = 78,
                        UserId = null,
                        UserName = "Ân Phạm",
                        CategoryId = 4,
                        IsApproval = true,
                        IsDeny = false

                    },

                    new Image()
                    {
                        Id = 10,
                        Name = "Vịnh Hạ Long",
                        Url = "../../assets/Img/vinhhalong.jpeg",
                        Desciption = "Vịnh Hạ Long một địa danh là di sản văn hóa và kì quan thiên nhiên của Việt Nam",
                        ImageStatus = true,
                        DateCreate = new DateTime(2021, 06, 28),
                        LikeCount = 88,
                        CommentCount = 0,
                        ViewsCount = 134,
                        UserId = null,
                        UserName = "Ân Phạm",
                        CategoryId = 1,
                        IsApproval = true,
                        IsDeny = false
                    },

                    new Image()
                    {
                        Id = 11,
                        Name = "Sa mạc Sahara",
                        Url = "../../assets/Img/sahara.jpeg",
                        Desciption = "Vịnh Hạ Long một địa danh là di sản văn hóa và kì quan thiên nhiên của Việt Nam",
                        ImageStatus = true,
                        DateCreate = new DateTime(2021, 06, 28),
                        LikeCount = 18,
                        CommentCount = 0,
                        ViewsCount = 72,
                        UserId = null,
                        UserName = "Ân Phạm",
                        CategoryId = 1,
                        IsApproval = true,
                        IsDeny = false
                    },

                     new Image()
                     {
                         Id = 12,
                         Name = "Kim tự tháp",
                         Url = "../../assets/Img/kimtuthap.jpeg",
                         Desciption = "Kim tự tháp một địa danh là di sản văn hóa và kì quan thiên nhiên của Việt Nam",
                         ImageStatus = true,
                         DateCreate = new DateTime(2021, 06, 28),
                         LikeCount = 30,
                         CommentCount = 0,
                         ViewsCount = 45,
                         UserId = null,
                         UserName = "Ân Phạm",
                         CategoryId = 6,
                         IsApproval = true,
                         IsDeny = false
                     }




                );
        }
    }
}
