using MainPlugin.Core.Entities.Interfaces;
using MainPlugin.Core.Entities.Models.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MainPlugin.Infrastructure.Repositories
{
    public class ChainQuestRepository : IRepository<ChainQuest>
    {
        public void Add(in ChainQuest sender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ChainQuest> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<ChainQuest>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ChainQuest GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ChainQuest> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ChainQuest GetByIdWithIncludes(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ChainQuest> GetByIdWithIncludesAsync(int id)
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

        public ChainQuest Select(Expression<Func<ChainQuest, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<ChainQuest> SelectAsync(Expression<Func<ChainQuest, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(in ChainQuest sender)
        {
            throw new NotImplementedException();
        }
    }
}
