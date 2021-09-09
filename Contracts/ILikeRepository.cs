using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ILikeRepository
    {
        Task<Like> GetLikeAsync(string userId, int imageId, bool trackChanges);
        Task CreateLikeAsync(string userId, int imageId);
        Task DeleteLikeAsync(string userId, int imageId, Like like);
        Task PlusUpdateLikeAsync(string userId, int imageId, Like like);
        Task MinusUpdateLikeAsync(string userId, int imageId, Like like);



    }
}
