using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.DtoClasses;
using Onion.Application.ManagerInterfaces;
using Onion.WebApi.Models.RequestModels.AppUserProfiles;
using Onion.WebApi.Models.ResponseModels.AppUserProfiles;

namespace Onion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerAppUserProfileController : ControllerBase
    {
        private readonly IAppUserProfileManager _appUserProfileManager;
        private readonly IMapper _mapper;

        public ManagerAppUserProfileController(IAppUserProfileManager appUserProfileManager, IMapper mapper)
        {
            _appUserProfileManager = appUserProfileManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> AppUserProfilesList()
        {
            List<AppUserProfileDto> values = await _appUserProfileManager.GetAllAsync();
            List<AppUserProfileResponseModel> response = _mapper.Map<List<AppUserProfileResponseModel>>(values);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppUserProfile(int id)
        {
            AppUserProfileDto value = await _appUserProfileManager.GetByIdAsync(id);
            return Ok(_mapper.Map<AppUserProfileResponseModel>(value));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppUserProfile(CreateAppUserProfileRequestModel model)
        {
            AppUserProfileDto dto = _mapper.Map<AppUserProfileDto>(model);
            await _appUserProfileManager.CreateAsync(dto);
            return Ok("Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAppUserProfile(UpdateAppUserProfileRequestModel model)
        {
            AppUserProfileDto dto = _mapper.Map<AppUserProfileDto>(model);
            await _appUserProfileManager.UpdateAsync(dto);
            return Ok("Güncellendi");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PacifyAppUserProfile(int id)
        {
            string mesaj = await _appUserProfileManager.SoftDeleteAsync(id);
            return Ok(mesaj);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAppUserProfile(int id)
        {
            string mesaj = await _appUserProfileManager.HardDeleteAsync(id);
            return Ok(mesaj);
        }
    }
}
