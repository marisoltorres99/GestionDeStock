using GestionDeStock.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDeStock.DataContext
{
    public class StockContext : DbContext
    {
        public StockContext(DbContextOptions<StockContext> options) : base(options)
        {
        }

        public DbSet<Product> products { get; set; }
        public DbSet<StockMovement> stockMovements { get; set; }
    }
}
