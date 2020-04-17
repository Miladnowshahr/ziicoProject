using ECommerce.DataAccess.Context;
using ECommerce.Models.Model.Products.Groups;
using ECommerce.Models.Model.Products.States;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.Services.Repository.EF.GroupRepo
{
    public class GroupRepository : IGroupRepository
    {
        private  AppDbContext _db;
        public GroupRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Group group)
        {
            _db.Entry<Group>(group).State = EntityState.Added;
            await _db.Groups.AddAsync(group);
        }

        public async Task DeleteAsync(int id)
        {
            var model = await GetGroup(id);
            _db.Groups.Remove(model);
        }

        public async Task<Group> GetGroup(int id)
        {
            var model = await GetGroup(id);
            return model;
        }

        public async Task<IEnumerable<Group>> GetGroupsAsync(int? id, string title, string slug, State? state)
        {
            var model = await _db.Groups.Include(o => o.Creator).Include(i => i.LastModifier).ToListAsync();
                
            model= string.IsNullOrEmpty(title)? model: model.Where(t => t.Title.Contains(title)).ToList();
            model = id != null ? model.Where(i => i.Id == id).ToList() : model;
            model = state != null ? model.Where(s => s.State == state).ToList() : model;
            model = string.IsNullOrEmpty(slug) ? model : model.Where(t => t.Slug.Contains(title)).ToList();
            return model;
        }

        public async Task Update(Group group)
        {
            _db.Entry(group).State = EntityState.Modified;
            
        }        

        public async Task<Group> GetGroupAsync(int id)
        {
            return await _db.Groups.Include(x=>x.Creator).Include(x=>x.LastModifier).FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task SaveAsync()
        {
           await _db.SaveChangesAsync();
        }
    }
}
