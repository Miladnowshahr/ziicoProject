using ECommerce.Models.Model.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Presentation.Web.Areas.Admin.Controllers
{
    public class BaseController:Controller
    {
        private UserManager<Operator> _userManager;
        //private SignInManager<Operator> _signInManager;
        private Operator _operator;
        public BaseController(UserManager<Operator> userManager)
        {
            _userManager = userManager;
        }

      //  public List<BreadCrumb> BreadCrumbs { get; set; }

        
        public Operator Operator
        {
            get
            {
                return GetOperatorAsync().GetAwaiter().GetResult();
            }
        }

        private async Task<Operator> GetOperatorAsync()
        {
            _operator = await _userManager.FindByNameAsync("digiadmin");

            if (await _userManager.CheckPasswordAsync(_operator,"123456"))
            {
                return _operator;
            }
            return null;
        }
    }
}
