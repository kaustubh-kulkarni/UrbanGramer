using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Dtos;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using API.Extensions;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly DataContext _context;
        public UsersController(DataContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }


        [HttpGet]
        public async  Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
        [HttpGet("{username}")]
        public async Task<ActionResult<AppUser>> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.Include(p => p.Posts).SingleOrDefaultAsync(x => x.Username == username);
        }

        [HttpPost("add-post")]
        public async Task<ActionResult<UserDto>> AddPost(PostDto postDto)
        {
            var username = await _userRepository.GetUserByUsernameAsync(User.GetUsername());

            var post = new Post
            {
                Id = postDto.Id,
                Title = postDto.Title,
                Content = postDto.Content
            };

            username.Posts.Add(post);

            if (await _userRepository.SaveAllAsync())
            {
                return Ok(postDto);
            }
  
            return Ok(200);

            
        }


    }
}