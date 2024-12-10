using Microsoft.EntityFrameworkCore;


namespace BLL.DAL
{
    public class Db : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Products> Products { get; set; }

        public Db(DbContextOptions options) : base(options) 
        {
        
        }

    }
}
