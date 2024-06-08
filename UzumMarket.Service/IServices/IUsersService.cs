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
    public interface IUsersService
    {
        IQueryable<Users> GetAll(Expression<Func<Users, bool>> expression, string[] includes = null);
        ValueTask<UsersDto> GetAsync(Expression<Func<Users, bool>> expression, string[] includes = null);
        ValueTask<UsersDto> CreateAsync(UsersDto entity);
        ValueTask<bool> DeleteAsync(Expression<Func<Users, bool>> expression);
        UsersDto Update(int id, UsersDto entity);
    }
}
