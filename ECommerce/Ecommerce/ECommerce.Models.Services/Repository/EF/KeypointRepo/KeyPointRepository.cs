using ECommerce.DataAccess.Context;
using ECommerce.Models.Model.KeyPoints;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.Services.Repository.EF.KeypointRepo
{
    public class KeyPointRepository : IKeyPointRepository
    {
        private AppDbContext _db;


        public KeyPointRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(KeyPoint keyPoint)
        {
            await _db.KeyPoints.AddAsync(keyPoint);
        }

        public async Task<KeyPoint> KeyPointAsync(int id)
        {
            var model = await _db.KeyPoints.Include(x=>x.Creator).Include(x=>x.LastModifier).FirstOrDefaultAsync(x=>x.Id==id);
            return model;
        }

        public async Task<IEnumerable<KeyPoint>> KeyPointsAsync(int? id,int? productId, string title,KeyPointType? type)
        {
            var models = await _db.KeyPoints.Include(x=>x.Creator).Include(x=>x.LastModifier)
                .Where(x=> (x.Title.Contains(title)||string.IsNullOrEmpty(title)) &&
                (x.Type==type || type==null)   &&
                    (x.Id==id|| id==null)&& (x.ProductId==productId || productId==null))
                .ToListAsync();

            return models;
        }

        public void Update(KeyPoint keyPoint)
        {
            _db.Entry(keyPoint).State = EntityState.Modified;

        }
        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
        public async Task RemoveAsync(int id)
        {
            _db.Remove(id);
            await _db.SaveChangesAsync();
        }
    }
}
