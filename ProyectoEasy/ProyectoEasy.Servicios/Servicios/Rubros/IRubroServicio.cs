using ProyectoEasy.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoEasy.Aplicacion.Servicios
{
    public interface IRubroServicio
    {
        Task<Rubros> Crear(Rubros rubro);

        Task<List<Rubros>> Get();

        Task<Rubros> GetById(int id);

        Task<Rubros> Actualizar(Rubros b);

        Task Eliminar(int id);

        Task<bool> ValidarNombreRubro(string nom);
    }
}
