using GestionEventos.Data.Interfaces;
using GestionEventos.Models.Models;
using Microsoft.AspNetCore.Mvc;
namespace GestionEventos.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AsistenteEventoController : ControllerBase
{
    private readonly IAsistenteEventoRepository _asistenteEventoRepository;
    private readonly IEventoRepository _eventoRepository;

    public AsistenteEventoController(IAsistenteEventoRepository asistenteEventoRepository, IEventoRepository eventoRepository)
    {
        _asistenteEventoRepository = asistenteEventoRepository;
        _eventoRepository = eventoRepository;
    }
    [HttpGet("GetAsistentesEventoByIdEvento/{idEvento}")]
    public async Task<IActionResult> GetAsistentesEventoByIdEvento(int idEvento)
    {
        try
        {
            var asistentesEvento = await _asistenteEventoRepository.GetAsistentesEventoByIdEvento(idEvento);
            return Ok(asistentesEvento);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("GetAsistentesEventoByIdUsuario/{idUsuario}")]
    public async Task<IActionResult> GetAsistentesEventoByIdUsuario(int idUsuario)
    {
        try
        {
            var asistentesEvento = await _asistenteEventoRepository.GetAsistentesEventoByIdUsuario(idUsuario);
            return Ok(asistentesEvento);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost("AddAsistenteEvento")]
    public async Task<IActionResult> AddAsistenteEvento(AsistenteEvento asistenteEvento)
    {
        try
        {
            //Valido que el usuario no este registrado en mas de 3 eventos
            var asistentesEvento = await _asistenteEventoRepository.GetAsistentesEventoByIdUsuario(asistenteEvento.IdUsuarioAsistenteEvento);

            if (asistentesEvento.Count() >= 3)
            {
                return BadRequest("El usuario ya se encuentra registrado en 3 eventos");
            }

            //Validar que el usuario no se registre en el mismo evento
            var asistenteEventoExistente = asistentesEvento.FirstOrDefault(x => x.IdEventoAsistenteEvento == asistenteEvento.IdEventoAsistenteEvento);
            if (asistenteEventoExistente != null)
            {
                return BadRequest("El usuario ya se encuentra registrado en este evento");
            }

            //Validar que el evento no haya pasado de cantidad de asistentes
            var evento = await _eventoRepository.GetEventoById(asistenteEvento.IdEventoAsistenteEvento);
            if (evento.CapacidadEvento <= asistentesEvento.Count())
            {
                return BadRequest("El evento ya ha alcanzado la cantidad de asistentes permitidos");
            }

            var newAsistenteEvento = await _asistenteEventoRepository.AddAsistenteEvento(asistenteEvento);
            return Ok(newAsistenteEvento);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("UpdateAsistenteEvento")]
    public async Task<IActionResult> UpdateAsistenteEvento(AsistenteEvento asistenteEvento)
    {
        try
        {
            var updateAsistenteEvento = await _asistenteEventoRepository.UpdateAsistenteEvento(asistenteEvento);
            return Ok(updateAsistenteEvento);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("DeleteAsistenteEvento/{id}")]
    public async Task<IActionResult> DeleteAsistenteEvento(int id)
    {
        try
        {
            await _asistenteEventoRepository.DeleteAsistenteEvento(id);
            return Ok("AsistenteEvento eliminado");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
