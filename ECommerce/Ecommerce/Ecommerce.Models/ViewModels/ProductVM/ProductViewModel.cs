using ECommerce.Models.Model.Products.Brands;
using ECommerce.Models.Model.Products.Groups;
using ECommerce.Models.Model.Products.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.ViewModels.ProductVM
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        
        
        public string PrimaryTitle { get; set; }

        public string SecondaryTile { get; set; }

        public string Description { get; set; }
        public virtual Brand Brand { get; set; }

        public virtual Group Group { get; set; }

        public string State { get; set; }

        public string Creator { get; set; }

        public string CreateDate { get; set; }

        public string LastModifier { get; set; }

        public string LastModifyDate { get; set; }
    }
}
