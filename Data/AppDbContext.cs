using Microsoft.EntityFrameworkCore;
using WebApi_Livro.Models;

namespace WebApi_Livro.Data;

public class AppDbContext : DbContext //DbContext pertence ao EntityFrameworkCore
{
    //DbContextOpttions siginifica que voce esta passando as opções para o Contexto
    //Qual Server ou banco ele vai se conectar
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<AutorModel> Autores { get; set; }
    public DbSet<LivrosModel> Livros { get; set; }
}
