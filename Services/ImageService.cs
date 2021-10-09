using AutoMapper;
using Contracts;
using Entities;
using Entities.DTO;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Identity;
using Repository;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class ImageService : RepositoryBase<Image>, IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly ILikeRepository _likeRepository;
        private readonly RepositoryContext _repositoryContext;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private User _user;
        public ImageService(IMapper mapper, RepositoryContext repositoryContext, IImageRepository imageRepository, ILikeRepository likeRepository, UserManager<User> userManager) : base(repositoryContext)
        {
            _mapper = mapper;
            _imageRepository = imageRepository;
            _userManager = userManager;
            _likeRepository = likeRepository;
            _repositoryContext = repositoryContext;
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
            image.UserName = _user.UserName;
            await _imageRepository.CreateImageAsync(userId, image);
        }

        public async Task DeleteImageAsync(string userId, Image image)
        {
            await _imageRepository.DeleteImageAsync(userId, image);
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

        public async Task IncreaseView(Image image)
        {
            await _imageRepository.IncreaseView(image);
        }

        public async Task<IEnumerable<Image>> GetImageByUserAsync(string userId, bool trackChanges)
        {
            return await _imageRepository.GetImageByUserAsync(userId, trackChanges);
        }

        public async Task<Image> GetImageByIdForUserAsync(string userId, int imageId, bool trackChanges)
        {
            return await _imageRepository.GetImageByIdForUserAsync(userId, imageId, trackChanges);
        }


        public async Task<PagedList<Image>> GetAllImagesAsync(ImageParameters imageParameters, bool trackChanges)
        {
            return await _imageRepository.GetAllImagesAsync(imageParameters, trackChanges);
        }

        public async Task<PagedList<Image>> GetImageHasApproval(ImageParameters imageParameters, bool trackChanges)
        {
            return await _imageRepository.GetImageHasApproval(imageParameters, trackChanges);
        }

        public async Task<Image> GetNewImageInCate(int cateId)
        {
            return await _imageRepository.GetNewImageInCate(cateId);
        }

        public async Task<PagedList<Image>> GetAllImagesForCategoryAsync(int categoryId, ImageParameters imageParameters, bool trackChanges)
        {
            return await _imageRepository.GetAllImagesForCategoryAsync(categoryId, imageParameters, trackChanges);
        }

        public async Task<Image> GetImageByIdAsync(int imageId, bool trackChanges)
        {
            return await _imageRepository.GetImageByIdAsync(imageId, trackChanges);
        }

        public async Task<IEnumerable<Image>> GetImageNotApproval()
        {
            return await _imageRepository.GetImageNotApproval();
        }

        public async Task<Image> GetImageTopLike()
        {
            return await _imageRepository.GetImageTopLike();

        }

        public async Task<Image> GetImageTopCmt()
        {
            return await _imageRepository.GetImageTopCmt();

        }

        public async Task<Image> GetImageTopView()
        {
            return await _imageRepository.GetImageTopView();

        }

        public async Task<bool> IsLikeImageAsync(string userId, int imageId)
        {
            var rs = from l in _repositoryContext.Likes
                     select l;

            foreach(var kq in rs)
            {
                if(kq.ImageId == imageId && kq.UserId == userId)
                {
                    await _likeRepository.CreateLikeAsync(userId, imageId);
                    return false;
                }
            }
            return true;

            
        }

        public async Task LikeImageByUserAsync(string userId, int imageId, Image image)
        {
            var rs = from l in _repositoryContext.Likes
                     where l.UserId == userId && l.ImageId == imageId
                     select l;
            
            if(rs.SingleOrDefault() == null)
            {
                image.LikeCount += 1;
                await _likeRepository.CreateLikeAsync(userId, imageId);
            }
            else
            {
                Like like = new Like();
                foreach (var kq in rs)
                {
                    like.UserId = kq.UserId;
                    like.ImageId = kq.ImageId;
                    like.IsLike = kq.IsLike;
                }
                if (like.UserId == userId && like.ImageId == imageId && like.IsLike == true)
                {
                    image.LikeCount -= 1;
                    var likedb = await _likeRepository.GetLikeAsync(userId, imageId, trackChanges: true);
                    await _likeRepository.MinusUpdateLikeAsync(userId, imageId, likedb);
                }
                else
                {
                    image.LikeCount += 1;
                    var likedb = await _likeRepository.GetLikeAsync(userId, imageId, trackChanges: true);
                    await _likeRepository.PlusUpdateLikeAsync(userId, imageId, likedb);
                }
            }
            await _imageRepository.LikeImageByUserAsync(userId, imageId, image);
        }

        public async Task addLikeImageAsync(string userId, int imageId, Image image)
        {
            await _imageRepository.addLikeImageAsync(userId, imageId, image);
        }

        public async Task minusLikeImageAsync(string userId, int imageId, Image image)
        {
            await _imageRepository.minusLikeImageAsync(userId, imageId, image);
        }

        public async Task UpdateImage(int imageId, Image image)
        {
            if(imageId == image.Id)
                image.CommentCount += 1;
            await _imageRepository.UpdateImage(image);

        }

    }
}
