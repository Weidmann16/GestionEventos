using GestionEventos.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionEventos.Models.Data;

public partial class GestionEventosContext : DbContext
{
    public GestionEventosContext()
    {
    }
    public GestionEventosContext(DbContextOptions<GestionEventosContext> options)
        : base(options)
    {
    }
    public virtual DbSet<AsistenteEvento> AsistentesEventos { get; set; } = null!;
    public virtual DbSet<Evento> Eventos { get; set; } = null!;
    public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}