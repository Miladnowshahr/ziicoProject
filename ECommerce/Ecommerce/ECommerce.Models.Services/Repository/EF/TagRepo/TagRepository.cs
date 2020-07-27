using ECommerce.DataAccess.Context;
using ECommerce.Models.Models.Tags;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.Services.Repository.EF.TagRepo
{
    public class TagRepository : ITagRepository
    {
        private AppDbContext _db;

        public TagRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Tag tag)
        {
            await _db.Tags.AddAsync(tag);
        }

        public async Task<Tag> GetTagAsync(int id)
        {
            return await _db.Tags.Include(x=>x.Creator).Include(x=>x.LastModifier).FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<IEnumerable<Tag>> GetTagsAsync(int? id, string title)
        {
            return await _db.Tags.Include(x => x.Creator).Include(x => x.LastModifier).Where(x => (x.Id == id || !id.HasValue)).ToListAsync();
        }

        public async Task Remove(int id)
        {
            var model =await GetTagAsync(id);
            _db.Tags.Remove(model);
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Update(Tag tag)
        {
            _db.Entry(tag).State = EntityState.Modified;
        }
    }
}
