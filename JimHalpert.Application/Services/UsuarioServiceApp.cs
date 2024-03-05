using Dietcode.Api.Core.Results;
using Dietcode.Core.DomainValidator;
using Dietcode.Core.Lib;
using JimHalpert.App.ViewModel;
using JimHalpert.App.ViewModel.Interface;
using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Domain.Inteface.Service;
using JimHalpert.Domain.ObjectValue;
using System.Collections.Generic;
using System.Linq;


namespace JimHalpert.App.Services
{
    public class UsuarioServiceApp : BaseServiceApp<UsuarioViewModel>, IUsuarioServiceApp
    {
        private readonly IUsuarioService service;

        public UsuarioServiceApp(IUsuarioService service, IUnitOfWork uow) : base(uow)
        {
            this.service = service;
        }

        public MethodResult Gravar(UsuarioDadosViewModel Usuario)
        {
            BeginTransaction();
            var dadoIncluir = Usuario.ConvertObjects<UsuarioDados>(); //Mapper.Map<Usuario>(Usuario);
            var retorno = service.Gravar(dadoIncluir);
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

        public MethodResult Excluir(int id)
        {
            BeginTransaction();
            var retorno = service.Excluir(id);
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

        public MethodResult ObterPorId(int id)
        {
            var Usuarios = service.ObterPorId(id);
            var retorno = Usuarios.ConvertObjects<UsuarioViewModel>(); //Mapper.Map<UsuarioViewModel>(Usuarios);

            if (retorno == null)
            {
                return NotFound("Não foi encontrado registros");
            }

            return Ok(retorno);
        }

        public MethodResult ObterTodos()
        {
            var Usuarios = service.ObterTodos();
            var retorno = Usuarios.ConvertObjects<List<UsuarioViewModel>>(); //Mapper.Map<IEnumerable<UsuarioViewModel>>(Usuarios);

            if (!retorno.Any())
            {
                return NotFound("Não foi encontrado registros");
            }

            return Ok(retorno);

        }

        public MethodResult Filtrar(string query)
        {
            var Usuarios = service.Filtrar(query);
            var retorno = Usuarios.ConvertObjects<List<UsuarioViewModel>>(); //Mapper.Map<IEnumerable<UsuarioViewModel>>(Usuarios);

            if (!retorno.Any())
            {
                return NotFound("Não foi encontrado registros");
            }

            return Ok(retorno);

        }
    }
}
