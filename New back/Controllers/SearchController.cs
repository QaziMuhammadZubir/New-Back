


namespace New_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly productdb _context;
        public SearchController(productdb context)
        {
            _context = context;
        }
        [HttpGet("{search}")]
        public async Task<IList<Product>> Search(string title)
        {
            //IQueryable<Product> query = _context.Products;
            bool isnum = false;
            int i = 0;
            if (string.IsNullOrEmpty(title))
                return null;
            try
            {
                i = int.Parse(title);
                isnum = true;
            }
            catch (Exception)
            {
                isnum = false;
                //throw;
            }

            if (isnum && i < 3)
            {
                return await _context.Products.Where(e => (int)e.CategoryType == i).ToListAsync();
            }
            else
            {
                return await _context.Products.Where(e => e.title.ToLower().Contains(title.ToLower()) || e.description.ToLower().Contains(title.ToLower())).ToListAsync();

            }

        }

    }
}
