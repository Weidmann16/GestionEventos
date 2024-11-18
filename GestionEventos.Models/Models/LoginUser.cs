using System.ComponentModel.DataAnnotations.Schema;
namespace GestionEventos.Models.Models;
[NotMapped]
public partial class LoginUser
{
    public string NombreUsuarioLogin { get; set; } = null!;
    public string ContrasenaUsuarioLogin { get; set; } = null!;
}