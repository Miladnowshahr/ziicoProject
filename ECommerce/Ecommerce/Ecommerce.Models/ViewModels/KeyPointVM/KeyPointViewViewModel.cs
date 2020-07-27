using ECommerce.Models.Model.KeyPoints;
using ECommerce.Models.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.ViewModels.KeyPointVM
{
    public class KeyPointViewViewModel:KeyPointBaseViewModel
    {

        public string Creator { get; set; }
        
        public string CreatorDateTime { get; set; }

        public string LastModifier { get; set; }

        public string LastModifierDateTime { get; set; }

        public KeyPointType KeyPoint { get; set; }
        public Product Product { get; set; }

        public int ProductId { get; set; }
        
        public string State { get;set; }

    }
}
