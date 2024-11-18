using GestionEventos.Data.Interfaces;
using GestionEventos.Models.Data;
using GestionEventos.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionEventos.Data.Repositories;
public class EventoRepository : IEventoRepository
{
    private readonly GestionEventosContext _context;
    public EventoRepository(GestionEventosContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Evento>> GetEventosExceptByIdUsuario(int idUsuario)
    {
        try
        {
            var evento = await _context.Eventos
                .Include(x => x.Usuario)
                .Where(x => x.IdUsuarioEvento != idUsuario && x.EstadoEvento == true)
                .ToListAsync();

            //Eliminamos la contraseña del usuario
            foreach (var item in evento)
            {
                item.Usuario.ContrasenaUsuarioLogin = null;
            }

            //Agrego el numero de asistentes registrados a cada evento
            foreach (var item in evento)
            {
                item.AsistentesEvento = await _context.AsistentesEventos
                    .Where(x => x.IdEventoAsistenteEvento == item.IdEvento)
                    .CountAsync();
            }

            //Valido si el usuario esta inscrito
            foreach (var item in evento)
            {
                item.InscritoEvento = await _context.AsistentesEventos
                    .AnyAsync(x => x.IdEventoAsistenteEvento == item.IdEvento && x.IdUsuarioAsistenteEvento == idUsuario);
            }

            return evento;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<Evento>> GetEventosByIdUsuario(int idUsuario)
    {
        try
        {
            var evento = await _context.Eventos
                            .Include(x => x.Usuario)
                            .Where(x => x.IdUsuarioEvento == idUsuario)
                            .ToListAsync();

            //Eliminamos la contraseña del usuario
            foreach (var item in evento)
            {
                item.Usuario.ContrasenaUsuarioLogin = null;
            }

            //Agrego el numero de asistentes registrados a cada evento
            foreach (var item in evento)
            {
                item.AsistentesEvento = await _context.AsistentesEventos
                    .Where(x => x.IdEventoAsistenteEvento == item.IdEvento)
                    .CountAsync();
            }

            return evento;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Evento> GetEventoById(int idEvento)
    {
        try
        {
            var evento = await _context.Eventos.FindAsync(idEvento);
            if (evento == null)
            {
                throw new Exception("Evento no encontrado");
            }
            return evento;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Evento> AddEvento(Evento evento)
    {
        try
        {
            await _context.Eventos.AddAsync(evento);
            await _context.SaveChangesAsync();
            return evento;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task<Evento> DeleteEvento(int id)
    {
        try
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                throw new Exception("Evento no encontrado");
            }
            evento.EstadoEvento = false;
            _context.Eventos.Update(evento);
            await _context.SaveChangesAsync();
            return evento;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
   
    public async Task<Evento> UpdateEvento(Evento evento)
    {
        try
        {
            _context.Eventos.Update(evento);
            await _context.SaveChangesAsync();
            return evento;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
