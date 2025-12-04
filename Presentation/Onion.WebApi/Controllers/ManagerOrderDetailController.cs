using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.DtoClasses;
using Onion.Application.ManagerInterfaces;
using Onion.WebApi.Models.RequestModels.OrderDetails;
using Onion.WebApi.Models.ResponseModels.OrderDetails;

namespace Onion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerOrderDetailController : ControllerBase
    {
        private readonly IOrderDetailManager _orderDetailManager;
        private readonly IMapper _mapper;

        public ManagerOrderDetailController(IOrderDetailManager orderDetailManager, IMapper mapper)
        {
            _orderDetailManager = orderDetailManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetailsList()
        {
            List<OrderDetailDto> values = await _orderDetailManager.GetAllAsync();
            List<OrderDetailResponseModel> response = _mapper.Map<List<OrderDetailResponseModel>>(values);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetail(int id)
        {
            OrderDetailDto value = await _orderDetailManager.GetByIdAsync(id);
            return Ok(_mapper.Map<OrderDetailResponseModel>(value));
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailRequestModel model)
        {
            OrderDetailDto dto = _mapper.Map<OrderDetailDto>(model);
            await _orderDetailManager.CreateAsync(dto);
            return Ok("Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailRequestModel model)
        {
            OrderDetailDto dto = _mapper.Map<OrderDetailDto>(model);
            await _orderDetailManager.UpdateAsync(dto);
            return Ok("Güncellendi");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PacifyOrderDetail(int id)
        {
            string mesaj = await _orderDetailManager.SoftDeleteAsync(id);
            return Ok(mesaj);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            string mesaj = await _orderDetailManager.HardDeleteAsync(id);
            return Ok(mesaj);
        }
    }
}
