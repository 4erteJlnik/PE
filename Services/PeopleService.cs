using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PE.Entity;
using PE.Infrastructure.DTO;
using PE.Infrastructure.Repository;

namespace PE.Services
{
    public class PeopleService
    {
        private readonly IPeopleRepository _peopleRepository;
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        public PeopleService(IPostRepository postRepository,
                             IPeopleRepository peopleRepository,
                             IMapper mapper)
        {
            //DI
            _postRepository = postRepository;
            _peopleRepository = peopleRepository;
            _mapper = mapper;
        }
        public People GetwoPosts(Guid id)
        {
            return _mapper.Map<People>(_peopleRepository.GetByIdAsync(id).Result);
        }
        public People Get(Guid id)
        {
            People p = _mapper.Map<People>(_peopleRepository.GetByIdAsync(id).Result);
            p.Posts = (ICollection<Post>)_postRepository.ByUser(id).ToList();
            return p;
        }
        public IEnumerable<People> GetAll()
        {
            return _mapper.Map<IEnumerable<People>>(_peopleRepository.GetAll());
        }
        public IEnumerable<People> GetAll(int number)
        {
            return _mapper.Map<IEnumerable<People>>(_peopleRepository.GetNumber(number));
        }
        public void Add(Peoplelogindto People)
        {
            if (People == null)
                throw new ArgumentNullException();
            Peopledto dto = new Peopledto
            {
                ID = People.Id,
                DateOfCreate = DateTime.Now,
                FIO = "NewUser",
                Posts = new List<Postdto>(),
                Comments = new List<PostCommentdto>(),
                Avatar = null,
                Peoplelogin = People,
                Rating = 0
            };
            _peopleRepository.AddAsyncAndSave(dto).Wait();
            _peopleRepository.SaveChangesAsync();
        }
        public People Edit(People People)
        {
            Peopledto old = _peopleRepository.GetByIdAsync(People.ID).Result;
            if (old == null)
                throw new Exception("Errror in Edit " + People.ID.ToString());
            old.DateOfCreate = People.DateOfCreate;
            old.Avatar = People.Avatar;
            old.FIO = People.FIO;
            old.Rating = People.Rating;
            _peopleRepository.EditAsyncAndSave(old);
            _peopleRepository.SaveChangesAsync();
            return _mapper.Map<People>(_peopleRepository.GetByIdAsync(People.ID).Result);
        }
        public void EditVoid(People People)
        {
            Peopledto old = _peopleRepository.GetByIdAsync(People.ID).Result;
            if (old == null)
                throw new Exception("Errror in EditVoid " + People.ID.ToString());
            old.DateOfCreate = People.DateOfCreate;
            old.Avatar = People.Avatar;
            old.FIO = People.FIO;
            old.Rating = People.Rating;
            _peopleRepository.EditAsyncAndSave(old);
            _peopleRepository.SaveChangesAsync();
        }
    }
}
