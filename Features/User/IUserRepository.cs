using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using repository_dapper.Repository;

namespace repository_dapper.Features.User
{
    public interface IUserRepository : IRepositoryBase<UserDto>
    {
         Task<IEnumerable<UserDto>> GetUsersAsync();
         Task<UserDto> GetUserAsync(Guid id);
         Task<bool> InsertUserAsync(UserDto user);
         Task<bool> UpdateUserAsync(UserDto user);
         Task<bool> DeleteUserAsync(UserDto user);
         Task<bool> DeleteUserAsync(Guid id);
    }
}