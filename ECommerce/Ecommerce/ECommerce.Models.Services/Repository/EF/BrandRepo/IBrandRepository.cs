using ECommerce.Models.Model.Products.Brands;
using ECommerce.Models.Model.Products.States;
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
        void Update(Brand brand);
        Task DeleteAsync(Brand brand);
        Task<IEnumerable<Brand>> GetBrandsAsync(string title,int? id,State? state);
        Task<Brand> GetBrandAsync(int id);
        Task SaveAsync();
    }
}
