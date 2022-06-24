using PE.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE.Infrastructure.Repository
{
    public interface IPostCommentRepository : ICommentRepository<PostCommentdto>
    {
        IEnumerable<PostCommentdto> ByPost(Guid post);
        IEnumerable<PostCommentdto> ByPost(Postdto post);
    }
}
