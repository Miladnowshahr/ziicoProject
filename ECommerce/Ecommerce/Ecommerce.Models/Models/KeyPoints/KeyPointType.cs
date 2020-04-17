using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.Model.KeyPoints
{
    public enum KeyPointType:byte
    {
        [Display(Name="منفی")]
        Positive=1,
        [Display(Name ="مثبت")]
        Negative = 2
    }
}
