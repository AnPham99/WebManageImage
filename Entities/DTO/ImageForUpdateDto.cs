using Entities.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class ImageForUpdateDto : ImageForManipulationDto
    {
        public bool IsLike { set; get; }
    }
}
