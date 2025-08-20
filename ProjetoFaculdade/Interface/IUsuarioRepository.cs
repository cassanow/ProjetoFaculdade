
using ProjetoFaculdade.Models;

namespace ProjetoFaculdade.Interface;

public interface IUsuarioRepository
{
    Task Registrar(Usuario usuario);
    
    Task<bool> UsuarioExiste(string email);
    
    Task<Usuario> ObterUsuario(string email);         
    
    Task<List<Usuario>> ObterListaUsuarios();
}