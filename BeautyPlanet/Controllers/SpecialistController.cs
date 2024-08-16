﻿using AutoMapper;
using BeautyPlanet.DTOs;
using BeautyPlanet.IRepository;
using BeautyPlanet.Migrations;
using BeautyPlanet.Models;
using BeautyPlanet.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeautyPlanet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialistController : ControllerBase
    {

        private readonly UserManager<Person> _userManager;
        private readonly ILogger<SpecialistController> _logger;
        private readonly IAuthoManger _authoManger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SpecialistController(UserManager<Person> userManager, ILogger<SpecialistController> logger, IAuthoManger authoManger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _logger = logger;
            _authoManger = authoManger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet("GetAppointmentByDate")]
        public async Task<IActionResult>GetAppointmentByDate(string spId,DateTime date)
        {

            var app = await _unitOfWork.Appointment.GetAll(q => q.SpecialistId.Equals(spId) && q.StartTime.Date == date.Date, include: x => x.Include(c => c.Center).Include(ca => ca.Category).Include(s => s.Specialist).Include(st => st.Status),orderBy:o=>o.OrderBy(s=>s.StartTime));
            var map=_mapper.Map<IList<GetAppointment>>(app);
            foreach (var item in map)
            {
                foreach (var a in app)
                    if (item.Id == a.Id)
                        item.Status = a.Status.Name;

            }
            return Ok(map);
        }
    }
}