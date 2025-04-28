namespace App.Domain.ViewModels.Auth
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Lembrar { get; set; }
        public string SenhaNova { get; set; }
        public string SenhaConferencia { get; set; }
    }
}
