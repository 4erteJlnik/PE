using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web1.Domain;

namespace Web1.Services
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
