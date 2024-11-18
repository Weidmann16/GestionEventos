using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace GestionEventos.Models.Models;

[Table("Usuarios")]
public partial class Usuario
{
    [Key]
    public int IdUsuario { get; set; }
    public string NombreUsuarioLogin { get; set; } = null!;
    public string ContrasenaUsuarioLogin { get; set; } = null!;
    public string NombreUsuario { get; set; } = null!;
    public string ApellidoUsuario { get; set; } = null!;
    public bool EstadoUsuario { get; set; }
}