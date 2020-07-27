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
        private AppDbContext _db;

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
            return await _db.Products.Include(x => x.Creator).Include(x => x.LastModifier).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(int? id,string primTitle,string secTitle)
        {
            var query= await _db.Products.Include(b=>b.Brand).Include(o=>o.Creator).Include(g=>g.Group).Include(o=>o.LastModifier).ToListAsync();

            var product = query.Where(p => (p.Id == id || id == null) && (p.PrimaryTitle == primTitle || string.IsNullOrEmpty(primTitle)) && (p.SecondaryTile==secTitle || string.IsNullOrEmpty(secTitle))).ToList();


            return product;
        
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
