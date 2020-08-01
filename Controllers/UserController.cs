using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using repository_dapper.Contracts.Request;
using repository_dapper.Contracts.Response;
using repository_dapper.Features.User;

namespace repository_dapper.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet("api/users")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepository
                .GetUsersAsync();
            var usersResponse = _mapper
                .Map<List<UserResponse>>(users);

            return Ok(usersResponse);
        }

        [HttpGet("api/users/{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var user = await _userRepository
                .GetUserAsync(id);

            if(user == null)
                return NotFound();
            
            var userResponse = _mapper
                .Map<UserResponse>(user);
            
            return Ok(userResponse);
        }

        [HttpPost("api/users")]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {
            var newUser = _mapper
                .Map<UserDto>(request);
            var createdUser = await _userRepository
                .InsertUserAsync(newUser);

            if(!createdUser)
                return BadRequest();

            var absolutedUri = string.Concat(HttpContext.Request.Scheme, 
                "://", HttpContext.Request.Host.ToUriComponent(), 
                $"/api/users/{newUser.Id}");

            return Created(absolutedUri, _mapper
                .Map<UserResponse>(newUser));
        }

        [HttpPut("api/users/{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateUserRequest request)
        {
            var user = await _userRepository
                .GetUserAsync(id);
            
            if(user == null)
                return NotFound();

            user.FullName = request.FullName;
            user.Email = request.Email;

            var updatedUser = await _userRepository
                .UpdateUserAsync(user);

            if(!updatedUser)
                return BadRequest();
            
            return Ok(_mapper
                .Map<UserResponse>(user));
        }

        [HttpDelete("api/users/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var user = await _userRepository
                .GetUserAsync(id);
            
            if(user == null)
                return NotFound();
            
            var deletedUser = await _userRepository
                .DeleteUserAsync(user);

            if(!deletedUser)
                return BadRequest();

            return NoContent();
        }
    }
}