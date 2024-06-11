using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UzumMarket.Service.Dto_s;
using UzumMarket.Service.IServices;

namespace UzumMarketWepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService service;

        public ItemController(IItemService service)
        {
            this.service = service;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(ItemDto itemDto)
            => Ok(await service.CreateAsync(itemDto));

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
            => Ok(service.GetAll(p => p.Id != 0));

        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int id, ItemDto itemDto)
            => Ok(service.Update(id, itemDto));

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAll([FromRoute] int id)
            => Ok(await service.GetAsync(p => p.Id == id));

        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await service.DeleteAsync(p => p.Id == id));
    }
}
