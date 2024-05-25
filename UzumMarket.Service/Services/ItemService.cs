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
    public class ItemService : IItemService
    {
        private readonly IGenericRepository<Item> repository;
        private readonly IMapper mapper;
        public ItemService(IGenericRepository<Item> repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async ValueTask<ItemDto> CreateAsync(ItemDto entity)
        {
            var item = new Item();
            if (entity is not null)
            {
                var newItem = mapper.Map<Item>(entity);
                item = await repository.CreateAsync(newItem);
            }
            repository.SaveChangesAsync();
            return mapper.Map<ItemDto>(item);
        }

        public async ValueTask<bool> DeleteAsync(Expression<Func<Item, bool>> expression)
        {
            bool result = await repository.DeleteAsync(expression);
            await repository.SaveChangesAsync();
            return result;
        }

        public IQueryable<Item> GetAll(Expression<Func<Item, bool>> expression, string[] includes = null)
            => repository.GetAll(expression, includes);

        public async ValueTask<ItemDto> GetAsync(Expression<Func<Item, bool>> expression, string[] includes = null)
        {
            var item = await repository.GetAsync(expression, includes);
            return mapper.Map<ItemDto>(item);
        }

        public ItemDto Update(int id, ItemDto entity)
        {
            var item = mapper.Map<Item>(entity);
            item.Id = id;
            var newItem = repository.Update(item);
            return mapper.Map<ItemDto>(newItem);
        }
    }
}
