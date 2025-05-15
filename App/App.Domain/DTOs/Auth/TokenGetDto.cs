namespace App.Domain.DTOs.Auth
{
    public class TokenGetDto
    {
        public string IdentificadorToken { get; set; }
        public DateTime? ExpiraEm { get; set; }
    }
}
