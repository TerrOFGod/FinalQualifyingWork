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
