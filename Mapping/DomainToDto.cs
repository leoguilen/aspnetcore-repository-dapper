using AutoMapper;
using repository_dapper.Entitades;
using repository_dapper.Features.User;

namespace repository_dapper.Mapping
{
    public class DomainToDto : Profile
    {
        public DomainToDto()
        {
            CreateMap<User, UserDto>();
        }
    }
}