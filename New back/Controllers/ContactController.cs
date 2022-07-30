


namespace New_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly productdb _context;
        public ContactController(productdb context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Contact>>> Get()
        {

            return Ok(await _context.Contacts.ToListAsync());
        }
        //Search
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> Get(int id)
        {
            var Contact = await _context.Contacts.FindAsync(id);
            if (Contact == null)
                return BadRequest("Contact not found");
            return Ok(Contact);
        }
        //add
        [HttpPost]
        public async Task<ActionResult<List<Contact>>> AddContact(Contact con)
        {

            _context.Contacts.Add(con);
            await _context.SaveChangesAsync();
            return Ok(await _context.Contacts.ToListAsync());
        }


        //del
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Contact>>> delContact(int id)
        {

            var deldbContact = await _context.Contacts.FindAsync(id);
            if (deldbContact == null)
                return BadRequest("Contact not found");
            _context.Contacts.Remove(deldbContact);
            await _context.SaveChangesAsync();
            return Ok(await _context.Contacts.ToListAsync());
        }
    }
}
