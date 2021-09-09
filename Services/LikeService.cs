/*using Contracts;
using Entities.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;
        public LikeService(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }
        public async Task CreateLikeAsync(string userId, int imageId)
        {

            await _likeRepository.CreateLikeAsync(userId, imageId);
        }

    }
}
*/