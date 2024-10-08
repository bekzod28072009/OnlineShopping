﻿using AutoMapper;
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
    public class UsersService : IUsersService
    {
        private readonly IGenericRepository<Users> repository;
        private readonly IMapper mapper;
        public UsersService(IGenericRepository<Users> repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async ValueTask<UsersDto> CreateAsync(UsersDto entity)
        {
            var user = new Users();
            if (entity is not null)
            {
                var newUser = mapper.Map<Users>(entity);
                user = await repository.CreateAsync(newUser);
            }
            repository.SaveChangesAsync();
            return mapper.Map<UsersDto>(user);
        }

        public async ValueTask<bool> DeleteAsync(Expression<Func<Users, bool>> expression)
        {
            bool result = await repository.DeleteAsync(expression);
            await repository.SaveChangesAsync();
            return result;
        }

        public IQueryable<Users> GetAll(Expression<Func<Users, bool>> expression, string[] includes = null)
            => repository.GetAll(expression, includes);

        public async ValueTask<UsersDto> GetAsync(Expression<Func<Users, bool>> expression, string[] includes = null)
        {
            var users = await repository.GetAsync(expression, includes);
            return mapper.Map<UsersDto>(users);
        }

        public UsersDto Update(int id, UsersDto entity)
        {
            var user = mapper.Map<Users>(entity);
            user.Id = id;
            var newOrder = repository.Update(user);
            return mapper.Map<UsersDto>(newOrder);
        }
    }
}
