using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Dtos;
using API.Entities;
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
        private readonly DataContext _context;
        public PostsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async  Task<ActionResult<IEnumerable<Post>>> GetPost()
        {
            return await _context.Posts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPostById(int id)
        {
            return await _context.Posts.FindAsync(id);
        }

        [HttpPost("create")]
        public async Task<ActionResult<PostDto>> AddPost(PostCreateDto postCreateDto)
        {
            if (await PostExists(postCreateDto.Id)) return BadRequest("Post already exists!");
           var post = new Post
           {
               Title = postCreateDto.Title,
               Content = postCreateDto.Content
           };

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return new PostDto{
                Title = post.Title,
                Content = post.Content
            };

        }

        // Method to check whether the post exists or not
        private async Task<bool> PostExists(int id)
        {
            return await _context.Posts.AnyAsync(x => x.Id == id);
        }
    }
}