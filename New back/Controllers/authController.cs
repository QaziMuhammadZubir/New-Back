
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace New_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class authController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly productdb _context;
        public authController(IConfiguration configuration, productdb context, IUserService userService)
        {
            _configuration = configuration;
            _context = context;
            _userService = userService;
        }

        /*[HttpGet]
        public ActionResult<string> GetMe()
        {
            var userName = _userService.GetMyName();
            return Ok(userName);

            var userName = User?.Identity?.Name;
            var userName2 = User.FindFirstValue(ClaimTypes.Email);
            var role = User.FindFirstValue(ClaimTypes.Role);
            return Ok(new { userName, userName2, role });
        }*/

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(User request)
        {

            if (await _context.users.AnyAsync(x => x.email == request.email))
            {
                return BadRequest("Email Already exist");
            }

            _context.users.Add(request);
            await _context.SaveChangesAsync();


            return Ok(await _context.users.ToListAsync());
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(login request)
        {
            var user = _context.users.FirstOrDefault(x => x.email == request.email && x.password == request.password);
            if (user == null) return null;

            var token = CreateToken((User)user);
            return Ok(token);
        }
       /* [HttpPost("logout")]
        public async Task<ActionResult> logout()
        {
            HttpContext.Session.SetString("JWToken", "");
            return Ok();

        }*/

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.email),
                new Claim(ClaimTypes.Hash, user.password),
                new Claim(ClaimTypes.Sid,Convert.ToString(user.U_Id)),
                new Claim(ClaimTypes.Name, user.name),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> Get(int Uid)
        {

            return await _context.users.Where(o => o.U_Id == Uid).ToListAsync();
        }
    }
}
