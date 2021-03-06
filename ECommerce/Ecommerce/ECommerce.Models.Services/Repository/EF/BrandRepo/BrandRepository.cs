﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.DataAccess.Context;
using ECommerce.Models.Model.Products.Brands;
using ECommerce.Models.Model.Products.States;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Models.Services.Repository.EF.BrandRepo
{
    public class BrandRepository:IBrandRepository
    {
        private AppDbContext _db;

        public BrandRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Brand brand)
        {
            _db.Entry<Brand>(brand).State = EntityState.Added;
            await _db.Brands.AddAsync(brand);
        }

        public async Task Update(Brand brand)
        {
            //_db.Brands.Update(brand);
            _db.Entry(brand).State = EntityState.Modified;
        }

        public async Task DeleteAsync(Brand brand)
        {
            var model = await GetBrandAsync(brand.Id);
            _db.Brands.Remove(model);
        }

        public async Task<IEnumerable<Brand>> GetBrandsAsync(string title, int? id, State? state)
        {
            var model= await _db.Brands.Include(o=>o.Creator).Include(i=>i.LastModifier)
                .Where(b=>(b.Title.Contains(title)|| string.IsNullOrEmpty(title)) 
                && (b.Id==id || id==null) && (b.State==state||state==null))
                .ToListAsync();

            //old version

            //model= string.IsNullOrEmpty(title)? model.Where(t => t.Title.Contains(title)).ToList() : model;
            //model = id != null ? model.Where(i => i.Id == id).ToList() : model;
            //model = state != null ? model.Where(s => s.State == state).ToList() : model;

            return model;
        }

        public async Task<Brand> GetBrandAsync(int id)
        {
            return await _db.Brands.Include(i => i.Creator).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
