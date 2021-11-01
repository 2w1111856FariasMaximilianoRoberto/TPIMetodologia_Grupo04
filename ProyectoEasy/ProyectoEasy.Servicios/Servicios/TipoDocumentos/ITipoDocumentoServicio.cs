using ProyectoEasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEasy.Aplicacion.Servicios
{
   public interface ITipoDocumentoServicio
    {
        Task<TipoDocumentos> Crear(TipoDocumentos cliente);

        Task<List<TipoDocumentos>> Get();

        Task<TipoDocumentos> GetById(int id);

        Task<TipoDocumentos> Actualizar(TipoDocumentos c);

        Task Eliminar(int id);

        Task<bool> ExisteNombreTipoDocuemento(string nom);

    }
}
