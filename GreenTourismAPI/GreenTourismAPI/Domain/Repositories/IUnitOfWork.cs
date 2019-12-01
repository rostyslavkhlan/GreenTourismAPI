using System.Threading.Tasks;

namespace GreenTourismAPI.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
