using System;
using Microsoft;
using Web1.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using Web1.Domain;
using AutoMapper;
using Web1.Infrastructure.AutoMapper;
using System.Threading.Tasks;
using Web1.Infrastructure.Repository;

namespace Web1.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IPeopleRepository _peopleRepository;
        private readonly IMapper _mapper;
        private readonly IPostCommentRepository _postCommentRepository;

        public PostService(IPostCommentRepository commentRepository,
                           IPeopleRepository peopleRepository,
                           IPostRepository postRepository,
                           IMapper mapper)
        {
            //DI
            _postCommentRepository = commentRepository;
            _peopleRepository = peopleRepository;
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public Post GetNoComments(Guid id)
        {
            return _mapper.Map<Post>(_postRepository.GetByIdAsync(id).Result);
        }
        public Post GetWithComments(Guid id)
        {
            Post post = _mapper.Map<Post>(_postRepository.GetByIdAsync(id).Result);
            post.Comments = _mapper.Map<List<PostComment>>(_postCommentRepository.ByPost(id).ToList());
            return post;
        }
        public IEnumerable<Post> GetAll()
        {
            return _mapper.Map<IEnumerable<Post>>(_postRepository.GetAll());
        }
        public IEnumerable<Post> GetNumber(int number)
        {
            return _mapper.Map<IEnumerable<Post>>(_postRepository.GetNumber(number));
        }
        public IEnumerable<Post> GetByUser(Guid user)
        {
            return _mapper.Map<IEnumerable<Post>>(_postRepository.ByUser(user));
        }
        public void Add(Post post)
        {
            Postdto dto = _mapper.Map<Postdto>(post);
            dto.Creator = _peopleRepository.GetByIdAsync(post.CreatorId).Result;
            if (dto.Creator == null)
                throw new Exception("Пользователь не найден " + post.CreatorId.ToString());
            _postRepository.AddAsyncAndSave(dto).Wait();
        }
        public Post Edit(Post post, bool admin)
        {
            Postdto old = _postRepository.GetByIdAsync(post.ID).Result;
            if (old == null)
                throw new Exception("Обьявление не найдено " + post.ID.ToString());
            if (admin | (post.CreatorId == old.CreatorId))
            {
                old.DateOfCreate = post.DateOfCreate;
                old.Description = post.Description;
                old.Name = post.Name;
                old.Cost = post.Cost;
                old.City = post.City;
                _postRepository.EditAsyncAndSave(old).Wait();
                return _mapper.Map<Post>(_postRepository.GetByIdAsync(post.ID).Result);
            }
            else
                throw new Exception("Вы не являетесь автором");
        }
        public void EditVoid(Post post, bool admin)
        {
            Postdto old = _postRepository.GetByIdAsync(post.ID).Result;
            if (old == null)
                throw new Exception("Обьявление не найдено " + post.ID.ToString());
            if (admin | (post.CreatorId == old.CreatorId))
            {
                old.DateOfCreate = post.DateOfCreate;
                old.Description = post.Description;
                old.Name = post.Name;
                old.Cost = post.Cost;
                old.City = post.City;
                _postRepository.EditAsyncAndSave(old);
            }
            else
                throw new Exception("Вы не являетесь автором");
        }
        public void Delete(Guid id, Guid user, bool admin)
        {
            if (admin)
            {
                _postRepository.DeleteAsyncAndSave(id).Wait();
                _postRepository.SaveChangesAsync();
            }
            else
            {
                Postdto old = _postRepository.GetByIdAsync(id).Result;
                if (old.CreatorId == user)
                {
                    _postRepository.DeleteAsyncAndSave(id).Wait();
                    _postRepository.SaveChangesAsync();
                }
                else
                throw new Exception("Вы не являетесь автором");
            }
        }
    }
}