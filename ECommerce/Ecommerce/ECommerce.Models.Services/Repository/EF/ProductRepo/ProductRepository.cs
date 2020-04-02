using ECommerce.DataAccess.Context;
using ECommerce.Models.Model.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.Services.Repository.EF.ProductRepo
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _db;

        public ProductRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Product product)
        {
            await _db.Products.AddAsync(product);
        }

        public async Task DeleteAsync(Product product)
        {
            var model = await GetProductAsync(product.Id);
            _db.Products.Remove(model);
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _db.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _db.Products.Include(b=>b.Brand).ThenInclude(o=>o.Creator).Include(g=>g.Group).ThenInclude(o=>o.Creator).ToListAsync();
        }

        public void Update(Product product)
        {
            _db.Products.Update(product);
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

    }
}
