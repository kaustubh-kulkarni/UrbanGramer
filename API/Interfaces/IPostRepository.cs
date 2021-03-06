using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IPostRepository
    {
        void AddPost(Post post);
        void DeletePost(Post post);
        Task<Post> GetPosts(int id);
        Task<bool> SaveAllAsync();
    }
}