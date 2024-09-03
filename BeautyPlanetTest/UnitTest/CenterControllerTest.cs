using AutoMapper;
using BeautyPlanet.Controllers;
using BeautyPlanet.DTOs;
using BeautyPlanet.IRepository;
using BeautyPlanet.Repository;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyPlanetTest.UnitTest
{
    public  class CenterControllerTest
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CenterController> _logger;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;
        public CenterControllerTest()
        {
            _unitOfWork=A.Fake<IUnitOfWork>();
            _mapper=A.Fake<IMapper>();
            _logger = A.Fake<ILogger<CenterController>>();
            _environment= A.Fake<IWebHostEnvironment>();
        }
        [Fact]
        public void GetCenter()
        {
            var center = A.Fake<ICollection<GetCenterDTO>>();
            var centerlist=A.Fake<List<GetCenterDTO>>();
            A.CallTo(() => _mapper.Map<List<GetCenterDTO>>(center)).Returns(centerlist);
            var controller = new CenterController(_environment, _unitOfWork, _mapper, _logger);
            var result = controller.GetAllCenter();
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<IActionResult>));
        }
    }
}
