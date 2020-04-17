using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.Model.Products.States
{
    public enum State : byte
    {
        [Display(Name ="فعال",Description = "فعال")]
        Enable=1,
        [Display(Name ="غیرفعال", Description = "غیرفعال")]
        Disable=2
    }
}
