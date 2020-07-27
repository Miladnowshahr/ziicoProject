using ECommerce.Infra.Web;
using ECommerce.Models.Model.Products;
using ECommerce.Models.Model.Products.Brands;
using ECommerce.Models.Model.Products.Groups;
using ECommerce.Models.Model.Products.States;
using ECommerce.Models.Model.Users;
using ECommerce.Models.Services.Repository.EF.BrandRepo;
using ECommerce.Models.Services.Repository.EF.GroupRepo;
using ECommerce.Models.Services.Repository.EF.ProductRepo;
using ECommerce.Models.ViewModels.ProductVM;
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
using System.Threading.Tasks;

namespace ECommerce.Presentation.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : BaseController
    {
        private UserManager<Operator> _userManager;
        private IBrandRepository _brandRepo;
        private IGroupRepository _groupRepo;
        private IProductRepository _productRepo;
        private IHostingEnvironment _env;

        public ProductController(UserManager<Operator> userManager, IBrandRepository brandRepo, IGroupRepository groupRepo, IProductRepository productRepo, IHostingEnvironment env) : base(userManager)
        {
            _userManager = userManager;
            _brandRepo = brandRepo;
            _groupRepo = groupRepo;
            _productRepo = productRepo;
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List(int? id, string primTitle, string secTitle)
         {
            var user = Operator;

            var productList = await _productRepo.GetProductsAsync(null, null, null);

            var productvm = new List<ProductViewModel>();
            PersianCalendar p = new PersianCalendar();
               foreach (var item in productList)
            {
                productvm.Add(new ProductViewModel
                {
                    PrimaryTitle=item.PrimaryTitle,
                    SecondaryTile=item.SecondaryTile,
                    Id=item.Id,
                    Creator=$"{item.Creator.FirstName} {item.Creator.LastName}",
                    Brand=item.Brand,
                    Group=item.Group,
                    Description=item.Description,
                    CreateDate= p.PersianDate(item.CreateDate),
                    State=item.State.GetAttribute<DisplayAttribute>().Description,
                    LastModifier= item.LastModifier?.FirstName + " " + item.LastModifier?.LastName,
                    LastModifyDate =item.LastModifyDate.HasValue? p.PersianDate(item.LastModifyDate.Value):null
                });
            }

            return View(productvm);
        }

        public async Task<IActionResult> AddProduct()
        {
            var addProdcutVM = new EditProductShowViewModel();

            var brands = await _brandRepo.GetBrandsAsync(null, null, null);
            var selectBrands = brands.Select(b => new { b.Title, b.Id });


            var groups = await _groupRepo.GetGroupsAsync(null, null, null, null);
            var selectGroups = groups.Select(g => new { g.Title, g.Id });
            
            addProdcutVM.BrandGroupViewModel = new BrandGroupViewModel
            {
                Brand = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(selectBrands, "Id", "Title"),
                Group = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(selectGroups, "Id", "Title")

            };

           
            return View(addProdcutVM);
        }


        public async Task<IActionResult> EditProduct(int id)
        {
            ViewBag.Id = id;
            var editProductVM = new EditProductShowViewModel();

            var brands = await _brandRepo.GetBrandsAsync(null, null, null);
            var selectBrands = brands.Select(b => new { b.Title, b.Id });
            editProductVM.Product = await _productRepo.GetProductAsync(id);
            

            var groups = await _groupRepo.GetGroupsAsync(null, null,null, null);
            var selectGroups = groups.Select(g => new { g.Title, g.Id });

            editProductVM.BrandGroupViewModel = new BrandGroupViewModel
            {
                Brand = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(brands, "Id", "Title", editProductVM.Product.BrandId),
                Group = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(groups, "Id", "Title", editProductVM.Product.GroupId)
            };
            return View("AddProduct",editProductVM);
        }

        public async Task<IActionResult> Save(int? id,string primTitle, string secTitle, string description, int brand, int group,State state, IFormFile photo)
        {
            //Add 
            if (id==null)
            {
                var product = new Product
                {
                    BrandId = brand,
                    GroupId = group,
                    PrimaryTitle = primTitle,
                    SecondaryTile = secTitle,
                    Description = description,
                    State = state,
                    Creator = Operator,
                    CreateDate = DateTime.UtcNow

                };
                
                await _productRepo.AddAsync(product);
                await _productRepo.SaveAsync();

                var productId = product.Id;
                if (photo!=null)
                {
                    var ext = Path.GetExtension(photo.FileName);
                    var path = Path.Combine(_env.WebRootPath + "\\Images\\Products", productId + ext);
                    using (var filestream = new FileStream(path, FileMode.Create))
                    {
                        await photo.CopyToAsync(filestream);
                    }
                }
                return RedirectToAction("List");

            }
            //edit
            else
            {
                var model = await _productRepo.GetProductAsync(id.Value);
                model.BrandId = brand;
                model.Description = description;
                model.GroupId = group;
                model.LastModifier = Operator;
                model.LastModifyDate = DateTime.UtcNow;
                model.PrimaryTitle = primTitle;
                model.SecondaryTile = secTitle;
                model.State = state;

                 _productRepo.Update(model);
                await _productRepo.SaveAsync();

                return RedirectToAction("list");
            }
        }



        public IActionResult Specification(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public IActionResult SaveSpecification(int productId,int ids,string value)
        {
            return View("List");
        }

        /// <summary>
        /// list product items
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Items(int id,State? state,int[] tagValues)
        {
            ViewBag.ProductId = id;
            return View();
        }

        /// <summary>
        /// add items
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public IActionResult AddItem(int productId)
        {
            ViewBag.ProductId = productId;
            return View();
        }

        public IActionResult EditItem(int id)
        {
            ViewBag.Id = id;
            return View("AddItem");
        }
        public IActionResult SaveItem(int? id, int? productId, double? price, byte discount, int quantity, int[] tagValues, State state)
        {
            return RedirectToAction("items");
        }
    }
}