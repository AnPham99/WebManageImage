using AutoMapper;
using Contracts;
using Entities.DTO;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Identity;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private User _user;
        public ImageService(IMapper mapper, IImageRepository imageRepository, UserManager<User> userManager)
        {
            _mapper = mapper;
            _imageRepository = imageRepository;
            _userManager = userManager;
        }

        public async Task CreateImageAsync(string userId, Image image)
        {
            _user = await _userManager.FindByIdAsync(userId);

            image.DateCreate = DateTime.Now;
            image.LikeCount = 0;
            image.CommentCount = 0;
            image.ViewsCount = 0;
            image.IsApproval = false;
            image.IsDeny = false;
            image.IsLike = false;
            image.UserName = _user.UserName;
            await _imageRepository.CreateImageAsync(userId, image);
        }

        public async Task DeleteImageAsync(string userId, Image image)
        {
            await _imageRepository.DeleteImageAsync(userId, image);
        }

        public async Task LikeImageAsync(Image image)
        {
            await _imageRepository.LikeImageAsync(image);
        }
        public async Task UpdateImageByUserAsync(string userId, Image image)
        {
            await _imageRepository.UpdateImageByUserAsync(userId, image);
        }

        public async Task ApprovalImageByAdminAsync(Image image)
        {
            await _imageRepository.ApprovalImageByAdminAsync(image);
        }

        public async Task DenyImageByAdminAsync(Image image)
        {
            await _imageRepository.DenyImageByAdminAsync(image);
        }

        public async Task<IEnumerable<Image>> GetImageByUserAsync(string userId, bool trackChanges)
        {
            return await _imageRepository.GetImageByUserAsync(userId, trackChanges);
        }

        public async Task<Image> GetImageByIdForUserAsync(string userId, int imageId, bool trackChanges)
        {
            return await _imageRepository.GetImageByIdForUserAsync(userId, imageId, trackChanges);
        }


        public async Task<IEnumerable<Image>> GetAllImagesAsync(bool trackChanges)
        {
            return await _imageRepository.GetAllImagesAsync(trackChanges);
        }

        public async Task<PagedList<Image>> GetAllImagesForCategoryAsync(int categoryId, ImageParameters imageParameters, bool trackChanges)
        {
            return await _imageRepository.GetAllImagesForCategoryAsync(categoryId, imageParameters, trackChanges);
        }

        public async Task<Image> GetImageByIdAsync(int imageId, bool trackChanges)
        {
            return await _imageRepository.GetImageByIdAsync(imageId, trackChanges);
        }

        public async Task<IEnumerable<Image>> GetImageHasApproval() 
        {
            return await _imageRepository.GetImageHasApproval();
        }
        public async Task<IEnumerable<Image>> GetImageNotApproval()
        {
            return await _imageRepository.GetImageNotApproval();
        }
    }
}
