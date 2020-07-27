using ECommerce.Infra.Web;
using ECommerce.Models.Model.Products.States;
using ECommerce.Models.Model.Users;
using ECommerce.Models.Models.Tags;
using ECommerce.Models.Services.Repository.EF.TagRepo;
using ECommerce.Models.ViewModels.TagVM;
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
    public class TagController:BaseController
    {
        private UserManager<Operator> _userManager;
        private ITagRepository _tagRepo;

        public TagController(UserManager<Operator> userManager, ITagRepository tagRepo):base(userManager)
        {
            _tagRepo = tagRepo;
            _userManager = userManager;
        }

        public async Task<IActionResult> List(int? id,string title,State? state)
        {
            var tagShowModel = new List<TagShowViewModel>();

            var model = await _tagRepo.GetTagsAsync(id, title);
            var persian = new PersianCalendar();


            foreach (var item in model)
            {
                tagShowModel.Add(new TagShowViewModel
                {
                    Title=item.Title,
                    State=item.State.GetAttribute<DisplayAttribute>().Description,
                    Creator=$"{item.Creator.FirstName} {item.Creator.LastName}",
                    CreateDate=persian.PersianDate(item.CreateDate),
                    LastModifier=$"{item.LastModifier?.FirstName} {item.LastModifier?.LastName}",
                    LastModifyDate=item.LastModifyDate.HasValue? persian.PersianDate(item.LastModifyDate.Value):null,
                    Id=item.Id
                });
            }

            return View(tagShowModel);
        }

        public async Task<IActionResult> Add(int id)
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Id = id;
            var model = await _tagRepo.GetTagAsync(id);
            TagEditViewModel tagEditModel = new TagEditViewModel()
            {
                Id=model.Id,
                Title=model.Title,
                State=model.State
            };
            return View("Add",tagEditModel);
        }

        public async Task<IActionResult> Save(int? id, string title,State state)
        {
            if (id==null)
            {
                //Todo: Add
                await _tagRepo.AddAsync(new Tag
                {
                    Creator = Operator,
                    CreateDate = DateTime.UtcNow,
                    Title=title,
                    State=state
                });
                await _tagRepo.SaveAsync();
                return RedirectToAction("list");
                
            }
            else
            {
                //Tdod: Edit
                var editModel = await _tagRepo.GetTagAsync(id.Value);

                editModel.Title = title;
                editModel.State = state;
                editModel.LastModifier = Operator;
                editModel.LastModifyDate = DateTime.UtcNow;

                _tagRepo.Update(editModel);
                await _tagRepo.SaveAsync();

                return RedirectToAction("List");

            }


            return RedirectToAction("list");
        }

        public IActionResult Delete(int id)
        {
            var model = _tagRepo.Remove(id);
            return RedirectToAction();
        }
        /// <summary>
        /// لیست مقادیر یک بر چسب
        /// </summary>
        /// <returns></returns>
        public IActionResult Values(int id,string title,State? state)
        {
            ViewBag.Id = id;
            return View();
        }

        /// <summary>
        /// add value in a tag
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public IActionResult AddValue(int tagId)
        {
            ViewBag.TagId = tagId;
            return View();
        }
        

        /// <summary>
        /// edit tag value with a id of value
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult EditValue(int id )
        {
            ViewBag.Id = id;
            return View("AddValue");
        }

        [HttpPost]
        public IActionResult SaveValue(int? id,int? tagId, string title, State state)
        {
            return RedirectToAction("values");
        }

        public IActionResult DeleteValue(int id)
        {
            return RedirectToAction("Values");
        }
    }
}
