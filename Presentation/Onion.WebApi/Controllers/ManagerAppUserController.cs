using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.DtoClasses;
using Onion.Application.ManagerInterfaces;
using Onion.WebApi.Models.RequestModels.AppUsers;
using Onion.WebApi.Models.ResponseModels.AppUsers;

namespace Onion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerAppUserController : ControllerBase
    {
        private readonly IAppUserManager _appUserManager;
        private readonly IMapper _mapper;

        public ManagerAppUserController(IAppUserManager appUserManager, IMapper mapper)
        {
            _appUserManager = appUserManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> AppUsersList()
        {
            List<AppUserDto> values = await _appUserManager.GetAllAsync();
            List<AppUserResponseModel> response = _mapper.Map<List<AppUserResponseModel>>(values);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppUser(int id)
        {
            AppUserDto value = await _appUserManager.GetByIdAsync(id);
            return Ok(_mapper.Map<AppUserResponseModel>(value));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppUser(CreateAppUserRequestModel model)
        {
            AppUserDto dto = _mapper.Map<AppUserDto>(model);
            await _appUserManager.CreateAsync(dto);
            return Ok("Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAppUser(UpdateAppUserRequestModel model)
        {
            AppUserDto dto = _mapper.Map<AppUserDto>(model);
            await _appUserManager.UpdateAsync(dto);
            return Ok("Güncellendi");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PacifyAppUser(int id)
        {
            string mesaj = await _appUserManager.SoftDeleteAsync(id);
            return Ok(mesaj);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAppUser(int id)
        {
            string mesaj = await _appUserManager.HardDeleteAsync(id);
            return Ok(mesaj);
        }
    }
}
