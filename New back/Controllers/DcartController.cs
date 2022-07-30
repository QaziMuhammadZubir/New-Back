

namespace New_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DcartController : ControllerBase
    {
        private readonly productdb _context;
        public DcartController(productdb context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<DemyCartClass>>> Get(int Uid)
        {

            return await _context.demyCartClasses.Where(o => o.Uid == Uid).ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<DemyCartClass>>> Price(int id)
        {

            var TotalP = await _context.demyCartClasses.Where(o => o.Uid == id).SumAsync(b => b.Price * b.Quantity);
            return Ok(TotalP);
        }
        [HttpPost]
        public async Task<ActionResult<List<DemyCartClass>>> AddCart(DemyCartClass con)
        {
            _context.demyCartClasses.Add(con);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<DemyCartClass>>> delCart(int id)
        {

            var deldbCart = await _context.demyCartClasses.FindAsync(id);
            if (deldbCart == null)
                return BadRequest("Product not found");
            _context.demyCartClasses.Remove(deldbCart);
            await _context.SaveChangesAsync();
            return Ok(await _context.demyCartClasses.ToListAsync());
        }

        [HttpPost("{Uid}")]
        public async Task<ActionResult<List<DemyCartClass>>> Remall(int Uid)
        {
            var del = _context.demyCartClasses.Where(x => x.Uid == Uid).ToList();
            if (del == null)
                return BadRequest("Product not found");
            /* foreach (var item in deldbCart)
             {
                 _context.Carts.Remove(item);
             }*/


            _context.demyCartClasses.RemoveRange(del);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
