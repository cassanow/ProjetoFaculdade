using Microsoft.EntityFrameworkCore;

namespace ProjetoFaculdade.Data;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
        
    }
}