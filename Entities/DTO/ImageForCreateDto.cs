using Entities.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DTO
{
    public class ImageForCreateDto : ImageForManipulationDto
    {
        public string UserName { set; get; }

    }
}
