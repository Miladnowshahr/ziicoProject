using ECommerce.Models.Model.Products.States;
using ECommerce.Models.Model.ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.Models.Tags
{
    public class Tag:BaseOperatorModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<TagValue> TagValues { get; set; }
        public State State { get; set; }
    }
}
