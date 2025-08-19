using ProjetoFaculdade.DTO;
using ProjetoFaculdade.Models;

namespace ProjetoFaculdade.Mapper;

public class MapeamentoUsuario
{
    public static Usuario ToUsuario(LoginDTO dto)
    {
        return new Usuario
        {
            Email = dto.Email,
            Senha = dto.Senha,
        };
    }

    public static LoginDTO ToLogin(Usuario usuario)
    {
        return new LoginDTO
        {
            Email = usuario.Email,
            Senha = usuario.Senha,
        };
    }
}