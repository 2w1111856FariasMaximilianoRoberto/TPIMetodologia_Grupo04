using ProyectoEasy.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoEasy.Aplicacion.Servicios
{
    public interface IMarcaServicio
    {
        Task<Marcas> Crear(Marcas marca);

        Task<List<Marcas>> Get();

        Task<Marcas> GetById(int id);

        Task<Marcas> Actualizar(Marcas b);

        Task Eliminar(int id);

        Task<bool> ValidarNombreMarca(string nom);

    }
}