using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.DtoClasses;
using Onion.Application.ManagerInterfaces;
using Onion.WebApi.Models.RequestModels.Categories;
using Onion.WebApi.Models.ResponseModels.Categories;

namespace Onion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerCategoryController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager;
        private readonly IMapper _mapper;
        public ManagerCategoryController(ICategoryManager categoryManager, IMapper mapper)
        {
            _categoryManager = categoryManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> CategoriesList()
        {
            List<CategoryDto> values = await _categoryManager.GetAllAsync();
            List<CategoryResponseModel> responseModels = _mapper.Map<List<CategoryResponseModel>>(values);

            return Ok(responseModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            CategoryDto value = await _categoryManager.GetByIdAsync(id);

            return Ok(_mapper.Map<CategoryResponseModel>(value));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestModel model)
        {
            CategoryDto category = _mapper.Map<CategoryDto>(model);
            await _categoryManager.CreateAsync(category);
            return Ok("Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryRequestModel model)
        {
            CategoryDto category = _mapper.Map<CategoryDto>(model);
            await _categoryManager.UpdateAsync(category);
            return Ok("Güncellendi");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PacifyCategory(int id)
        {
            string mesaj = await _categoryManager.SoftDeleteAsync(id);
            return Ok(mesaj);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            string mesaj = await _categoryManager.HardDeleteAsync(id);
            return Ok(mesaj);
        }
    }
}
