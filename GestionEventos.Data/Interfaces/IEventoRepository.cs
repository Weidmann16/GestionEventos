using GestionEventos.Models.Models;

namespace GestionEventos.Data.Interfaces;

public interface IEventoRepository
{
    Task<IEnumerable<Evento>> GetEventosExceptByIdUsuario(int idUsuario);
    Task<IEnumerable<Evento>> GetEventosByIdUsuario(int idUsuario);
    Task<Evento> GetEventoById(int idEvento);
    Task<Evento> AddEvento(Evento evento);
    Task<Evento> UpdateEvento(Evento evento);
    Task<Evento> DeleteEvento(int id);
}
