using System.ComponentModel.DataAnnotations;

namespace ProjetoFaculdade.DTO;

public class LoginDTO
{
    [Required(ErrorMessage = "O email é obrigatório.")]
    [EmailAddress(ErrorMessage = "Informe um email válido.")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "A senha é obrigatória.")]
    public string Senha { get; set; }
}