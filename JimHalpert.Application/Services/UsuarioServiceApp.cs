using Dietcode.Api.Core.Results;
using Dietcode.Core.DomainValidator;
using Dietcode.Core.Lib;
using JimHalpert.App.ViewModel;
using JimHalpert.App.ViewModel.Interface;
using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Domain.Inteface.Service;
using JimHalpert.Domain.ObjectValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace JimHalpert.App.Services
{
    public class UsuarioServiceApp : BaseServiceApp<UsuarioViewModel>, IUsuarioServiceApp
    {
        private readonly IUsuarioService service;

        public UsuarioServiceApp(IUsuarioService service, IUnitOfWork uow) : base(uow)
        {
            this.service = service;
        }

        public async Task<MethodResult<ValidationResult>> Gravar(UsuarioDadosViewModel Usuario)
        {
            BeginTransaction();
            var dadoIncluir = Usuario.ConvertObjects<UsuarioDados>(); //Mapper.Map<Usuario>(Usuario);
            var retorno = await service.Gravar(dadoIncluir);
            if (retorno.Valid)
            {
                //commit transaction
                Commit();
                //commit error
                if (!ValidationResults.Valid)
                {
                    return Ok(retorno);
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

        public async Task<MethodResult<UsuarioViewModel>> ObterPorId(int id)
        {
            var Usuarios = await service.ObterPorId(id);
            var retorno = Usuarios.ConvertObjects<UsuarioViewModel>(); //Mapper.Map<UsuarioViewModel>(Usuarios);

            if (retorno == null)
            {
                return Ok(new UsuarioViewModel());
            }

            return Ok(retorno);
        }

        public async Task<MethodResult<List<UsuarioViewModel>>> ObterTodos()
        {
            var Usuarios = await service.ObterTodos();
            var retorno = Usuarios.ConvertObjects<List<UsuarioViewModel>>(); //Mapper.Map<IEnumerable<UsuarioViewModel>>(Usuarios);

            if (!retorno.Any())
            {
                return Ok(new List<UsuarioViewModel>());
            }

            return Ok(retorno);

        }

        public async Task<MethodResult<List<UsuarioViewModel>>> Filtrar(string query)
        {
            var Usuarios = await service.Filtrar(query);
            var retorno = Usuarios.ConvertObjects<List<UsuarioViewModel>>(); //Mapper.Map<IEnumerable<UsuarioViewModel>>(Usuarios);

            if (!retorno.Any())
            {
                return Ok(new List<UsuarioViewModel>());
            }

            return Ok(retorno);

        }

        [Obsolete("Método não implementado. Não usar.")]
        public Task<MethodResult<ValidationResult>> Gravar(UsuarioViewModel dado)
        {
            throw new System.NotImplementedException();
        }
    }
}
