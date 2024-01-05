using Microsoft.EntityFrameworkCore;

namespace ProductDetails.Models
{
    public class ProductinfoContext:DbContext
    {
        public ProductinfoContext(DbContextOptions <ProductinfoContext> options):base(options)
        {

        }
        public DbSet<Productsinfo> Productsinfos { get; set; }
    }
}
