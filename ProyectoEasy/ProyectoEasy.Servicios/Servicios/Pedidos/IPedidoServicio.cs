using ProyectoEasy.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoEasy.Aplicacion.Servicios
{
    public interface IPedidoServicio
    {
        Task<Pedidos> Crear(Pedidos pedido);
        Task Eliminar(int id);
        Task<List<Pedidos>> Get();
        Task<Pedidos> GetById(int id);
    }
}