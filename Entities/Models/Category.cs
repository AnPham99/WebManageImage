using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Category
    {
        [Key]
        [Column("CategoryId")]
        public int Id { set; get; }

        [Required(ErrorMessage = "Phải có tên danh mục.")]
        [MaxLength(60, ErrorMessage = "Tên danh mục tối đa 60 ký tự.")]
        public string Name { set; get; }

        public List<Image> Images { set; get; }
    }
}
