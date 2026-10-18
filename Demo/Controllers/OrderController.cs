using AutoMapper;
using Demo.Dtos.OrderDto;
using Demo.Models;
using Demo.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;


        public OrderController(IUOW uow , IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderDto dto)
        {
            var orderdto = _mapper.Map<Order>(dto);
            await _uow.Order.Create(orderdto);
            await _uow.Save();
            foreach(var item in dto.OrderItems)
            {
                var orderItemdto = _mapper.Map<OrderItem>(item);
                orderItemdto.OrderId = orderdto.OrderId;
                await _uow.OrderItem.Create(orderItemdto);
              

            }
            await _uow.Save();
            return Created();



        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var search = await _uow.Order.GetById(id);
            var res = _mapper.Map<Order>(search);
            return Ok(res);
        }

    }
}
