using ProyectoEasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEasy.Aplicacion.Servicios
{
    public interface IFormaPagoServicio
    {
        Task<FormasPago> Crear(FormasPago formasPago);
        Task<List<FormasPago>> Get();
        Task<FormasPago> GetById(int id);
        Task<FormasPago> Actualizar(FormasPago formasPago);
        Task Eliminar(int id);
        Task<bool> Existe(string desc);
    }
}
