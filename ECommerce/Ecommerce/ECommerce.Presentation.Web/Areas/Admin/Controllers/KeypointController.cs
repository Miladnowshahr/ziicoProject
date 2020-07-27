using ECommerce.Infra.Web;
using ECommerce.Models.Model.KeyPoints;
using ECommerce.Models.Model.Products;
using ECommerce.Models.Model.Products.States;
using ECommerce.Models.Model.Users;
using ECommerce.Models.Services.Repository.EF.KeypointRepo;
using ECommerce.Models.ViewModels.KeyPointVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Presentation.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KeypointController:BaseController
    {

        private IKeyPointRepository _keypointRepo;
        private UserManager<Operator> _userManager;
        
        public KeypointController(UserManager<Operator> userManager,IKeyPointRepository keypointRepo):base(userManager)
        {
            _userManager = userManager;
            _keypointRepo = keypointRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List(int productId, KeyPointType keyPoint) 
        {
            ViewBag.ProductId = productId;
            ViewBag.Keypoint = keyPoint;

            var model = await _keypointRepo.KeyPointsAsync(null,productId, null,keyPoint);

            var keyPointList = new List<KeyPointViewViewModel>();
            PersianCalendar persian = new PersianCalendar();

            foreach (var item in model)
            {
                keyPointList.Add(new KeyPointViewViewModel
                {
                    Creator =$"{item.Creator.FirstName} {item.Creator.LastName}",
                    CreatorDateTime=persian.PersianDate(item.CreateDate),
                    Title=item.Title,
                    Id=item.Id,
                    KeyPoint=item.Type,
                    LastModifier=item.LastModifier?.FirstName + "" + item.LastModifier?.LastName,
                    LastModifierDateTime=item.LastModifyDate.HasValue? persian.PersianDate(item.LastModifyDate.Value) :null,
                    Product=item.Product,
                    ProductId=item.ProductId,
                    State=item.State.GetAttribute<DisplayAttribute>().Description
                });
            }
            return View(keyPointList);
        }

        public IActionResult Add(int productId,KeyPointType type)
        {
            ViewBag.ProductId = productId;
            ViewBag.Type = type;
         
            
            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Id = id;
            var model = await _keypointRepo.KeyPointAsync(id);

            var keyPointEditModel = new KeyPointEditViewModel
            {
                Id=model.Id,
                State=model.State.ToString(),
                Title=model.Title
            };
            ViewBag.ProductId = model.ProductId;
            ViewBag.Type = model.Type;

            return View("add",keyPointEditModel);
        }
        public async Task<IActionResult> Save(int? id,int productId,KeyPointType type ,string title,State state )
        {
            if (id==null)
            {
                // add keypoint 
                var keypoint = new KeyPoint
                {

                    Type = type,
                    Title = title,
                    CreateDate = DateTime.UtcNow,
                    Creator = Operator,
                    ProductId=productId,
                    State=state
                };

                await _keypointRepo.AddAsync(keypoint);
                await _keypointRepo.SaveAsync();
                return RedirectToAction("list",new {productId=productId, keyPoint=type }); 
            }

            else
            {
                //edit keypoint
                var model = await _keypointRepo.KeyPointAsync(id.Value);
                model.LastModifier = Operator;
                model.LastModifyDate = DateTime.UtcNow;
                model.Title = title;
                model.State = state;

                 _keypointRepo.Update(model);
                await _keypointRepo.SaveAsync();
                return RedirectToAction("list", new { productId = productId, keyPoint = type });
            }
            return RedirectToAction("List");
        }
        public IActionResult Delete(int id,int productId,KeyPointType type)
        {
            _keypointRepo.RemoveAsync(id);
            return RedirectToAction("list",new {productId=productId,type=type });
         }

    }
}
