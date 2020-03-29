using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.DataAccess.Context;
using ECommerce.Models.Model.Products.Brands;

namespace ECommerce.Models.Services.Repository.EF.BrandRepo
{
    public class BrandRepository:IBrandRepository
    {
        private readonly AppDbContext _db;

        public BrandRepository(AppDbContext db)
        {
            _db = db;
        }

        public Task AddAsync(Brand brand)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Brand brand)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Brand brand)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Brand>> GetBrandsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Brand> FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
