using MainPlugin.Core.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MainPlugin.Infrastructure.Repositories
{
    public class EnvironmentRepository : IRepository<Environment>
    {
        public void Add(in Environment sender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Environment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Environment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Environment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Environment> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Environment GetByIdWithIncludes(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Environment> GetByIdWithIncludesAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Environment Select(Expression<Func<Environment, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Environment> SelectAsync(Expression<Func<Environment, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(in Environment sender)
        {
            throw new NotImplementedException();
        }
    }
}
