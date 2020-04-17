using ECommerce.Models.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.Services.Repository.EF.ProductRepo
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);

        void Update(Product product);

        Task DeleteAsync(Product product);

        Task<Product> GetProductAsync(int id);

        Task<IEnumerable<Product>> GetProductsAsync(int? id, string primTitle, string secTitle);

        Task SaveAsync();
    }
}
