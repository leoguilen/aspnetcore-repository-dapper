using AutoMapper;
using repository_dapper.Contracts.Request;
using repository_dapper.Features.User;

namespace repository_dapper.Mapping
{
    public class RequestToDto : Profile
    {
        public RequestToDto()
        {
            CreateMap<CreateUserRequest, UserDto>();
            CreateMap<UpdateUserRequest, UserDto>();
        }
    }
}