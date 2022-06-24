using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using Web1.Domain;
using Web1.Infrastructure;
using Web1.Infrastructure.AutoMapper;
using Web1.Infrastructure.Repository;
using Web1.Services;
using Xunit;

namespace UnitAppTest.Tests
{
    public class CommentServiceTests
    {
        private readonly Mock<IPostCommentRepository> _postCommentRepositoryMock;
        private readonly Mock<IPeopleRepository> _peopleRepositoryMock;
        private readonly Mock<IPostRepository> _postsRepositoryMock;
        private readonly IMapper _mapper;

        private readonly CommentService _commentService;

        public CommentServiceTests()
        {
            _postCommentRepositoryMock = new Mock<IPostCommentRepository>();
            _peopleRepositoryMock = new Mock<IPeopleRepository>();
            _postsRepositoryMock = new Mock<IPostRepository>();

            var config = new MapperConfiguration(mc => mc.AddProfile(new ApplicationMapperProfile()));
            _mapper = config.CreateMapper();

            _commentService = new CommentService(_peopleRepositoryMock.Object,
                _postsRepositoryMock.Object,
                _postCommentRepositoryMock.Object,
                _mapper);
        }

        [Fact]
        public void GetAll_Should_Return_All_Mapped_Comments()
        {
            //Arrange
            var commentsStub = new List<PostCommentdto>
            {
                new PostCommentdto { Description = "test description", ID = Guid.NewGuid(), UserId = Guid.NewGuid() }
            };

            _postCommentRepositoryMock.Setup(_ => _.GetAll()).Returns(commentsStub);

            //Act
            var result = _commentService.GetAll();

            //Assert
            Assert.NotEmpty(result);
        }
    }
}
