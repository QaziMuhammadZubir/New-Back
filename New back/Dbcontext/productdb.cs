using Microsoft.EntityFrameworkCore;
using New_back.Model;

namespace New_back.Dbcontext
{
    public class productdb : DbContext
    {
        public productdb(DbContextOptions<productdb> optons) : base(optons)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Orderlist> orderlists { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Checkout> checkouts { get; set; }
        public DbSet<DemyCartClass> demyCartClasses { get; set; }

    }
}
