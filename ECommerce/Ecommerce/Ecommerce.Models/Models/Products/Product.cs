using ECommerce.Models.Model.Products.Brands;
using ECommerce.Models.Model.Products.Groups;
using ECommerce.Models.Model.Products.States;
using ECommerce.Models.Model.ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECommerce.Models.Model.Products
{
    public class Product:BaseOperatorModel
    {
        public string PrimaryTitle { get; set; }
        
        public string SecondaryTile { get; set; }

        public string Description { get; set; }
        public Brand Brand { get; set; }

        public Group Group { get; set; }

        public State State { get; set; }

    }
}
