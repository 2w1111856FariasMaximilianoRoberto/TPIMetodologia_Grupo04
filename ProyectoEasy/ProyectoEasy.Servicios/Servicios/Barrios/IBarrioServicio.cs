using ProyectoEasy.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoEasy.Aplicacion.Servicios
{
    public interface IBarrioServicio
    {
        Task<Barrios> Crear(Barrios barrio);

        Task<List<Barrios>> Get();

        Task<Barrios> GetById(int id);

        Task<Barrios> Actualizar(Barrios b);

        Task Eliminar(int id);

        Task<bool> ValidarNombreBarrio(string nom);
    }
}