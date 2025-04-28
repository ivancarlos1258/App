namespace App.Domain.DTOs.Usuario
{
    public class UsuarioPostDto
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Cpf { get; set; }

        public DateTime Nascimento { get; set; }

        public string Telefone { get; set; }

        public bool? IsAtivo { get; set; }

      
    }
}
