using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoEasy.Aplicacion.Servicios.Dtos;
using ProyectoEasy.Domain.Entities;
using ProyectoEasy.Servicios.Dtos;

namespace ProyectoEasy.Aplicacion.Servicios
{
    public interface IUsuarioServicio
    {
        Task<Usuarios> Crear(Usuarios usuario);
        Task<List<Usuarios>> Get();
        Task<List<UsuarioListadoDto>> GetDto();
        Task<Usuarios> GetById(int id);
        Task<Usuarios> Actualizar(Usuarios u);
        Task Eliminar(int id);
        Task<bool> ExisteNombreUsuario(string nomUsu);
        Task<bool> ExisteEmail(string email);

        Task<UsuarioSesionDto> Login(LoginUsuarioDto login);
    }
}
