using ECommerce.Models.Model.Products.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.Services.Repository.EF.BrandRepo
{
    public interface IBrandRepository
    {
        Task AddAsync(Brand brand);
        Task UpdateAsync(Brand brand);
        Task DeleteAsync(Brand brand);
        Task<IEnumerable<Brand>> GetBrandsAsync();
        Task<Brand> FindAsync(int id);

        Task SaveAsync();
    }
}
