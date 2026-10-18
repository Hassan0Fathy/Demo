using AutoMapper;
using Demo.Dtos.CategoryDto;
using Demo.Dtos.ProductDto;
using Demo.Models;
using Demo.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;
        public ProductController(IUOW uow , IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetByFilter(int? categoryId, int? pageNumber, int? pageSize, int? Price)
        {
            var search = await _uow.Product.GetByFilter(categoryId, pageNumber, pageSize, Price);
            var res = _mapper.Map<ICollection< ReadProductDto>>(search);
            return Ok(res);
        }
        [HttpGet("GetMostPriceByCategoryId")]
        public async Task<IActionResult>GetMostPrice(int categoryid)
        {
            var search = await _uow.Product.GetSecondMostPriceByCategoryId(categoryid);
            var res = _mapper.Map<ReadProductDto>(search);
            return Ok(res);
        }
        [HttpGet("SearchByName")]
        public async Task<IActionResult> SearchName(string name)
        {
            var search = await _uow.Product.SearchByName(name);
            var res = _mapper.Map<ReadProductDto>(search);
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            var res = _mapper.Map<Product>(dto);
            await _uow.Product.Create(res);
            await _uow.Save();
            return Created(string.Empty, new { message = $"{dto.ProductName} Created!" });


        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id ,UpdateProductDto dto)
        {
            var search = await _uow.Product.GetById(id);
            var res = _mapper.Map(dto, search);

            _uow.Product.Update(res);
            await _uow.Save();
            return Ok();

        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateStock(int id , UpdateStockDto dto)
        {
            var search = await _uow.Product.GetById(id);
            var res = _mapper.Map(dto, search);
            _uow.Product.Update(res);
            await _uow.Save();
            return Ok(res);
        }

    }
}
