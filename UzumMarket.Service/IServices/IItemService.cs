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
    public interface IItemService
    {
        IQueryable<Item> GetAll(Expression<Func<Item, bool>> expression, string[] includes = null);
        ValueTask<ItemDto> GetAsync(Expression<Func<Item, bool>> expression, string[] includes = null);
        ValueTask<ItemDto> CreateAsync(ItemDto entity);
        ValueTask<bool> DeleteAsync(Expression<Func<Item, bool>> expression);
        ItemDto Update(int id, ItemDto entity);
    }
}
