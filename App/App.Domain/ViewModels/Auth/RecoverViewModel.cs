namespace App.Domain.ViewModels.Auth
{
    public class RecoverViewModel
    {
        public string Cpf { get; set; }
        public string Email { get; set; }

        //apos momento da solicitacao
        public Guid Token { get; set; }
        public string SenhaAntiga { get; set; }
        public string NovaSenha { get; set; }
    }
}
