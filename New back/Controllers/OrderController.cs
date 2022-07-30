

namespace New_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly productdb _context;
        public OrderController(productdb context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Orderlist>>> Get()
        {

            return Ok(await _context.orderlists.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<Orderlist>>> AddContact(Orderlist od)
        {
            _context.orderlists.Add(od);
            await _context.SaveChangesAsync();
            return Ok(await _context.orderlists.ToListAsync());
        }
        /*[HttpGet("car")]
        public async Task<ActionResult<List<Orderlist>>> Crt(int aid)
        {

            return await _context.Carts.Where(o => o.Uid == aid).ToListAsync();
        }
        */
    }
}
