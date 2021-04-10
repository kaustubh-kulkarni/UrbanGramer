using API.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UsersController : ControllerBase
    {
        public UsersController(DataContext context)
        {
        }
    }
}