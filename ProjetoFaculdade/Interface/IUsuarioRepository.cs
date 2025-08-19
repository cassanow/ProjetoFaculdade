
using ProjetoFaculdade.Models;

namespace ProjetoFaculdade.Interface;

public interface IUsuarioRepository
{
    Task Registrar(Usuario usuario);
    
    Task<bool> UsuarioExiste(string email);
}