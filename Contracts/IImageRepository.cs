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
        Task<IEnumerable<Image>> GetAllImagesAsync(bool trackChanges);
        Task<PagedList<Image>> GetAllImagesForCategoryAsync(int categoryId, ImageParameters imageParameters, bool trackChanges);
        Task<Image> GetImageByIdAsync(int imageId, bool trackChanges);
        Task<IEnumerable<Image>> GetImageByUserAsync (string userId, bool trackChanges);
        Task<Image> GetImageByIdForUserAsync(string userId, int imageId, bool trackChanges);
        Task CreateImageAsync(string userId, Image image);
        Task DeleteImageAsync(string userId, Image image);
        Task LikeImageAsync(Image image);
        Task UpdateImageByUserAsync(string userId, Image image);
        Task ApprovalImageByAdminAsync(Image image);
        Task DenyImageByAdminAsync(Image image);



        Task<IEnumerable<Image>> GetImageHasApproval();
        Task<IEnumerable<Image>> GetImageNotApproval();
    }
}
