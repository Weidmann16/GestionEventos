using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace GestionEventos.Models.Models;

[Table("AsistentesEventos")]
public partial class AsistenteEvento
{
    [Key]
    public int IdAsistenteEvento { get; set; }
    public int IdEventoAsistenteEvento { get; set; }
    public int IdUsuarioAsistenteEvento { get; set; }
    public bool EstadoAsistenteEvento { get; set; }

    [ForeignKey("IdEventoAsistenteEvento")]
    public Evento? Evento { get; set; } = null;

    [ForeignKey("IdUsuarioAsistenteEvento")]
    public Usuario? Usuario { get; set; } = null;
}