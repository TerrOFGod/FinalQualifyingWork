using GPTTextGenerator.Entities.Interfaces;
using GPTTextGenerator.Entities.Models.Interactors;
using System.Linq.Expressions;

namespace GPTTextGenerator.Infrastructure.Repositories
{
    public class PlayerRepository : IRepository<Player>
    {
        public void Add(in Player sender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Player> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Player>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Player GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Player> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Player GetByIdWithIncludes(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Player> GetByIdWithIncludesAsync(int id)
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

        public Player Select(Expression<Func<Player, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Player> SelectAsync(Expression<Func<Player, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(in Player sender)
        {
            throw new NotImplementedException();
        }
    }
}
