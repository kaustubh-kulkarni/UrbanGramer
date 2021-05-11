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
using AutoMapper;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public UsersController(DataContext context, IUserRepository userRepository, IPostRepository postRepository, IMapper mapper)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _userRepository = userRepository;
            _context = context;
        }


        [HttpGet]
        public async  Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
        [HttpGet("{username}", Name = "GetUser")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            return await _userRepository.GetMemberAsync(username);
        }

        [HttpPost("add-post")]
        public async Task<ActionResult<PostDto>> CreatePost(PostCreateDto postCreateDto)
        {
    
            var post = new Post
            {
                Title = postCreateDto.Title,
                Content = postCreateDto.Content,
            };

            _postRepository.AddPost(post);
            await _postRepository.SaveAllAsync();

            return new PostDto
            {
                Title = post.Title,
                Content = post.Content
            };
        }      

    }
}