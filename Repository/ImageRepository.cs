using Contracts;
using Entities;
using Entities.DTO;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ImageRepository : RepositoryBase<Image>, IImageRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public ImageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<IEnumerable<Image>> GetAllImagesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToListAsync();

        public async Task<IEnumerable<Image>> GetImageHasApproval()
        {        
            var rs = from i in _repositoryContext.Images
                     where i.IsApproval == true && i.ImageStatus == true
                     select i;
            return await rs.OrderBy(c => c.Name).ToListAsync();
        }
        /*like*/
       /* public async Task<IEnumerable<Image>> GetImageTopLike()
        {
            int max = 0;
            var rs = from i in _repositoryContext.Images
                     where i.IsApproval == true && i.ImageStatus == true
                     select i;
            foreach(var img in rs)
            {
                if (img.LikeCount > max)
                    return img;
            }
            *//*return await rs.OrderBy(c => c.Name).ToListAsync();*//*
        }*/

        public async Task<IEnumerable<Image>> GetImageNotApproval()
        {
            var rs = from i in _repositoryContext.Images
                     where i.IsApproval == false && i.ImageStatus == true && i.IsDeny == false
                     select i;
            return await rs.OrderBy(c => c.Name).ToListAsync();
        }


        public async Task<PagedList<Image>> GetAllImagesForCategoryAsync(int categoryId, ImageParameters imageParameters, bool trackChanges)
        {
            var images = await FindByCondition(i => i.CategoryId.Equals(categoryId), trackChanges)
            .Search(imageParameters.SearchTerm)
            .OrderBy(i => i.Name)
            .ToListAsync();

            return PagedList<Image>
                .ToPagedList(images, imageParameters.PageNumber,
                imageParameters.PageSize);
        }

        public async Task<Image> GetImageByIdAsync(int imageId, bool trackChanges) =>
            await FindByCondition(i =>i.Id.Equals(imageId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Image>> GetImageByUserAsync(string userId, bool trackChanges) =>
            await FindByCondition(i => i.UserId.Equals(userId), trackChanges)
            .OrderBy(c => c.Name)
            .ToListAsync();

        public async Task<Image> GetImageByIdForUserAsync(string userId, int imageId, bool trackChanges) =>
            await FindByCondition(i =>i.UserId.Equals(userId) && i.Id.Equals(imageId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task CreateImageAsync(string userId, Image image)
        {
            image.UserId = userId;
            Create(image);
            await SaveChangeAsync();
        }

        public async Task DeleteImageAsync(string userId, Image image)
        {
            if (image.UserId == userId)
                Delete(image);
            await SaveChangeAsync();
        }

        public async Task UpdateImageByUserAsync(string userId, Image image)
        {
            if (image.UserId == userId)
                Update(image);
            await SaveChangeAsync();
        }

        public async Task ApprovalImageByAdminAsync(Image image)
        {
            image.IsApproval = true;
            Update(image);
            await SaveChangeAsync();
        }
        public async Task DenyImageByAdminAsync(Image image)
        {
            image.IsDeny = true;
            Update(image);
            await SaveChangeAsync();
        }

        public async Task LikeImageAsync(/*string userId,*/ Image image)
        {
            /*var rs = from i in _repositoryContext.Images
                     join l in _repositoryContext.Likes on i.Id equals l.ImageId
                     join u in _repositoryContext.Users on l.UserId equals u.Id
                    
                     select new
                    

            foreach (var kq in rs)
            {
                if (kq.UserId == userId)
                {
                    image.LikeCount += 1;
                    kq.IsLike = true;
                }
                 else
                {
                    image.LikeCount -= 1;
                    image.IsLike = false;
                }

            }*/
            /*if (image.IsLike == false)
            {
                image.LikeCount += 1;
                image.IsLike = true;
            }
            else
            {
                image.LikeCount -= 1;
                image.IsLike = false;
            }*/
            Update(image);
            await SaveChangeAsync();
        }

    }
}
