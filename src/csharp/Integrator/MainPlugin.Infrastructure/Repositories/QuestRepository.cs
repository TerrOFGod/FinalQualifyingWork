using GPTTextGenerator.Entities.Interfaces;
using GPTTextGenerator.Entities.Models.Interactions;
using System.Linq.Expressions;

namespace GPTTextGenerator.Infrastructure.Repositories
{
    public class QuestRepository : IRepository<Quest>
    {
        public void Add(in Quest sender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Quest> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Quest>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Quest GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Quest> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Quest GetByIdWithIncludes(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Quest> GetByIdWithIncludesAsync(int id)
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

        public Quest Select(Expression<Func<Quest, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Quest> SelectAsync(Expression<Func<Quest, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(in Quest sender)
        {
            throw new NotImplementedException();
        }
    }
}
