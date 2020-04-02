using ECommerce.Models.Model.Products.Brands;
using ECommerce.Models.Model.Products.States;
using ECommerce.Models.Model.Users;
using ECommerce.Models.Services.Repository.EF.BrandRepo;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Presentation.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController:BaseController
    {
        private UserManager<Operator> _userManager;
        private IHostingEnvironment _env;
        private IBrandRepository _repo;

        
        public BrandController(UserManager<Operator> userManager, IHostingEnvironment env, IBrandRepository repo) : base(userManager)
        {
            _userManager = userManager;
            _env = env;
            _repo = repo;
        }

        public IActionResult Index(int id)
        {
            return View();
        }

        public IActionResult List(string title,int? id, State? state)
        {
            var model = _repo.GetBrandsAsync(title, id, state);
            return View(model);
        }

        public IActionResult AddBrand()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Id = id;
            return View("List");
        }

        public async Task<IActionResult> Save(int? id, string title, string slug, State state, IFormFile photo)
        {
            if (id==null)
            {
                //To do: Add Brand
                var brand = new Brand
                {
                    CreateDate=DateTime.UtcNow,
                    Title=title,
                    Slug=slug,
                    Creator=new Operator
                    {
                        Id = Operator.Id
                    },
                    State=state,
                    
                };
                await _repo.AddAsync(brand);
                await _repo.SaveAsync();
                var brandId = brand.Id;

                var ext = Path.GetExtension(photo.FileName);
                var path = Path.Combine(_env.WebRootPath + "\\Images\\Brands", brandId + ext);
                using (var filestream=new FileStream(path,FileMode.Create))
                {
                    await photo.CopyToAsync(filestream);
                }
                return View("List");

            }
            else
            {

            }
            return View();
        }
    }
}
