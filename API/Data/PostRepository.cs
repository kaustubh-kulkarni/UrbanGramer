using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;

namespace API.Data
{
    public class PostRepository : IPostRepository
    {
        private readonly DataContext _context;
        public PostRepository(DataContext context)
        {
            _context = context;
        }

        public void AddPost(Post post)
        {
            _context.Posts.Add(post);
        }

        public void DeletePost(Post post)
        {
            _context.Posts.Remove(post);
        }

        public async Task<Post> GetPost(int id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}