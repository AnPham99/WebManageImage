using Entities.DTO;
using Entities.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICommentRepository
    {
        Task<IEnumerable> GetAllCommentAsync(int imageId, bool trackChanges);
        Task CreateCommentAsync(string userId, int imageId, Comment comment);

    }
}
