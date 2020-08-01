using AutoMapper;
using repository_dapper.Contracts.Response;
using repository_dapper.Features.User;

namespace repository_dapper.Mapping
{
    public class DtoToResponse : Profile
    {
        public DtoToResponse()
        {
            CreateMap<UserDto, UserResponse>();
        }
    }
}