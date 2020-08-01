using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using repository_dapper.Options;
using repository_dapper.Repository;

namespace repository_dapper.Features.User
{
    public class UserRepository : RepositoryBase<UserDto>, IUserRepository
    {
        public UserRepository(DatabaseOptions dbOptions) 
            : base(dbOptions) {}

        public async Task<bool> DeleteUserAsync(UserDto user)
        {
            return await DeleteAsync(user);
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            return await DeleteAsync(id);
        }

        public async Task<UserDto> GetUserAsync(Guid id)
        {
            return await FindByIdAsync(id);
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            return await FindAllAsync();
        }

        public async Task<bool> InsertUserAsync(UserDto user)
        {
            user.Id = Guid.NewGuid();
            user.CreatedAt = DateTime.Now;

            return await CreateAsync(user);
        }

        public async Task<bool> UpdateUserAsync(UserDto user)
        {
            return await UpdateAsync(user);
        }
    }
}