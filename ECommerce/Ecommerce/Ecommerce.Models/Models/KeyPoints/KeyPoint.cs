using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Models.Model.Products;
using ECommerce.Models.Model.Products.States;
using ECommerce.Models.Model.ShareModel;

namespace ECommerce.Models.Model.KeyPoints
{
    public class KeyPoint:BaseOperatorModel
    {

        public string Title { get; set; }
        public KeyPointType Type { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public State State { get; set; }
    }
}
