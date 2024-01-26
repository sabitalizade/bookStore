

using AutoMapper;
using Bookshop.Interfaces;
using BookStore.Dto;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookshop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetUsers()
        {
            var users = _mapper.Map<List<UserDto>>(_userRepository.GetCurrent(1));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(users);
        }
        [HttpPost("register")]
        [ProducesResponseType(201, Type = typeof(UserDto))]
        [ProducesResponseType(400)]
        public IActionResult Register([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = _mapper.Map<Users>(userDto);
            if (!_userRepository.Register(user))
            {
                ModelState.AddModelError("", $"Something went wrong saving the user " +
                                                $"{user.FirstName} {user.LastName}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetUser", new { userId = user.Id }, user);
        }
    }
}