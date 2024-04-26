using GPTTextGenerator.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using GPTTextGenerator.Entities.Interfaces;
using GPTTextGenerator.Entities.Models.Interactions;
using System.Linq.Expressions;

namespace GPTTextGenerator.Infrastructure.Repositories
{
    public class DialogueEntryRepository : IRepository<DialogueEntry>
    {
        private readonly BasicDbContext _dbContext;

        public DialogueEntryRepository(BasicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(in DialogueEntry entry)
        {
            _dbContext.DialogueEntries.Add(entry);

            foreach (var node in entry.Childs)
            {
                AddDialogueNodeAndChildren(node);
            }

            _dbContext.SaveChanges();
        }

        private void AddDialogueNodeAndChildren(DialogueNode node)
        {
            _dbContext.DialogueNodes.Add(node);

            if (node.Childs != null && node.Childs.Any())
            {
                foreach (var childNode in node.Childs)
                {
                    AddDialogueNodeAndChildren(childNode);
                }
            }
        }

        public IEnumerable<DialogueEntry> GetAll()
            => _dbContext.DialogueEntries.Include(x => x.Childs).ToList();

        public Task<List<DialogueEntry>> GetAllAsync()
            => _dbContext.DialogueEntries.Include(x => x.Childs).ToListAsync();

        public DialogueEntry GetById(int id) 
            => _dbContext.DialogueEntries.Include(x => x.Childs)
                                         .FirstOrDefault(x => x.ID == id);

        public Task<DialogueEntry> GetByIdAsync(int id) 
            => _dbContext.DialogueEntries.Include(x => x.Childs)
                                         .FirstOrDefaultAsync(x => x.ID == id);

        public DialogueEntry GetByIdWithIncludes(int id) 
            => _dbContext.DialogueEntries.Include(x => x.Childs)
                                         .FirstOrDefault(x => x.ID == id);

        public Task<DialogueEntry> GetByIdWithIncludesAsync(int id) 
            => _dbContext.DialogueEntries.Include(x => x.Childs)
                                         .FirstOrDefaultAsync(x => x.ID == id);

        public bool Remove(int id)
        {
            var entry = _dbContext.DialogueEntries.FirstOrDefault(x => x.ID == id);
            if (entry != null)
            {
                _dbContext.DialogueEntries.Remove(entry);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public int Save()
            => _dbContext.SaveChanges();

        public Task<int> SaveAsync()
            => _dbContext.SaveChangesAsync();
        

        public DialogueEntry Select(Expression<Func<DialogueEntry, bool>> predicate) 
            => _dbContext.DialogueEntries.Include(x => x.Childs)
                                         .FirstOrDefault(predicate);

        public Task<DialogueEntry> SelectAsync(Expression<Func<DialogueEntry, bool>> predicate) 
            => _dbContext.DialogueEntries.Include(x => x.Childs)
                                         .FirstOrDefaultAsync(predicate);

        public void Update(in DialogueEntry entry)
        {
            _dbContext.DialogueEntries.Update(entry);
            _dbContext.SaveChanges();
        }
    }
}
