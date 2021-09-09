using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.DTO;
using Entities.Models;

namespace WebManageImage.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public CommentController(ICommentRepository commentRepository, IMapper mapper)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
        }

        [HttpGet("{imageId}")]
        public async Task<IActionResult> GetAllComment(int imageId)
        {
            var cmts = await _commentRepository.GetAllCommentAsync(imageId, trackChanges: false);
            return Ok(cmts);
        }

        [HttpPost("{userId}/{imageId}")]
        public async Task<IActionResult> CreateComment(string userId, int imageId, [FromBody] CommentForCreateDto commentForCreate)
        {
            if (commentForCreate == null)
                return BadRequest("Bạn cần phải nhập thông tin");
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var cmtEntity = _mapper.Map<Comment>(commentForCreate);

            await _commentRepository.CreateCommentAsync(userId, imageId, cmtEntity);
            return Ok("tạo thành công");
        }
    }
}
