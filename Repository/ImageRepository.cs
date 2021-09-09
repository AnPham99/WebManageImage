using AutoMapper;
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
        private readonly IMapper _mapper;

        public ImageRepository(RepositoryContext repositoryContext, IMapper mapper) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Image>> GetAllImagesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToListAsync();

        /*top like*/
        public async Task<Image> GetImageTopLike()
        {
            var max = (from i in _repositoryContext.Images
                      where i.IsApproval == true && i.ImageStatus == true
                      select i).Max(i => i.LikeCount);

            var rs = from i in _repositoryContext.Images
                      where i.IsApproval == true && i.ImageStatus == true && i.LikeCount == max
                      select i;
            return await rs.SingleOrDefaultAsync();
        }

        /*cmt*/
        public async Task<Image> GetImageTopCmt()
        {
            var max = (from i in _repositoryContext.Images
                       where i.IsApproval == true && i.ImageStatus == true
                       select i).Max(i => i.CommentCount);

            var rs = from i in _repositoryContext.Images
                     where i.IsApproval == true && i.ImageStatus == true && i.CommentCount == max
                     select i;
            return await rs.FirstOrDefaultAsync();
        }

        /*view*/
        public async Task<Image> GetImageTopView()
        {
            var max = (from i in _repositoryContext.Images
                       where i.IsApproval == true && i.ImageStatus == true
                       select i).Max(i => i.ViewsCount);

            var rs = from i in _repositoryContext.Images
                     where i.IsApproval == true && i.ImageStatus == true && i.ViewsCount == max
                     select i;
            return await rs.SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Image>> GetImageHasApproval()
        {        
            var rs = from i in _repositoryContext.Images
                     where i.IsApproval == true && i.ImageStatus == true
                     select i;
            return await rs.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<IEnumerable<Image>> GetImageNotApproval()
        {
            var rs = from i in _repositoryContext.Images
                     where i.IsApproval == false && i.ImageStatus == true && i.IsDeny == false
                     select i;

            return await rs.OrderBy(c => c.Name).ToListAsync();
        }

        /*pagging*/
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

        public async Task IncreaseView(Image image)
        {
            image.ViewsCount += 1;
            Update(image);
            await SaveChangeAsync();
        }

        public async Task LikeImageByUserAsync(string userId, int imageId, Image image)
        {
            Update(image);
            await SaveChangeAsync();
        }


        public async Task addLikeImageAsync(string userId, int imageId, Image image)
        {
            image.LikeCount += 1;
            Update(image);
            await SaveChangeAsync();
        }

        public async Task minusLikeImageAsync(string userId, int imageId, Image image)
        {
            image.LikeCount -= 1;
            Update(image);
            await SaveChangeAsync();
        }

        public async Task UpdateImage(Image image)
        {
            Update(image);
            await SaveChangeAsync();
        }
    }
}
