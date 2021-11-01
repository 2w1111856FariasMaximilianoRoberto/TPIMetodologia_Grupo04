using ProyectoEasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEasy.Aplicacion.Servicios
{
   public interface IRolServicio
    {
        Task<TipoRoles> Crear(TipoRoles tipo);

        Task<List<TipoRoles>> Get();

        Task<TipoRoles> GetById(int id);

        Task<TipoRoles> Actualizar(TipoRoles t);

        Task Eliminar(int id);

        Task<bool> ExisteNombreRol(string nom);
    }
}
