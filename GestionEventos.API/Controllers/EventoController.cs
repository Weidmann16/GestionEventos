using GestionEventos.Data.Interfaces;
using GestionEventos.Models.Models;
using Microsoft.AspNetCore.Mvc;
namespace GestionEventos.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventoController : ControllerBase
{
    private readonly IEventoRepository _eventoRepository;
    private readonly IAsistenteEventoRepository _asistenteEventoRepository;
    public EventoController(IEventoRepository eventoRepository, IAsistenteEventoRepository asistenteEventoRepository)
    {
        _eventoRepository = eventoRepository;
        _asistenteEventoRepository = asistenteEventoRepository;
    }
    [HttpGet("GetEventosExceptByIdUsuario/{idUsuario}")]
    public async Task<IActionResult> GetEventosExceptByIdUsuario(int idUsuario)
    {
        try
        {
            var eventos = await _eventoRepository.GetEventosExceptByIdUsuario(idUsuario);
            return Ok(eventos);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetEventosByIdUsuario/{idUsuario}")]
    public async Task<IActionResult> GetEventosByIdUsuario(int idUsuario)
    {
        try
        {
            var eventos = await _eventoRepository.GetEventosByIdUsuario(idUsuario);
            return Ok(eventos);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{idEvento}")]
    public async Task<IActionResult> GetEventoById(int idEvento)
    {
        try
        {
            var evento = await _eventoRepository.GetEventoById(idEvento);
            return Ok(evento);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> AddEvento(Evento evento)
    {
        try
        {
            var newEvento = await _eventoRepository.AddEvento(evento);
            return Ok(newEvento);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut]
    public async Task<IActionResult> UpdateEvento(Evento evento)
    {
        try
        {
            //Validamos que la fecha no sea menor a la actual
            if (evento.FechaEvento < DateTime.Now)
            {
                return BadRequest("La fecha del evento no puede ser menor a la actual");
            }

            //Validamos que el la capacidad no sea menor a la cantidad de asistentes que ya tiene el evento
            var asistentes = await _asistenteEventoRepository.GetAsistentesEventoByIdEvento(evento.IdEvento);
            if (evento.CapacidadEvento < asistentes.Count())
            {
                return BadRequest("La capacidad del evento no puede ser menor a la cantidad de asistentes");
            }

            var updateEvento = await _eventoRepository.UpdateEvento(evento);
            return Ok(updateEvento);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("{idEvento}")]
    public async Task<IActionResult> DeleteEvento(int idEvento)
    {
        try
        {
            //Comprobamos si hay asistentes al evento
            var asistentes = await _asistenteEventoRepository.GetAsistentesEventoByIdEvento(idEvento);
            if (asistentes.Count() > 0)
            {
                return BadRequest("No se puede eliminar el evento, tiene asistentes");
            }
            
            var evento = await _eventoRepository.DeleteEvento(idEvento);
            return Ok(evento);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
