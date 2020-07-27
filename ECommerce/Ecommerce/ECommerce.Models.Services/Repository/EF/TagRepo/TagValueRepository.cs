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
    public class TagValueRepository : ITagValueRepository
    {
        private AppDbContext _db;

        public TagValueRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(TagValue tag)
        {
            await _db.TagValues.AddAsync(tag);
        }

        public async Task<TagValue> GetTagValueAsync(int id)
        {
            return await _db.TagValues.Include(x => x.Creator).Include(x => x.LastModifier).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TagValue>> GetTagValuesAsync(int? id, string title)
        {
            return await _db.TagValues.Include(x => x.Creator)
                .Include(x => x.LastModifier).Where(x => (x.Id == id || id.HasValue) && (x.Title.Contains(title)) || string.IsNullOrEmpty(title)).ToListAsync();
        }

        public async Task Remove(int id)
        {
            var model =await GetTagValueAsync(id);
            _db.TagValues.Remove(model);
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Update(TagValue tagvalue)
        {
            _db.Entry(tagvalue).State = EntityState.Modified;
        }
    }
}
