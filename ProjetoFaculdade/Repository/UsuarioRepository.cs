using Microsoft.EntityFrameworkCore;
using ProjetoFaculdade.Data;
using ProjetoFaculdade.Interface;
using ProjetoFaculdade.Models;

namespace ProjetoFaculdade.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly Context _context;

    public UsuarioRepository(Context context)
    {
        _context = context;
    }
    
    public async Task Registrar(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
    }
    
    public async Task<bool> UsuarioExiste(string email)
    {
        return await _context.Usuarios.AnyAsync(usuario => usuario.Email == email);
    }

    public async Task<Usuario> ObterUsuario(string email)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.Email == email);
    }

    public async Task<List<Usuario>> ObterListaUsuarios()
    {
        return await _context.Usuarios.ToListAsync();
    }
}