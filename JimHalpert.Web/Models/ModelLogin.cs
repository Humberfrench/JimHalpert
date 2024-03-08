namespace JimHalpert.Web.Models
{
    public class ModelLogin : ModelBase
    {
        public ModelLogin()
        {
            Login = string.Empty;
            Senha = string.Empty;
            UsuarioReset = string.Empty;
            ReturnUrl = string.Empty;
        }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string UsuarioReset { get; set; }
        public string ReturnUrl { get; set; }


    }
}
