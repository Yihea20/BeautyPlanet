﻿using AutoMapper;
using BeautyPlanet.DTOs;
using BeautyPlanet.IRepository;
using BeautyPlanet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeautyPlanet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductController> _logger;
        private readonly IWebHostEnvironment _environment;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProductController> logger, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _environment = environment;
        }
        [NonAction]
        private string GetFilePath(string name)
        {
            return this._environment.WebRootPath + "/Upload/ProductImage/" + name;
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm] ProductFile product)
        {
            string hosturl = $"{this.Request.Scheme}://11171443:60-dayfreetrial@{this.Request.Host}{this.Request.PathBase}";
            try
            {
                string FilePath = GetFilePath(product.Products.Name);
                if (!System.IO.Directory.Exists(FilePath))
                {
                    System.IO.Directory.CreateDirectory(FilePath);
                }
                string url = FilePath + "\\" + product.Products.Name + ".png";
                if (System.IO.File.Exists(url))
                {
                    System.IO.File.Delete(url);
                }
                using (FileStream stream = System.IO.File.Create(url))
                {
                    await product.Files.CopyToAsync(stream);
                    var result = _mapper.Map<Product>(product.Products);
                    result.ImageUrl = hosturl + "/Upload/ProductImage/" + product.Products.Name + "/" + product.Products.Name + ".png";
                    await _unitOfWork.Product.Insert(result);
                    await _unitOfWork.Save();
                    return Ok();
                }
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
        [HttpGet("GetAllPRoduct")]
        public async Task<IActionResult> GetAllProduct()
        {
            var product = await _unitOfWork.Product.GetAll(include:x=>x.Include(p=>p.Colors).Include(x=>x.Sizes).Include(p=>p.Centers).Include(r => r.Reviews));
            var map =_mapper.Map<IList<GetProduct>>(product);
            return Ok(map);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _unitOfWork.Product.Get(q=>q.Id==id, include: x => x.Include(p => p.Colors).Include(x => x.Sizes).Include(p => p.Centers).Include(r=>r.Reviews));
            var map = _mapper.Map<GetProduct>(product);
            return Ok(map);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDTO centerDto)
        {
            var old = await _unitOfWork.Product.Get(q => q.Id == id);
            //old.Sizes = centerDto.Sizes;
            _unitOfWork.Product.Update(old);
            await _unitOfWork.Save();
            return Ok();
        }
    }
}
