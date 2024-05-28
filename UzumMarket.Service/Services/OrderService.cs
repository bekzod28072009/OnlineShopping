using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UzumMarket.DataAcces.IRepository;
using UzumMarket.Domain.Entity;
using UzumMarket.Service.Dto_s;
using UzumMarket.Service.IServices;

namespace UzumMarket.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> repository;
        private readonly IMapper mapper;

        public OrderService(IGenericRepository<Order> repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async ValueTask<OrderDto> CreateAsync(OrderDto entity)
        {
            var order = new Order();
            if (entity is not null)
            {
                var newOrder = mapper.Map<Order>(entity);
                order = await repository.CreateAsync(newOrder);
            }
            repository.SaveChangesAsync();
            return mapper.Map<OrderDto>(order);
        }

        public async ValueTask<bool> DeleteAsync(Expression<Func<Order, bool>> expression)
        {
            bool result = await repository.DeleteAsync(expression);
            await repository.SaveChangesAsync();
            return result;
        }

        public IQueryable<Order> GetAll(Expression<Func<Order, bool>> expression, string[] includes = null)
            => repository.GetAll(expression, includes);

        public async ValueTask<OrderDto> GetAsync(Expression<Func<Order, bool>> expression, string[] includes = null)
        {
            var order = await repository.GetAsync(expression, includes);
            return mapper.Map<OrderDto>(order);
        }

        public OrderDto Update(int id, OrderDto entity)
        {
            var order = mapper.Map<Order>(entity);
            order.Id = id;
            var newOrder = repository.Update(order);
            return mapper.Map<OrderDto>(newOrder);
        }
    }
}
