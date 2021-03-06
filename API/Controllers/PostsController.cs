using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Dtos;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public PostsController(DataContext context, IUserRepository userRepository, IPostRepository postRepository, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPost()
        {
            return await _context.Posts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPostById(int id)
        {
            return await _context.Posts.FindAsync(id);
        }

        [HttpPost("add-post")]
        public async Task<ActionResult<PostDto>> CreatePost(PostCreateDto postCreateDto)
        {
            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());

            var post = new Post
            {
                Title = postCreateDto.Title,
                Content = postCreateDto.Content
            };

            user.Posts.Add(post);

            if (await _userRepository.SaveAllAsync()) return Ok();

            return BadRequest("Cannot post!");

        }

        [HttpDelete("delete-post/{postId}")]
        public async Task<ActionResult<AppUser>> DeletePost(int postId)
        {
            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());

            var post = user.Posts.FirstOrDefault(x => x.Id == postId);

            if (post == null) return NotFound();

            user.Posts.Remove(post);

            if(await _userRepository.SaveAllAsync()) return Ok();

            return BadRequest("Failed to delete the post");
        }      


    }
}