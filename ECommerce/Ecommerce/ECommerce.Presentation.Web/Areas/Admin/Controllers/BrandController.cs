using ECommerce.Infra.Web;
using ECommerce.Models.Model.Products.Brands;
using ECommerce.Models.Model.Products.States;
using ECommerce.Models.Model.Users;
using ECommerce.Models.Services.Repository.EF.BrandRepo;
using ECommerce.Models.ViewModels.BrandVM;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
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

        public async Task<IActionResult> List(string title,int? id, State? state)
        {
            var model = await _repo.GetBrandsAsync(title, id, state);

            var modelVm = new List<BrandViewModel>();

            PersianCalendar p = new PersianCalendar();
            if (model!=null)
            {
                foreach (var item in model)
                {
                    modelVm.Add(new BrandViewModel
                    {
                        Id = item.Id,
                        Title = item.Title,
                        Slug = item.Slug,
                        State = item.State.GetAttribute<DisplayAttribute>().Description,
                        Creator = item.Creator.FirstName + " " + item.Creator.LastName,
                        CreateDate = p.PersianDate(item.CreateDate),
                        LastModifyDate = item.LastModifyDate.HasValue ? p.PersianDate(item.LastModifyDate.Value) : null,
                        LastModifier = item.LastModifier?.FirstName + " " + item.LastModifier?.LastName
                    });
                }
            }
            

            return View(modelVm);
        }

        public IActionResult AddBrand()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var brand =await _repo.GetBrandAsync(id);
            if (brand==null)
            {
                return NotFound();
            }
            PersianCalendar p = new PersianCalendar();
            var model = new BrandViewModel
            {
                Id = brand.Id,
                Title = brand.Title,
                Slug = brand.Slug,
                State = brand.State.ToString(),
                Creator = brand.Creator.FirstName + " " + brand.Creator.LastName,
                CreateDate = p.PersianDate(brand.CreateDate),
                LastModifyDate = brand.LastModifyDate.HasValue ? p.PersianDate(brand.LastModifyDate.Value) : null,
                LastModifier = brand.LastModifier?.FirstName + " " + brand.LastModifier?.LastName
            };

            ViewBag.Id = id;
            return View("AddBrand",model);
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
                    Creator=Operator,
                    State=state,
                    
                };
                await _repo.AddAsync(brand);
                await _repo.SaveAsync();
                if (photo != null)
                {

                    var brandId = brand.Id;//for name =>1.jpg
                    var ext = Path.GetExtension(photo.FileName);
                    var path = Path.Combine(_env.WebRootPath + "\\Images\\Brands", brandId + ext);
                    using (var filestream = new FileStream(path, FileMode.Create))
                    {
                        await photo.CopyToAsync(filestream);
                    }
                }
                return RedirectToAction("list");
            }
            else
            {
                var brand =await  _repo.GetBrandAsync(id.Value);
                brand.State = state;
                brand.Slug = slug;
                brand.Title = title;
                brand.LastModifier = Operator;
                brand.LastModifyDate = DateTime.UtcNow;

                await _repo.Update(brand);
                await _repo.SaveAsync();
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var brand =await _repo.GetBrandAsync(id);
            await _repo.DeleteAsync(brand);
            await _repo.SaveAsync();
            return RedirectToAction("List");
        }

    }
}
