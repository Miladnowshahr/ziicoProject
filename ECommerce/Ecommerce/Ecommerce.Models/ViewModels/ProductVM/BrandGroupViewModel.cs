using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.ViewModels.ProductVM
{
    public class BrandGroupViewModel
    {
        public SelectList Brand { get; set; }

        public SelectList Group { get; set; }
    }
}
