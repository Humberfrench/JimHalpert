using JimHalpert.Domain.Entity;
using Dietcode.Core.DomainValidator;
using System.Collections.Generic;
using JimHalpert.Domain.ObjectValue;
using System.Threading.Tasks;

namespace JimHalpert.Domain.Inteface.Service
{
    public interface IUsuarioService : IBaseService<Usuario> 
    {
        Task<ValidationResult> Gravar(UsuarioDados Usuario);
        Task<ValidationResult> Excluir(int id);
        Task<IEnumerable<Usuario>> Filtrar(string query);
        Task<ValidationResult> BloqueiaUsuario(int usuario);
        Task<ValidationResult> DesbloqueiaUsuario(string login);
        Task<ValidationResult> DesbloqueiaUsuario(int usuario);
        Task<ValidationResult> Login(LoginDado login);
        Task<ValidationResult> AlterarSenha(AlterarSenhaObject dado);
    }
}
