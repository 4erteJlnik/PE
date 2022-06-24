using PE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE.Services
{
    public interface ICommentService
    {
        List<PostComment> GetAll();
        List<PostComment> GetNumber(int number);
        void Add(PostComment comment);
        IEnumerable<PostComment> GetByPost(Guid id);
        IEnumerable<PostComment> GetByUser(Guid id);
        PostComment GetById(Guid id);
        PostComment Edit(Guid id, String Description);
        Task EditVoid(Guid id, String Description);
        void Delete(Guid id);
    }
}
