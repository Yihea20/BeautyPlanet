using AutoMapper;
using BeautyPlanet.Controllers;
using BeautyPlanet.DTOs;
using BeautyPlanet.IRepository;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyPlanetTest.UnitTest
{
    public  class PostControllerTest
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<PostController> _logger;
        private readonly IWebHostEnvironment _environment;

        public PostControllerTest()
        {
            _unitOfWork = A.Fake<IUnitOfWork>();
            _mapper = A.Fake<IMapper>();
            _logger = A.Fake<ILogger<PostController>>();
            _environment = A.Fake<IWebHostEnvironment>();
        }
        [Fact]
        public void GetPost()
        {

            var post = A.Fake<ICollection<GetCenterPost>>();
            var postlist = A.Fake<List<GetCenterPost>>();
            A.CallTo(() => _mapper.Map<List<GetCenterPost>>(post)).Returns(postlist);
            var controller = new PostController(_unitOfWork,_mapper,  _logger,_environment);
            var result = controller.GetAllPost("sadasd",null);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<IActionResult>));
        }
    }
}
