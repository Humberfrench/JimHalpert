using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Domain.Inteface.Service;
using Dietcode.Core.DomainValidator;
using Dietcode.Core.Lib;
using System.Collections.Generic;
using JimHalpert.Domain.ObjectValue;
using System.Net.Mail;
using System.Threading.Tasks;

namespace JimHalpert.Services
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository repository;
        private readonly ValidationResult validationResult;
        private readonly IConvertKey convertKey;

        public UsuarioService(IBaseRepository<Usuario> baseRepository,
                              IUsuarioRepository repository,
                              IConvertKey convertKey) : base(baseRepository)
        {
            this.repository = repository;
            this.convertKey = convertKey;
            validationResult = new ValidationResult();
        }

        public async Task<ValidationResult> Gravar(UsuarioDados usuarioDados)
        {
            //validate

            if (usuarioDados.Login.IsNullOrEmptyOrWhiteSpace())
            {
                validationResult.Add("Login não preenchido");
                return validationResult;
            }

            if (usuarioDados.Nome.IsNullOrEmptyOrWhiteSpace())
            {
                validationResult.Add("Nome não preenchido");
                return validationResult;
            }

            if (usuarioDados.Email.IsNullOrEmptyOrWhiteSpace())
            {
                validationResult.Add("Email não preenchido");
                return validationResult;
            }

            if (usuarioDados.Celular.IsNullOrEmptyOrWhiteSpace())
            {
                validationResult.Add("Celular não preenchido");
                return validationResult;
            }

            if (usuarioDados.DataNascimento.Year == 1)
            {
                validationResult.Add("Data de Nascimento não preenchido");
                return validationResult;
            }


            //senha padrão
            var senha = "123@change";
            var chave = convertKey.Encript(senha);

            Usuario usuario = null;
            if (usuarioDados.UsuarioId == 0)
            {
                usuario = new Usuario
                {
                    Login = usuarioDados.Login,
                    Nome = usuarioDados.Nome,
                    Email = usuarioDados.Email,
                    Celular = usuarioDados.Celular,
                    DataNascimento = usuarioDados.DataNascimento,
                    Senha = chave.ChaveEncript,
                    DataAtualizacao = System.DateTime.Now,
                    DataCriacao = System.DateTime.Now,
                    ValidadeSenha = System.DateTime.Now.AddMonths(3),
                };
            }
            else
            {
                usuario = await repository.ObterPorIdAsync(usuarioDados.UsuarioId);
                usuario.Login = usuarioDados.Login;
                usuario.Nome = usuarioDados.Nome;
                usuario.Email = usuarioDados.Email;
                usuario.Celular = usuarioDados.Celular;
                usuario.DataNascimento = usuarioDados.DataNascimento;
                usuario.DataAtualizacao = System.DateTime.Now;
                usuario.DataCriacao = System.DateTime.Now;
                usuario.ValidadeSenha = System.DateTime.Now.AddMonths(3);
            }


            //add or update
            if (usuarioDados.UsuarioId == 0)
            {
                await repository.AdicionarAsync(usuario);
            }
            else
            {
                await repository.AtualizarAsync(usuario);
            }

            return validationResult;
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var usuario = await repository.ObterPorIdAsync(id);

            if (usuario == null)
            {
                validationResult.Add("Tipo de Pessoa inexistente");
                return validationResult;
            }

            base.Remover(usuario);
            return validationResult;
        }

        public async Task<IEnumerable<Usuario>> Filtrar(string query)
        {
            return await repository.Filtrar(query);
        }

        private async Task<ValidationResult> ObterUsuario(int usuarioId)
        {
            var usuario = await repository.ObterPorIdAsync(usuarioId);

            if (usuario == null)
            {
                validationResult.Add("Usuario não encontrado");
                return validationResult;
            }
            validationResult.Retorno = usuario;
            return validationResult;
        }

        private async Task<ValidationResult> ObterUsuario(string login)
        {
            var usuario = await repository.ObterUsuario(login);

            if (usuario == null)
            {
                validationResult.Add("Usuario não encontrado");
                return validationResult;
            }
            validationResult.Retorno = usuario;
            return validationResult;
        }


        public async Task<ValidationResult> AlterarSenha(AlterarSenhaObject dado)
        {
            var usuarioValidator = await ObterUsuario(dado.Login);

            if(usuarioValidator.Invalid)
            {
                validationResult.Add("Usuario não encontrado");
                return validationResult;
            }

            var usuario = usuarioValidator.Retorno as Usuario;
            var senha = convertKey.Decript(usuario.Senha).ChaveDecript;

            if(senha != dado.SenhaAtual)
            {
                validationResult.Add("Senha atual incorreta");
                return validationResult;
            }

            if (senha == dado.SenhaNova)
            {
                validationResult.Add("Senha atual igual a senha nova.");
                return validationResult;
            }

            usuario.Senha = convertKey.Encript(dado.SenhaNova).ChaveEncript;

            await repository.AtualizarAsync(usuario);

            return null;
        }

        public async Task<ValidationResult> Login(LoginDado login)
        {
            return null;
        }

        public async Task<ValidationResult> DesbloqueiaUsuario(int usuarioId)
        {
            var usuarioValidator = await ObterUsuario(usuarioId);

            if (usuarioValidator.Invalid)
            {
                validationResult.Add("Usuario não encontrado");
                return validationResult;
            }
            var usuario = usuarioValidator.Retorno as Usuario;

            return await DesbloqueiaUsuario(usuario);
        }
        public async Task<ValidationResult> DesbloqueiaUsuario(string login)
        {
            var usuarioValidator = await ObterUsuario(login);

            if (usuarioValidator.Invalid)
            {
                validationResult.Add("Usuario não encontrado");
                return validationResult;
            }
            var usuario = usuarioValidator.Retorno as Usuario;

            return await DesbloqueiaUsuario(usuario);
        }

        private async Task<ValidationResult> DesbloqueiaUsuario(Usuario usuario)
        {

            usuario.Ativo = true;
            usuario.TentativasInvalidas = 0;
            usuario.DataAtualizacao = System.DateTime.Now;
            await repository.AtualizarAsync(usuario);

            return validationResult;
        }
        public async Task<ValidationResult> BloqueiaUsuario(int usuarioId)
        {
            var usuarioValidator = await ObterUsuario(usuarioId);

            if (usuarioValidator.Invalid)
            {
                validationResult.Add("Usuario não encontrado");
                return validationResult;
            }

            var usuario = usuarioValidator.Retorno as Usuario;

            usuario.Ativo = false;
            usuario.TentativasInvalidas = 0;
            usuario.DataAtualizacao = System.DateTime.Now;
            await repository.AtualizarAsync(usuario);

            return validationResult;
        }

    }
}
