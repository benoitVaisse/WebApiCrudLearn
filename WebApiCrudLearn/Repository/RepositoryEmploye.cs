using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCrudLearn.Data;
using WebApiCrudLearn.Models;

namespace WebApiCrudLearn.Repository
{
    public class RepositoryEmploye : IRepositoryEmploye
    {
        private readonly ApplicationDBContext _context;

        public RepositoryEmploye(ApplicationDBContext context)
        {
            this._context = context;
        }

        public async Task<Employe> CreateAsync(Employe entity)
        {
            this._context.Employes.Add(entity);
            await this._context.SaveChangesAsync();
            return entity;
        }

        public async Task<Employe> DeleteAsync(Employe entity)
        {
            this._context.Employes.Remove(entity);
            await this._context.SaveChangesAsync();
            return entity;
        }

        public async Task<ICollection<Employe>> FindAllAsync()
        {
            return await this._context.Employes.ToListAsync();
        }

        public async Task<Employe> GetAsync(int id)
        {
            return await this._context.Employes.AsNoTracking().Where(e=>e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Employe> UpdateAsync(Employe entity)
        {
            this._context.Employes.Update(entity);
            await this._context.SaveChangesAsync();
            return entity;
        }
    }
}
