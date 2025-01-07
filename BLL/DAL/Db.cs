using Microsoft.EntityFrameworkCore;


namespace BLL.DAL
{
    public class Db : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public Db(DbContextOptions options) : base(options) 
        {
        
        }

    }
}
