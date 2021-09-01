using AutoMapper;
using Contracts;
using Entities.DTO;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebManageImage.Controllers
{
    [Route("api/images")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IImageService _imageService;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public ImagesController(UserManager<User> userManager, ICategoryService categoryService, IImageService imageService, ILoggerManager logger, IMapper mapper)
        {
            _categoryService = categoryService;
            _imageService = imageService;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllImages()
        {
            var image = await _imageService.GetAllImagesAsync(trackChanges: false);
            var imageDto = _mapper.Map<IEnumerable<GetImageDto>>(image);
            return Ok(imageDto);
        }


        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetImagesForCategory(int categoryId, [FromQuery] ImageParameters imageParameters)
        {
            var categories = await _categoryService.GetCategoryByIdAsync(categoryId, trackChanges: false);
            if (categories == null)
                return NotFound();
            var imageFromDb = await _imageService.GetAllImagesForCategoryAsync(categoryId, imageParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(imageFromDb.MetaData));
            var imageDto = _mapper.Map<IEnumerable<GetImageDto>> (imageFromDb);
            return Ok(imageDto);
        }


        [HttpGet("id/{imageId}")]
        public async Task<IActionResult> GetImageById(int imageId)
        {
            var imageDb = await _imageService.GetImageByIdAsync(imageId, trackChanges: false);
            var imageDto = _mapper.Map<GetImageDto>(imageDb);
            return Ok(imageDto);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetImageByUser(string userId)
        {
            var imageDb = await _imageService.GetImageByUserAsync(userId, trackChanges: false);
            var imageDto = _mapper.Map < IEnumerable<GetImageDto>> (imageDb);
            return Ok(imageDto);
        }

        [HttpGet("{userId}/{imageId}")]
        public async Task<IActionResult> GetImageByIdForUser(string userId, int imageId)
        {
            var imageDb = await _imageService.GetImageByIdForUserAsync(userId, imageId, trackChanges: false);
            var imageDto = _mapper.Map<GetImageDto>(imageDb);
            return Ok(imageDto);
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> CreateImageForCategory (string userId, [FromBody] ImageForCreateDto imageForCreate)
        {
            if (imageForCreate == null)
                return BadRequest("Bạn cần phải nhập thông tin của ảnh");
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the EmployeeForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var imageEntity = _mapper.Map<Image>(imageForCreate);

            await _imageService.CreateImageAsync(userId, imageEntity);
            var imageToReturn = _mapper.Map<GetImageDto>(imageEntity);
            return Ok("Đã tạo ảnh thành công");
        }


        [HttpDelete("{userId}/{imageId}")]
        public async Task<IActionResult> DeleteImageForUser(string userId, int imageId)
        {
            var image = await _imageService.GetImageByIdForUserAsync(userId, imageId, trackChanges: false);
            await _imageService.DeleteImageAsync(userId, image);
            return Ok("Đã xóa thành công");
        }

        [HttpPut("id/{imageId}")]
        public async Task<IActionResult> LikeImage(int imageId, [FromBody] ImageForUpdateDto imageForUpdateDto)
        {
            if (imageForUpdateDto == null)
                return BadRequest("Bạn cần phải nhập thông tin của ảnh");
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the EmployeeForCreationDto object");
                return UnprocessableEntity(ModelState);
            }
            var imageDb = await _imageService.GetImageByIdAsync(imageId, trackChanges: true);
            var image = _mapper.Map(imageForUpdateDto, imageDb);
            await _imageService.LikeImageAsync(image);
            return Ok("Đã sửa thành công");
        }

        [HttpPut("{userId}/{imageId}")]
        public async Task<IActionResult> UpdateImage (string userId, int imageId, [FromBody] ImageForUpdateDto imageForUpdateDto)
        {
            if (imageForUpdateDto == null)
                return BadRequest("Bạn cần phải nhập thông tin của ảnh");
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the EmployeeForCreationDto object");
                return UnprocessableEntity(ModelState);
            }
            var imageDb = await _imageService.GetImageByIdForUserAsync(userId, imageId, trackChanges: true);
            var image = _mapper.Map(imageForUpdateDto, imageDb);
            await _imageService.UpdateImageByUserAsync(userId,image);
            return Ok("Đã sửa thành công");
        }

        [HttpPut("adminok/{imageId}")]
        public async Task<IActionResult> ApprovalImageByAdmin(int imageId, [FromBody] ImageForUpdateDto imageForUpdateDto)
        {
            if (imageForUpdateDto == null)
                return BadRequest("Bạn cần phải nhập thông tin của ảnh");
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the EmployeeForCreationDto object");
                return UnprocessableEntity(ModelState);
            }
            var imageDb = await _imageService.GetImageByIdAsync(imageId, trackChanges: true);
            var image = _mapper.Map(imageForUpdateDto, imageDb);
            await _imageService.ApprovalImageByAdminAsync(image);
            return Ok("Đã sửa thành công");
        }

        [HttpPut("admindeny/{imageId}")]
        public async Task<IActionResult> DenyImageByAdmin(int imageId, [FromBody] ImageForUpdateDto imageForUpdateDto)
        {
            if (imageForUpdateDto == null)
                return BadRequest("Bạn cần phải nhập thông tin của ảnh");
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the EmployeeForCreationDto object");
                return UnprocessableEntity(ModelState);
            }
            var imageDb = await _imageService.GetImageByIdAsync(imageId, trackChanges: true);
            var image = _mapper.Map(imageForUpdateDto, imageDb);
            await _imageService.DenyImageByAdminAsync(image);
            return Ok("Đã sửa thành công");
        }

        [HttpGet("hasapproval")]
        public async Task<IActionResult> GetImageHasApproval()
        {
            var image = await _imageService.GetImageHasApproval();
            var imageDto = _mapper.Map<IEnumerable<GetImageDto>>(image);
            return Ok(imageDto);
        }

        [HttpGet("notapproval")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetImageNotApproval()
        {
            var image = await _imageService.GetImageNotApproval();
            var imageDto = _mapper.Map<IEnumerable<GetImageDto>>(image);
            return Ok(imageDto);
        }
    }
}
