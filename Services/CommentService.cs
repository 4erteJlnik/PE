using AutoMapper;
using PE.Entity;
using PE.Infrastructure.DTO;
using PE.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE.Services
{
    public class CommentService : ICommentService
    {
        private readonly IPostCommentRepository _postCommentRepository;
        private readonly IPeopleRepository _peopleRepository;
        private readonly IPostRepository _postsRepository;
        private readonly IMapper _mapper;

        public CommentService(IPeopleRepository peopleRepository,
                              IPostRepository postsRepository,
                              IPostCommentRepository postCommentRepository,
                              IMapper mapper)
        {
            _postCommentRepository = postCommentRepository;
            _peopleRepository = peopleRepository;
            _postsRepository = postsRepository;
            _mapper = mapper;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>

        public List<PostComment> GetAll()
        {
            return _mapper.Map<List<PostComment>>(_postCommentRepository.GetAll().ToList<PostCommentdto>());
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public List<PostComment> GetNumber(int number)
        {
            return _mapper.Map<List<PostComment>>(_postCommentRepository.GetNumber(number).ToList<PostCommentdto>());
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public void Add(PostComment comment)
        {
            PostCommentdto postComment = _mapper.Map<PostCommentdto>(comment);

            postComment.Post = _postsRepository.GetByIdAsync(comment.PostId).Result;

            if (postComment.Post == null)
            {
                throw new Exception("Not find Post " + postComment.PostId.ToString());
            }

            postComment.User = _peopleRepository.GetByIdAsync(comment.UserId).Result;

            if (postComment.User == null)
            {
                throw new Exception("Not find User " + postComment.UserId.ToString());
            }

            _postCommentRepository.AddAsyncAndSave(postComment).Wait();
            _postCommentRepository.SaveChangesAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<PostComment> GetByPost(Guid id)
        {
            return _mapper.Map<IEnumerable<PostComment>>(_postCommentRepository.ByPost(id));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<PostComment> GetByUser(Guid id)
        {
            return _mapper.Map<IEnumerable<PostComment>>(_postCommentRepository.ByUser(id));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PostComment GetById(Guid id)
        {
            PostCommentdto comment = _postCommentRepository.GetByIdAsync(id).Result;
            if (comment == null)
                throw new Exception("Not find GetById " + id.ToString());
            return _mapper.Map<PostComment>(comment);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Description"></param>
        /// <returns></returns>
        public PostComment Edit(Guid id, String Description)
        {
            PostCommentdto dto = _postCommentRepository.GetByIdAsync(id).Result;
            if (dto == null)
                throw new Exception("Not find Edit " + id.ToString());
            dto.DateOfCreate = DateTime.Now;
            dto.Description = Description;
            _postCommentRepository.EditAsyncAndSave(dto);
            return GetById(id);
        }
        public async Task EditVoid(Guid id, String Description)
        {
            PostCommentdto dto = await _postCommentRepository.GetByIdAsync(id);
            if (dto == null)
                throw new Exception("Not find EditVoid " + id.ToString());
            dto.DateOfCreate = DateTime.Now;
            dto.Description = Description;
            await _postCommentRepository.EditAsyncAndSave(dto);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public void Delete(Guid id)
        {
            _postCommentRepository.DeleteAsyncAndSave(id);
        }
    }
}
