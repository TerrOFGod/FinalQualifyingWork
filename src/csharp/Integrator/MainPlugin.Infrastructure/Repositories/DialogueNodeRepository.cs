using MainPlugin.Core.Entities.Interfaces;
using MainPlugin.Core.Entities.Models.Interactions;
using MainPlugin.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MainPlugin.Infrastructure.Repositories
{
    public class DialogueNodeRepository : IRepository<DialogueNode>
    {
        private readonly BasicDbContext _dbContext;

        public DialogueNodeRepository(BasicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(in DialogueNode sender)
        {
            _dbContext.DialogueNodes.Add(sender);
            _dbContext.SaveChanges();
        }

        public IEnumerable<DialogueNode> GetAll()
            => _dbContext.DialogueNodes.ToList();

        public Task<List<DialogueNode>> GetAllAsync()
            => _dbContext.DialogueNodes.ToListAsync();

        public DialogueNode GetById(int id) 
            => _dbContext.DialogueNodes.FirstOrDefault(x => x.ID == id);

        public Task<DialogueNode> GetByIdAsync(int id) 
            => _dbContext.DialogueNodes.FirstOrDefaultAsync(x => x.ID == id);

        // Add any necessary includes here
        public DialogueNode GetByIdWithIncludes(int id)
            => _dbContext.DialogueNodes.Include(x => x.Childs).FirstOrDefault(x => x.ID == id);

        // Add any necessary includes here
        public Task<DialogueNode> GetByIdWithIncludesAsync(int id)
            => _dbContext.DialogueNodes.Include(x => x.Childs).FirstOrDefaultAsync(x => x.ID == id);

        public bool Remove(int id)
        {
            var entity = _dbContext.DialogueNodes.FirstOrDefault(x => x.ID == id);
            if (entity != null)
            {
                _dbContext.DialogueNodes.Remove(entity);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public int Save()
            => _dbContext.SaveChanges();
       
        public Task<int> SaveAsync()
            => _dbContext.SaveChangesAsync();

        public DialogueNode Select(Expression<Func<DialogueNode, bool>> predicate)
            => _dbContext.DialogueNodes.FirstOrDefault(predicate);

        public Task<DialogueNode> SelectAsync(Expression<Func<DialogueNode, bool>> predicate)
            => _dbContext.DialogueNodes.FirstOrDefaultAsync(predicate);

        public void Update(in DialogueNode sender)
        {
            _dbContext.Entry(sender).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
