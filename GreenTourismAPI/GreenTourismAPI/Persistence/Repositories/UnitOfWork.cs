using GreenTourismAPI.Domain.Repositories;
using System.Threading.Tasks;

namespace GreenTourismAPI.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _Context;

        public UnitOfWork(AppDbContext context)
        {
            _Context = context;
        }

        public async Task CompleteAsync()
        {
            await _Context.SaveChangesAsync();
        }
    }
}
