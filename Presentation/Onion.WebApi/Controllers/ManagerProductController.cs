using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.DtoClasses;
using Onion.Application.ManagerInterfaces;
using Onion.WebApi.Models.RequestModels.Products;
using Onion.WebApi.Models.ResponseModels.Products;

namespace Onion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerProductController : ControllerBase
    {
        private readonly IProductManager _productManager;
        private readonly IMapper _mapper;

        public ManagerProductController(IProductManager productManager, IMapper mapper)
        {
            _productManager = productManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ProductsList()
        {
            List<ProductDto> values = await _productManager.GetAllAsync();
            List<ProductResponseModel> response = _mapper.Map<List<ProductResponseModel>>(values);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            ProductDto value = await _productManager.GetByIdAsync(id);
            return Ok(_mapper.Map<ProductResponseModel>(value));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductRequestModel model)
        {
            ProductDto dto = _mapper.Map<ProductDto>(model);
            await _productManager.CreateAsync(dto);
            return Ok("Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductRequestModel model)
        {
            ProductDto dto = _mapper.Map<ProductDto>(model);
            await _productManager.UpdateAsync(dto);
            return Ok("Güncellendi");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PacifyProduct(int id)
        {
            string mesaj = await _productManager.SoftDeleteAsync(id);
            return Ok(mesaj);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            string mesaj = await _productManager.HardDeleteAsync(id);
            return Ok(mesaj);
        }
    }
}
