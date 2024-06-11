using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UzumMarket.Service.Dto_s;
using UzumMarket.Service.IServices;

namespace UzumMarketWepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService service;

        public OrderController(IOrderService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(OrderDto dto)
            => Ok(await service.CreateAsync(dto));

        [HttpGet]
        public async ValueTask<IActionResult> GetAsync()
            => Ok(service.GetAll(p => p.Id != 0));

        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int Id, OrderDto dto)
            => Ok(service.Update(Id, dto));

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAll([FromRoute] int Id)
            => Ok(await service.GetAsync(p => p.Id == Id));

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] int Id)
            => Ok(await service.DeleteAsync(p => p.Id == Id));
    }
}
