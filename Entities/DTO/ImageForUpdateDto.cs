using Entities.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class ImageForUpdateDto : ImageForManipulationDto
     {
        public int LikeCount { set; get; }

    }
}
