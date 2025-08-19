using System.ComponentModel.DataAnnotations;

namespace ProjetoFaculdade.Models;

public class Usuario
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Por favor, informe o nome")]
    [StringLength(20)]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "Por favor, informe o email")]
    [EmailAddress(ErrorMessage = "Por favor, informe um email valido")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Por favor, informe a senha")]
    [StringLength(20, MinimumLength = 8, ErrorMessage = "A senha deve ter entre 8 e 20 caracteres")]
    public string Senha { get; set; }
}