using Azure.Core;
using GestionEventos.Data.Interfaces;
using GestionEventos.Models.Models;
using Microsoft.AspNetCore.Mvc;
namespace GestionEventos.API.Controllers;
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        [HttpPost("login")]
        public async Task<IActionResult> GetUsuarioLogin([FromBody] LoginUser loginUser)
        {
        // Valida que el request no sea nulo
        if (loginUser == null || string.IsNullOrEmpty(loginUser.NombreUsuarioLogin) || string.IsNullOrEmpty(loginUser.ContrasenaUsuarioLogin))
        {
            return BadRequest("Nombre de usuario y contraseña son requeridos.");
        }

        // Obtiene el usuario por el nombre de usuario
        var usuario = await _usuarioRepository.GetUsuarioLogin(loginUser);
        if (usuario == null)
        {
            return Unauthorized("Nombre de usuario o contraseña incorrectos.");
        }

        //Verifica que el usuario este activo
        if (!usuario.EstadoUsuario)
        {
            return Unauthorized("El usuario no se encuentra activo.");
        }

        //Verifica que la contraseña sea correcta
        if (!VerificarContraseña(loginUser.ContrasenaUsuarioLogin, usuario.ContrasenaUsuarioLogin))
        {
            return Unauthorized("Nombre de usuario o contraseña incorrectos.");
        }

        return Ok(new Usuario
        {
            IdUsuario = usuario.IdUsuario,
            NombreUsuario = usuario.NombreUsuario,
            ApellidoUsuario = usuario.ApellidoUsuario,
            EstadoUsuario = usuario.EstadoUsuario
        });
    }

    [HttpPost("registro")]
    public async Task<IActionResult> PostUsuarioRegistro([FromBody] Usuario usuario)
    {
        // Valida que el request no sea nulo
        if (usuario == null || 
            string.IsNullOrEmpty(usuario.NombreUsuario) || 
            string.IsNullOrEmpty(usuario.ApellidoUsuario) || 
            string.IsNullOrEmpty(usuario.NombreUsuarioLogin) || 
            string.IsNullOrEmpty(usuario.ContrasenaUsuarioLogin))
        {
            return BadRequest("Todos los campos son requeridos.");
        }

        // Valida que el usuario no exista
        var usuarioExistente = await _usuarioRepository.GetUsuarioById(usuario.IdUsuario);
        if (usuarioExistente != null)
        {
            return BadRequest("El nombre de usuario ya existe.");
        }

        //Valida que la contraseña tenga al maximo de 70 caracteres limite de BCrypt
        if (usuario.ContrasenaUsuarioLogin.Length > 70)
        {
            return BadRequest("La contraseña debe tener al maximo 70 caracteres.");
        }

        // Encripta la contraseña
        usuario.ContrasenaUsuarioLogin = EncriptarContraseña(usuario.ContrasenaUsuarioLogin);

        // Crea el usuario
        var usuarioCreado = await _usuarioRepository.PostUsuarioRegistro(usuario);
        if (usuarioCreado == null)
        {
            return BadRequest("Ocurrió un error al crear el usuario.");
        }
        return Ok(new Usuario
        {
            IdUsuario = usuarioCreado.IdUsuario,
            NombreUsuario = usuarioCreado.NombreUsuario,
            ApellidoUsuario = usuarioCreado.ApellidoUsuario,
            NombreUsuarioLogin = usuarioCreado.NombreUsuarioLogin
        });
    }

    // Verifica la contraseña
    private bool VerificarContraseña(string contraseña, string hashAlmacenado)
    {
        // Compara la contraseña con el hash almacenado
        return BCrypt.Net.BCrypt.Verify(contraseña, hashAlmacenado);
    }

    // Encripta la contraseña
    private string EncriptarContraseña(string contraseña)
    {
        // Encripta la contraseña
        return BCrypt.Net.BCrypt.HashPassword(contraseña);
    }
}
