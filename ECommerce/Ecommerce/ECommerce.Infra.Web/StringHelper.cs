using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infra.Web
{
    public static class StringHelper
    {
        public static bool CheckStringIsNull(this string text)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
            {
                return true;
            }
            return false; 
        }
    }
}
