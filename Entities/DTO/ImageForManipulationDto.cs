using Entities.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DTO
{
    public abstract class ImageForManipulationDto
    {
        [Required(ErrorMessage = "Image name is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the Name is 20 characters.")]
        public string Name { set; get; }

        [Required(ErrorMessage = "Cần phải có địa chỉ ảnh.")]
        public string Url { set; get; }

        [Required(ErrorMessage = "Desciption is a required field.")]
        [MaxLength(500, ErrorMessage = "Maximum length for the Desciption is 500 characters.")]
        public string Desciption { set; get; }

        [Required(ErrorMessage = "Image imageStatus is a required field.")]
        public bool ImageStatus { set; get; }

        public bool IsApproval { set; get; }     
        public int CategoryId { set; get; }

       

    }
}
