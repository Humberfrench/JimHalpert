﻿using Dietcode.Api.Core.Results;
using Dietcode.Core.DomainValidator;
using Dietcode.Core.Lib;
using JimHalpert.App.ViewModel;
using JimHalpert.App.ViewModel.Interface;
using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Domain.Inteface.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JimHalpert.App.Services
{
    public class ServicoServiceApp : BaseServiceApp<ServicoViewModel>, IServicoServiceApp
    {
        private readonly IServicoService service;
        public ServicoServiceApp(IServicoService service, IUnitOfWork uow) : base(uow)
        {
            this.service = service;
        }

        public async Task<MethodResult> Gravar(ServicoViewModel servico)
        {
            BeginTransaction();
            var dadoIncluir = servico.ConvertObjects<Servico>();
            var retorno = await service.Gravar(dadoIncluir);
            if (retorno.Valid)
            {
                //commit transaction
                Commit();
                //commit error
                if (!ValidationResults.Valid)
                {
                    return BadRequest(ConvertValidationErrors(ValidationResults.Erros.ToList()));
                }
            }
            return Ok(retorno);

        }

        public async Task<MethodResult> Excluir(int id)
        {
            BeginTransaction();
            var retorno = await service.Excluir(id);
            if (retorno.Valid)
            {
                //commit transaction
                Commit();
                //commit error
                if (!ValidationResults.Valid)
                {
                    return BadRequest(ConvertValidationErrors(ValidationResults.Erros.ToList()));
                }
            }
            return Ok(retorno);

        }

        public async Task<MethodResult> ObterPorId(int id)
        {
            var servicos = await service.ObterPorId(id);
            var retorno = servicos.ConvertObjects<ServicoViewModel>();
            if (retorno == null)
            {
                return NotFound("Não foi encontrado registros");
            }

            return Ok(retorno);
        }

        public async Task<MethodResult> ObterTodos()
        {
            var servicos = await service.ObterTodos();
            var retorno = servicos.ConvertObjects<List<ServicoViewModel>>();
            if (!retorno.Any())
            {
                return NotFound("Não foi encontrado registros");
            }

            return Ok(retorno);

        }

        public async Task<MethodResult> Filtrar(string query)
        {
            var servicos = await service.Filtrar(query);
            var retorno = servicos.ConvertObjects<List<ServicoViewModel>>();
            if (!retorno.Any())
            {
                return NotFound("Não foi encontrado registros");
            }

            return Ok(retorno);

        }
    }
}