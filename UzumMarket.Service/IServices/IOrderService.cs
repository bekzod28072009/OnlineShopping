using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UzumMarket.Domain.Entity;
using UzumMarket.Service.Dto_s;

namespace UzumMarket.Service.IServices
{
    public interface IOrderService
    {
        IQueryable<Order> GetAll(Expression<Func<Order, bool>> expression, string[] includes = null);
        ValueTask<OrderDto> GetAsync(Expression<Func<Order, bool>> expression, string[] includes = null);
        ValueTask<OrderDto> CreateAsync(OrderDto entity);
        ValueTask<bool> DeleteAsync(Expression<Func<Order, bool>> expression);
        OrderDto Update(int id, OrderDto entity);
    }
}
