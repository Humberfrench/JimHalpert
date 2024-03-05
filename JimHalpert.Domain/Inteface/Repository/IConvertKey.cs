using JimHalpert.Domain.ObjectValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JimHalpert.Domain.Inteface.Repository
{
    public interface IConvertKey
    {
        Chave Decript(byte[] chave);
        Chave Encript(string chave);
    }
}
