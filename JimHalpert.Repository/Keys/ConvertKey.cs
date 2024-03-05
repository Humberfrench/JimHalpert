using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Domain.ObjectValue;
using JimHalpert.Repository.Interfaces;

namespace JimHalpert.Repository.Keys
{
    public class ConvertKey : IConvertKey
    {
        private readonly IContextManager contextManager;
        private readonly IDbConnection Connection;


        public ConvertKey(IContextManager contextManager)
        {
            this.contextManager = contextManager;
            Connection = new SqlConnection(contextManager.GetConnectionString);
        }

        public Chave Decript(byte[] chave)
        {
            var sql = @"Exec OpenKeys

                        SELECT dbo.Decrypt(@chave) as ChaveDecript

                        Exec CloseKeys";

            var result = Connection.Query<Chave>(sql, new { @chave = chave }).FirstOrDefault();
            if (result != null)
            {
                result.ChaveEncript = chave;
            }

            return result;

        }

        public Chave Encript(string chave)
        {
            var sql = @"Exec OpenKeys

                        SELECT dbo.Encrypt(@chave) as ChaveEncript

                        Exec CloseKeys";

            var result = Connection.Query<Chave>(sql, new { @chave = chave }).FirstOrDefault();
            if (result != null)
            {
                result.ChaveDecript = chave;
            }

            return result;

        }



    }
}
