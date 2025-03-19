using GestionDeStock.DataContext;
using GestionDeStock.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDeStock.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private StockContext _stockContext;

        public ProductRepository(StockContext context)
        {
            _stockContext = context;
        }

        public async Task<IEnumerable<Product>> Get() =>
            await _stockContext.products.ToListAsync();

        public async Task<Product> GetById(int id) =>
           await _stockContext.products.FindAsync(id);

        public async Task Add(Product beer) =>
            await _stockContext.products.AddAsync(beer);

        public async Task Save() =>
            await _stockContext.SaveChangesAsync();
    }
}
