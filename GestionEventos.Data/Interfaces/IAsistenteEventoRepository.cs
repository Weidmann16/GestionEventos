using GestionEventos.Models.Models;

namespace GestionEventos.Data.Interfaces;

public interface IAsistenteEventoRepository
{
    Task<IEnumerable<AsistenteEvento>> GetAsistentesEventoByIdEvento(int idEvento);
    Task<IEnumerable<AsistenteEvento>> GetAsistentesEventoByIdUsuario(int idUsuario);
    Task<AsistenteEvento> AddAsistenteEvento(AsistenteEvento asistenteEvento);
    Task<AsistenteEvento> UpdateAsistenteEvento(AsistenteEvento asistenteEvento);
    Task DeleteAsistenteEvento(int id);
}
