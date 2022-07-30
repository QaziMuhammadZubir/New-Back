

namespace New_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly productdb _context;
        public CartController(productdb context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Cart>>> Get(int Uid)
        {

            return await _context.Carts.Where(o=> o.Uid == Uid).ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Cart>>> Price(int id)
        {

            var TotalP = await _context.Carts.Where(o => o.Uid == id).SumAsync(b => b.Price*b.Quantity);
            return Ok(TotalP);
        }
        [HttpPost]
        public async Task<ActionResult<List<Cart>>> AddCart(Cart con)
        {
            _context.Carts.Add(con);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Cart>>> delCart(int id)
        {

            var deldbCart = await _context.Carts.FindAsync(id);
            if (deldbCart == null)
                return BadRequest("Product not found");
            _context.Carts.Remove(deldbCart);
            await _context.SaveChangesAsync();
            return Ok(await _context.Carts.ToListAsync());
        }
        


    }
}
