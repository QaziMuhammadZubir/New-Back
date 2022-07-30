

namespace New_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class btController : ControllerBase
    {
        private readonly productdb _context;
        private readonly IWebHostEnvironment env;

        public btController(productdb context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }



        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {

            return Ok(await _context.Products.ToListAsync());
        }
        //Search
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return BadRequest("Product not found");
            return Ok(product);
        }
        /*[HttpPost]
        public async Task<ActionResult<List<Product>>> Addproduct(Product Prod)
        {

            _context.Products.Add(Prod);
            await _context.SaveChangesAsync();
            return Ok(await _context.Products.ToListAsync());
        }*/
        /*[HttpPut]
        public async Task<ActionResult<List<Product>>> Updateproduct(Product upproduct)
        {

            var updproduct = await _context.Products.FindAsync(upproduct);
            if (updproduct == null)
                return BadRequest("Product not found");
            // updproduct.image = upproduct.image;
            updproduct.title = upproduct.title;
            updproduct.price = upproduct.price;
            updproduct.CategoryType = upproduct.CategoryType;
            updproduct.description = upproduct.description;

            await _context.SaveChangesAsync();
            return Ok(await _context.Products.ToListAsync());
        }*/

        //del
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Product>>> delproduct(int id)
        {

            var deldbproduct = await _context.Products.FindAsync(id);
            if (deldbproduct == null)
                return BadRequest("Product not found");
            _context.Products.Remove(deldbproduct);
            await _context.SaveChangesAsync();
            return Ok(await _context.Products.ToListAsync());
        }
        /* [HttpPost]
         [Route("upload")]
         public async Task<IActionResult> UploadImageProfile(Product product)
         {
             if (ModelState.IsValid)
             {
                 using (var memoryStream = new MemoryStream())
                 {
                     //await product.File.CopyToAsync(memoryStream);

                     // Upload the file if less than 2 MB
                     if (memoryStream.Length < 2097152)
                     {
                         //create a AppFile mdoel and save the image into database.
                         var file = new AppFile()
                         {
                             Name = product.title,
                             price = product.price,
                             CategoryType = product.CategoryType,
                             description = product.description,
                             image = memoryStream.ToArray()
                         };

                         _context.AppFiles.Add(file);
                         _context.SaveChanges();
                     }
                     else
                     {
                         ModelState.AddModelError("File", "The file is too large.");
                     }
                 }

                 var returndata = _context.AppFiles
                     .Where(c => c.Name == product.title)
                     .Where(c => c.price == product.price)
                     .Where(c => c.CategoryType == product.CategoryType)
                     .Where(c => c.description == product.description)
                     .Select(c => new ReturnData()
                     {
                         Name = c.Name,
                         price = c.price,
                         CategoryType = c.CategoryType,
                         description = c.description,
                         ImageBase64 = String.Format("data:image/png;base64,{0}", Convert.ToBase64String(c.image))
                     }).FirstOrDefault();
                 return Ok(returndata);
             }
             return Ok("Invalid");
         }*/
        //Add
        [HttpPost]
        [Route("uploadProfile")]
        public async Task<IActionResult> UploadProfile(Product product)
        {
            if (ModelState.IsValid)
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                var p = await _context.Products.FirstOrDefaultAsync(c =>
               c.title.Equals(product.title) &&
               c.price.Equals(product.price) &&
               c.CategoryType.Equals(product.CategoryType) &&
               c.description.Equals(product.description)
                );
                p.ImageNames = $"{p.p_Id}1.jpg";
                //_context.Products.Add(p);
                var path = env.WebRootPath + "/Images";

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                //string base64str = product.ImageBase64.Substring(product.ImageBase64.IndexOf("base64,") + ("base64,").Length);
                //Console.WriteLine(base64str);
                await System.IO.File.WriteAllBytesAsync(Path.Combine(path, p.ImageNames), Convert.FromBase64String(product.ImageBase64));
                _context.Products.Update(p);
                await _context.SaveChangesAsync();

                return Ok(p.ImageNames);
            }
            return Ok("Invalid");
        }

    }
}

