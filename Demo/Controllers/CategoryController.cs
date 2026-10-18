using AutoMapper;
using Demo.Dtos.CategoryDto;
using Demo.Models;
using Demo.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;
        public CategoryController(IUOW uow , IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var search = await _uow.Category.GetAllAsync();
            var res = _mapper.Map<ICollection<ReadCategoryDto>>(search);
            return Ok(res);

        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            var res =  _mapper.Map<Category>(dto);
            await _uow.Category.Create(res);
            await _uow.Save();
            return Created(string.Empty, new { message = $"{dto.CategoryName} Created!" });

        }

    }
}
