using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace GestionEventos.Models.Models;

[Table("Eventos")]
public partial class Evento
{
    [Key]
    public int IdEvento { get; set; }
    public string NombreEvento { get; set; } = null!;
    public string DescripcionEvento { get; set; } = null!;
    public DateTime FechaEvento { get; set; } = DateTime.Now;
    public string UbicacionEvento { get; set; } = null!;
    public int CapacidadEvento { get; set; }
    public bool EstadoEvento { get; set; }
    public int IdUsuarioEvento { get; set; }

    [NotMapped]
    public int AsistentesEvento { get; set; }

    [NotMapped]
    public bool InscritoEvento { get; set; }

    [ForeignKey("IdUsuarioEvento")]
    public Usuario? Usuario { get; set; } = null;
}
