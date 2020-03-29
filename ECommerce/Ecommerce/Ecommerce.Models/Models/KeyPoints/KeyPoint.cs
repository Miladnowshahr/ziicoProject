using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Models.Model.ShareModel;

namespace ECommerce.Models.Model.KeyPoints
{
    public class KeyPoint:BaseOperatorModel
    {

        public string Title { get; set; }
        public KeyPointType Type { get; set; }
    }
}
