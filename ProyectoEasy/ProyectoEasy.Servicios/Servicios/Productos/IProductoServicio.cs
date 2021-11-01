using ProyectoEasy.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoEasy.Aplicacion.Servicios
{
    public interface IProductoServicio
    {
        Task<Productos> Crear(Productos producto);

        Task<List<Productos>> Get();

        Task<Productos> GetById(int id);

        Task<Productos> Actualizar(Productos p);

        Task Eliminar(int id);

        
    }
}