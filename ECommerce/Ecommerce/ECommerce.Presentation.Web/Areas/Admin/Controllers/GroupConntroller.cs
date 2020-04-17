using ECommerce.Infra.Web;
using ECommerce.Models.Model.Products.Groups;
using ECommerce.Models.Model.Products.States;
using ECommerce.Models.Model.Users;
using ECommerce.Models.Services.Repository.EF.GroupRepo;
using ECommerce.Models.ViewModels.GroupVM;
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
using System.Text;
using System.Threading.Tasks;
using ECommerce.Infra.Web;
using System.Net;

namespace ECommerce.Presentation.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GroupController : BaseController
    {
        private UserManager<Operator> _userManager;
        private IGroupRepository _repo;
        private IHostingEnvironment _env;

        public GroupController(UserManager<Operator> userManager, IGroupRepository repo, IHostingEnvironment env) : base(userManager)
        {
            _userManager = userManager;
            _repo = repo;
            _env = env;
        }
        public IActionResult Index(int id)
        {
            return View();
        }

        public async Task<IActionResult> List(int? id, string title, string slug, State? state)
        {
            var model = await _repo.GetGroupsAsync(id, title, slug, state);
            var groupVM = new List<GroupViewModel>();
            if (model != null)
            {
                PersianCalendar p = new PersianCalendar();

                foreach (var item in model)
                {
                    groupVM.Add(new GroupViewModel
                    {
                        Title = item.Title,
                        State = item.State.GetAttribute<DisplayAttribute>().Description,
                        Slug = item.Slug,
                        Creator = $"{item.Creator.FirstName} {item.Creator.LastName}",
                        CreateDate = p.PersianDate(item.CreateDate),
                        LastModifier = $"{item.LastModifier?.FirstName} {item.LastModifier?.LastName}",
                        LastModifyDate = item.LastModifyDate.HasValue? p.PersianDate(item.LastModifyDate.Value):null,
                        Id=item.Id
                    });
                }
            }

            return View(groupVM);
        }

        public IActionResult AddGroup()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var group = await _repo.GetGroupAsync(id);
            if (group==null)
            {
                return NotFound();
            }

            PersianCalendar p = new PersianCalendar();

            var groupVM = new EditGroupViewModel
            {
                Slug=group.Slug,
                State=group.State.ToString(),
                Title=group.Title,
                Id=group.Id
            };


            ViewBag.Id = id;
            return View("AddGroup", groupVM);
        }

        public async Task<IActionResult> Save(int? id, string title, string slug, State state, IFormFile photo)
        {
            if (id==null)
            {
                //Todo:add
                var group = new Group
                {
                    CreateDate = DateTime.UtcNow,
                    Title = title,
                    Slug = slug.CheckStringIsNull()? null:slug,
                    Creator = Operator,
                    State = state,
                    
                };
                await _repo.AddAsync(group);
                await _repo.SaveAsync();
                if (photo != null)
                {

                    var groupId = group.Id;

                    var ext = Path.GetExtension(photo.FileName);
                    var path = Path.Combine(_env.WebRootPath + "\\Images\\Groups", groupId + ext);
                    using (var filestream = new FileStream(path, FileMode.Create))
                    {
                        await photo.CopyToAsync(filestream);
                    }
                }
                return RedirectToAction("list");
            }
            else
            {
                //Todo:edit
                var model = await _repo.GetGroupAsync(id.Value);
                model.Title = title;
                model.State = state;
                model.LastModifier = Operator;
                model.LastModifyDate = DateTime.UtcNow;

                await _repo.Update(model);
                await _repo.SaveAsync();
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
           
            await _repo.DeleteAsync(id);

            await _repo.SaveAsync();
            return RedirectToAction("List");
        }
    }
}
