using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Models.Model.Products.States;
using ECommerce.Models.Model.ShareModel;


namespace ECommerce.Models.Model.Products.Brands
{
    public class Brand:BaseOperatorModel
    {

        public string Title { get; set; }

        public string Slug { get; set; }

        public State State { get; set; }

    }
}
