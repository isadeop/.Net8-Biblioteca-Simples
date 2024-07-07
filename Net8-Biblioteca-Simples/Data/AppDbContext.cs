using Microsoft.EntityFrameworkCore;
using Net8_Biblioteca_Simples.Models;

namespace Net8_Biblioteca_Simples.Data;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<AutorModel> Autores { get; set; }
    public DbSet<LivroModel> Livros { get; set; }


}
