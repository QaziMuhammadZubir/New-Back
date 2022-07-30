

namespace New_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckController : ControllerBase
    {
        private readonly productdb _context;
        public CheckController(productdb context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Checkout>>> Get(int Uid)
        {

            return await _context.checkouts.Where(o => o.Uid == Uid).ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<List<Checkout>>> AddCart(Checkout check)
        {
            _context.checkouts.Add(check);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
