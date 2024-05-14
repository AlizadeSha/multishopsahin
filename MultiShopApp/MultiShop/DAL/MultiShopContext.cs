using Microsoft.EntityFrameworkCore;
using MultiShop.Models;

namespace MultiShop.DAL
{
    public class MultiShopContext : DbContext
    {
        public MultiShopContext(DbContextOptions options) : base(options)
        {
        }  
       public DbSet<Category> Categories { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=DESKTOP-R20TAJ1\\SQLEXPRESS;Database=NewMultiShop2;Trusted_Connection=true;TrustServerCertificate=True");
            base.OnConfiguring(options);
        }
    }
}
