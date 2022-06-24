using System;
using Web1.Domain;
using Web1.Infrastructure;
using AutoMapper;
using System.Collections.Generic;

namespace Web1.Infrastructure.AutoMapper
{

    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {

            CreateMap<PostComment, PostCommentdto>();
            CreateMap<PostCommentdto, PostComment>();
            CreateMap<People, Peopledto>();
            //    .ForPath(p => p.Peoplelogin.Email, p => p.MapFrom(p => p.ContactMail));
            CreateMap<Peopledto, People>();
            //    .ForPath(p => p.ContactMail, p => p.MapFrom(p => p.Peoplelogin.Email));
            CreateMap<Post, Postdto>();
            CreateMap<Postdto, Post>();

        }

    }
}