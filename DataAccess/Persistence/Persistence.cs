using System.Threading.Tasks;
using DataAccess.Database;

namespace DataAccess.Persistence
{
    public class Persistence : IPersistence
    {
        private readonly DatabaseContext _context;

        public Persistence(DatabaseContext context)
        {
            _context = context;
        }
        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public int SaveChange()
        {
            return _context.SaveChanges();
        }
    }
}
