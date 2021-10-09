using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IImageRepository
    {
        Task<PagedList<Image>> GetAllImagesAsync(ImageParameters imageParameters, bool trackChanges);
        Task<PagedList<Image>> GetImageHasApproval(ImageParameters imageParameters, bool trackChanges);
        Task<PagedList<Image>> GetAllImagesForCategoryAsync(int categoryId, ImageParameters imageParameters, bool trackChanges);
        Task<Image> GetImageByIdAsync(int imageId, bool trackChanges);
        Task<IEnumerable<Image>> GetImageByUserAsync (string userId, bool trackChanges);
        Task<Image> GetImageByIdForUserAsync(string userId, int imageId, bool trackChanges);
        Task<Image> GetNewImageInCate(int cateId);
        Task CreateImageAsync(string userId, Image image);
        Task DeleteImageAsync(string userId, Image image);      
        Task UpdateImageByUserAsync(string userId, Image image);
        Task ApprovalImageByAdminAsync(Image image);
        Task DenyImageByAdminAsync(Image image);
        Task IncreaseView(Image image);
        Task <Image> GetImageTopLike();
        Task<Image> GetImageTopCmt();
        Task<Image> GetImageTopView();
        Task UpdateImage(Image image);
        Task<IEnumerable<Image>> GetImageNotApproval();

        Task LikeImageByUserAsync(string userId, int imageId, Image image);
        Task addLikeImageAsync(string userId, int imageId, Image image);
        Task minusLikeImageAsync(string userId, int imageId, Image image);

    }
}
