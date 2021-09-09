using AutoMapper;
using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Entities.DTO;
using System.Collections;

namespace Repository
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly IMapper _mapper;

        public CommentRepository(RepositoryContext repositoryContext, IMapper mapper) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable> GetAllCommentAsync(int imageId, bool trackChanges)
        {
            var rs = from c in _repositoryContext.Comments
                     join u in _repositoryContext.Users
                     on c.UserId equals u.Id
                     where c.ImageId == imageId
                     select new
                     {
                         UserName = u.UserName,
                         Content = c.Content
                     };

            return await rs.ToListAsync();
        }

        public async Task CreateCommentAsync(string userId, int imageId, Comment comment)
        {
            comment.UserId = userId;
            comment.ImageId = imageId;
            Create(comment);
            await SaveChangeAsync();
        }
    }
}
