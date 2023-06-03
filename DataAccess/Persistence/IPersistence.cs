using System.Threading.Tasks;

namespace DataAccess.Persistence
{
    public interface IPersistence
    {
        Task<int> SaveChangesAsync();
        int SaveChange();
    }
}