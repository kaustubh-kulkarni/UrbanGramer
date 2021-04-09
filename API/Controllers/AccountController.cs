namespace API.Controllers
{
    public class AccountController: ControllerBase
    {
        private readonly DataContext _context;
        public AccountController(DataContext dataContext){
            _context = context;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var user = new User
            {
                Username = registerDto.Username.ToLower(),
                Password = registerDto.Password
            };

            _context.User.Add(user);
        }
        
    }
}