using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Models.ShareModel;
using ECommerce.Models.Users;

namespace ECommerce.Models.Products.Groups
{
    public class Group:BaseOperatorModel
    {
        
        public string Title { get; set; }

        public string Slug { get; set; }

    }
}
