using PE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE.Services
{
    public interface IPostService
    {
        Post GetNoComments(Guid id);
        Post GetWithComments(Guid id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetNumber(int number);
        IEnumerable<Post> GetByUser(Guid user);
        void Add(Post post);
        Post Edit(Post post, bool admin);
        void EditVoid(Post post, bool admin);
        void Delete(Guid id, Guid user, bool admin);
    }
}
