
using Dapper;
using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Repository.Interfaces;
using System.Collections.Generic;

namespace JimHalpert.Repository
{
    public class MesRepository : BaseRepository<Mes>, IMesRepository
    {
        public MesRepository(IContextManager contextManager) : base(contextManager)
        {

        }

    }
}