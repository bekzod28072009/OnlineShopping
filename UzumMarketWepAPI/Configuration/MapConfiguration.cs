using AutoMapper;
using UzumMarket.Domain.Entity;
using UzumMarket.Service.Dto_s;

namespace UzumMarketWepAPI.Configuration
{
    public class MapConfiguration : Profile
    {
        public MapConfiguration()
        {
            CreateMap<Item, ItemDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Users, UsersDto>().ReverseMap();
        }
    }
}
