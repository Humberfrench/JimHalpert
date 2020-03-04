
using Dapper;
using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Repository.Interfaces;
using System.Collections.Generic;

namespace JimHalpert.Repository
{
    public class StatusNotaFiscalRepository : BaseRepository<StatusNotaFiscal>, IStatusNotaFiscalRepository
    {
        public StatusNotaFiscalRepository(IContextManager contextManager) : base(contextManager)
        {

        }

    }
}