using ProyectoEasy.Domain.Entities;
using ProyectoEasy.Servicios.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoEasy.Aplicacion.Servicios
{
    public interface IClienteServicio
    {
        Task<Clientes> Crear(Clientes cliente);

        Task<List<Clientes>> Get();
        Task<List<ClienteListaDto>> GetDto();

        Task<Clientes> GetById(int id);

        Task<Clientes> Actualizar(Clientes c);

        Task Eliminar(int id);

        Task<bool> ExisteNombreUsuario(string nom);
        Task<ClienteSesionDto> Login(LoginClienteDto login);
    }
}