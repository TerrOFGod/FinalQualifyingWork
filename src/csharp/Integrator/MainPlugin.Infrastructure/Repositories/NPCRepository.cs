using MainPlugin.Core.Entities.Interfaces;
using MainPlugin.Core.Entities.Models.Interactors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MainPlugin.Infrastructure.Repositories
{
    public class NPCRepository : IRepository<SmartNPC>
    {
        public void Add(in SmartNPC sender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SmartNPC> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<SmartNPC>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public SmartNPC GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SmartNPC> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public SmartNPC GetByIdWithIncludes(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SmartNPC> GetByIdWithIncludesAsync(int id)
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

        public SmartNPC Select(Expression<Func<SmartNPC, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<SmartNPC> SelectAsync(Expression<Func<SmartNPC, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(in SmartNPC sender)
        {
            throw new NotImplementedException();
        }
    }
}
