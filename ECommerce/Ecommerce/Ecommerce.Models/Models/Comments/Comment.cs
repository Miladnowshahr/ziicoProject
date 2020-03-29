using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Models.Model.ShareModel;

namespace ECommerce.Models.Model.Comments
{
    public class Comment:BaseModel
    {
        
        public string Text { get; set; }

        public DateTime CreateDateTime { get; set; }
    }
}
