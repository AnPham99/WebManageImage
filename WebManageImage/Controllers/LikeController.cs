using AutoMapper;
using Contracts;
using Entities.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebManageImage.Controllers
{
    [Route("api/like")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;




        public LikeController(ILikeRepository likeRepository, IMapper mapper)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
        }

        [HttpGet("{userId}/{imageId}")]
        public async Task<IActionResult> GetIsLike(string userId, int imageId)
        {
            var likeDb = await _likeRepository.GetLikeAsync(userId, imageId, trackChanges: false);
            var likeDto = _mapper.Map<LikeDto>(likeDb);
            return Ok(likeDto);
        }
    }
}
