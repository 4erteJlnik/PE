using System;
using Microsoft.EntityFrameworkCore;
using Web1.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Web1.Infrastructure.Repository
{


    public interface IPostCommentRepository : ICommentRepository<PostCommentdto>
    {
        IEnumerable<PostCommentdto> ByPost(Guid post);
        IEnumerable<PostCommentdto> ByPost(Postdto post);
    }
}