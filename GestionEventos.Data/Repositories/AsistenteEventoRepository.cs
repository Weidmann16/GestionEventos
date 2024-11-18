using GestionEventos.Data.Interfaces;
using GestionEventos.Models.Data;
using GestionEventos.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionEventos.Data.Repositories;
public class AsistenteEventoRepository : IAsistenteEventoRepository
{
    private readonly GestionEventosContext _context;
    public AsistenteEventoRepository(GestionEventosContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<AsistenteEvento>> GetAsistentesEventoByIdEvento(int idEvento)
    {
        try
        {
            var asistenteEvento = await _context.AsistentesEventos
                            .Where(x => x.IdEventoAsistenteEvento == idEvento)
                            .ToListAsync();
            return asistenteEvento;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task<IEnumerable<AsistenteEvento>> GetAsistentesEventoByIdUsuario(int idUsuario)
    {
        try
        {
            var asistenteEvento = await _context.AsistentesEventos
                            .Include(x => x.Evento)
                            .Where(x => x.IdUsuarioAsistenteEvento == idUsuario)
                            .ToListAsync();
            return asistenteEvento;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task<AsistenteEvento> AddAsistenteEvento(AsistenteEvento asistenteEvento)
    {
        try
        {
            await _context.AsistentesEventos.AddAsync(asistenteEvento);
            await _context.SaveChangesAsync();
            return asistenteEvento;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task<AsistenteEvento> UpdateAsistenteEvento(AsistenteEvento asistenteEvento)
    {
        try
        {
            _context.AsistentesEventos.Update(asistenteEvento);
            await _context.SaveChangesAsync();
            return asistenteEvento;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task DeleteAsistenteEvento(int id)
    {
        try
        {
            var asistenteEvento = await _context.AsistentesEventos.FindAsync(id);
            if (asistenteEvento == null)
            {
                throw new Exception("Asistente no encontrado");
            }
            asistenteEvento.EstadoAsistenteEvento = false;
            _context.AsistentesEventos.Update(asistenteEvento);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
