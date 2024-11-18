using GestionEventos.Data.Interfaces;
using GestionEventos.Models.Data;
using GestionEventos.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionEventos.Data.Repositories;
public class UsuarioRepository : IUsuarioRepository
{
    private readonly GestionEventosContext _context;
    public UsuarioRepository(GestionEventosContext context)
    {
        _context = context;
    }
    public async Task<Usuario?> GetUsuarioLogin(LoginUser loginUser)
    {
        try
        {
            //Busca el usuario por nombre de usuario
            var user = await _context.Usuarios
                            .FirstOrDefaultAsync(x => x.NombreUsuarioLogin == loginUser.NombreUsuarioLogin);

            return user;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Usuario?> GetUsuarioById(int idUsuario)
    {
        try
        {
            //Busca el usuario por id
            var user = await _context.Usuarios
                            .FirstOrDefaultAsync(x => x.IdUsuario == idUsuario);
            return user;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Usuario?> PostUsuarioRegistro(Usuario usuario)
    {
        try
        {
            //Agrega el usuario
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
