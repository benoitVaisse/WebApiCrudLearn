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

        public Task<Employe> Create(Employe entity)
        {
            throw new NotImplementedException();
        }

        public Task<Employe> Delete(Employe entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employe>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<Employe> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Employe> Update(Employe entity)
        {
            throw new NotImplementedException();
        }
    }
}
