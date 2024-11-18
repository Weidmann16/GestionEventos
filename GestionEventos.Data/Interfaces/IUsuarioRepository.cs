using GestionEventos.Models.Models;
namespace GestionEventos.Data.Interfaces;
public interface IUsuarioRepository
{
    Task<Usuario?> GetUsuarioLogin(LoginUser loginUser);
    Task<Usuario?> GetUsuarioById(int idUsuario);
    Task<Usuario?> PostUsuarioRegistro(Usuario usuario);
}