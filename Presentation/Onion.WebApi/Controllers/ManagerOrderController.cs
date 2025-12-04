using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.DtoClasses;
using Onion.Application.ManagerInterfaces;
using Onion.WebApi.Models.RequestModels.Orders;
using Onion.WebApi.Models.ResponseModels.Orders;

namespace Onion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerOrderController : ControllerBase
    {
        private readonly IOrderManager _orderManager;
        private readonly IMapper _mapper;

        public ManagerOrderController(IOrderManager orderManager, IMapper mapper)
        {
            _orderManager = orderManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> OrdersList()
        {
            List<OrderDto> values = await _orderManager.GetAllAsync();
            List<OrderResponseModel> response = _mapper.Map<List<OrderResponseModel>>(values);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            OrderDto value = await _orderManager.GetByIdAsync(id);
            return Ok(_mapper.Map<OrderResponseModel>(value));
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderRequestModel model)
        {
            OrderDto dto = _mapper.Map<OrderDto>(model);
            await _orderManager.CreateAsync(dto);
            return Ok("Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderRequestModel model)
        {
            OrderDto dto = _mapper.Map<OrderDto>(model);
            await _orderManager.UpdateAsync(dto);
            return Ok("Güncellendi");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PacifyOrder(int id)
        {
            string mesaj = await _orderManager.SoftDeleteAsync(id);
            return Ok(mesaj);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            string mesaj = await _orderManager.HardDeleteAsync(id);
            return Ok(mesaj);
        }
    }
}
