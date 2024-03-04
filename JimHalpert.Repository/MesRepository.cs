using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Repository.Interfaces;

namespace JimHalpert.Repository
{
    public class MesRepository : BaseRepository<Mes>, IMesRepository
    {
        public MesRepository(IContextManager contextManager) : base(contextManager)
        {

        }

    }
}