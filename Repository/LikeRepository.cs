using AutoMapper;
using Contracts;
using Entities;
using Entities.DTO;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class LikeRepository : RepositoryBase<Like>, ILikeRepository
    {
        private readonly IMapper _mapper;
        private readonly RepositoryContext _repositoryContext;
        public LikeRepository(RepositoryContext repositoryContext, IMapper mapper) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _mapper = mapper;
        }

        public async Task<Like> GetLikeAsync(string userId, int imageId, bool trackChanges) =>
            await FindByCondition(l => l.ImageId.Equals(imageId) && l.UserId.Equals(userId), trackChanges)
            .SingleOrDefaultAsync();


        public async Task CreateLikeAsync(string userId, int imageId)
        {
            Like like = new Like();
            like.UserId = userId;
            like.ImageId = imageId;
            like.IsLike = true;
            Create(like);
            await SaveChangeAsync();
        }

        public async Task DeleteLikeAsync(string userId, int imageId, Like like)
        {
            if(like.UserId == userId && like.ImageId == imageId)
                Delete(like);
            await SaveChangeAsync();
        }

        public async Task PlusUpdateLikeAsync(string userId, int imageId, Like like)
        {
            if (like.UserId == userId && like.ImageId == imageId)
            {
                like.UserId = userId;
                like.ImageId = imageId;
                like.IsLike = true;
                Update(like);
            }
            await SaveChangeAsync();
        }


        public async Task MinusUpdateLikeAsync(string userId, int imageId, Like like)
        {
            if (like.UserId == userId && like.ImageId == imageId)
            {
                like.UserId = userId;
                like.ImageId = imageId;
                like.IsLike = false;
                Update(like);
            }
            await SaveChangeAsync();
        }
    }
}
