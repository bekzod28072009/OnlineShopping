using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UzumMarket.Service.Dto_s;
using UzumMarket.Service.IServices;

namespace UzumMarketWepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService service;

        public UsersController(IUsersService service)
        {
            this.service = service;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(UsersDto dto)
            => Ok(await service.CreateAsync(dto));

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
            => Ok(service.GetAll(p => p.Id != 0));


        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int id, UsersDto dto)
            => Ok(service.Update(id, dto));




        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await service.GetAsync(u => u.Id == id));


        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await service.DeleteAsync(p => p.Id == id));
    }
}
