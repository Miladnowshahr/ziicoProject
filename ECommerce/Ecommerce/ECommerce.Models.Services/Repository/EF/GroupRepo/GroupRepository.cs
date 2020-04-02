using ECommerce.DataAccess.Context;
using ECommerce.Models.Model.Products.Groups;
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
        private readonly AppDbContext _db;
        public GroupRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Group group)
        {
            await _db.Groups.AddAsync(group);
        }

        public async Task DeleteAsync(Group group)
        {
            var model = await GetGroup(group.Id);
            _db.Groups.Remove(model);
        }

        public async Task<Group> GetGroup(int id)
        {
            var model = await GetGroup(id);
            return model;
        }

        public async Task<IEnumerable<Group>> GetGroupsAsync()
        {
            return await _db.Groups.ToListAsync();
        }

        public void Update(Group group)
        {
             _db.Groups.Update(group);
        }        

        public async Task<Group> GetGroupAsync(int id)
        {
            return await _db.Groups.FindAsync(id);
        }

        public async Task SaveAsync()
        {
           await _db.SaveChangesAsync();
        }
    }
}
