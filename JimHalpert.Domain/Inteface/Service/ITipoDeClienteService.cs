﻿using JimHalpert.Domain.Entity;
using JimHalpert.DomainValidator;
using System.Collections.Generic;

namespace JimHalpert.Domain.Inteface.Service
{
    public interface ITipoDeClienteService : IBaseService<TipoDeCliente> 
    { 
        ValidationResult Gravar(TipoDeCliente tipoDeCliente);
        ValidationResult Excluir(int id);
        IEnumerable<TipoDeCliente> Filtrar(string query);
    }
}
