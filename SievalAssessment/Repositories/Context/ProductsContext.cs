using Microsoft.EntityFrameworkCore;
using SievalAssessment.Models;

namespace SievalAssessment.Repositories.Context
{
    public class ProductsContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ProductsDB");
        }
        public DbSet<Product> Products { get; set; }

    }
}
