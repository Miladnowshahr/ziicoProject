using ECommerce.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.ShareModel
{
    public class BaseOperatorModel:BaseModel
    {
        public Operator Creator { get; set; }

        public DateTime CreateDate { get; set; }

        public Operator LastModifier { get; set; }

        public DateTime LastModifyDate { get; set; }
    }
}
