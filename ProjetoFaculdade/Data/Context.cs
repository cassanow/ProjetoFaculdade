using Microsoft.EntityFrameworkCore;
using ProjetoFaculdade.Models;

namespace ProjetoFaculdade.Data;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
        
    }
    
    public DbSet<Usuario> Usuarios { get; set; }
}