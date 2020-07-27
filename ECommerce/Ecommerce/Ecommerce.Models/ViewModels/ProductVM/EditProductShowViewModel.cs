using ECommerce.Models.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.ViewModels.ProductVM
{
    public class EditProductShowViewModel
    {
       public BrandGroupViewModel BrandGroupViewModel { get; set; }

        public Product Product { get; set; }
    }
}
