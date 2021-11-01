using Microsoft.EntityFrameworkCore;
using ProyectoEasy.Domain.Entities;
using ProyectoEasy.Infraestructura;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoEasy.Aplicacion.Servicios
{
    public class PedidoServicio : IPedidoServicio
    {
        private readonly PedidosEasyContext _context;

        public PedidoServicio(PedidosEasyContext pedidosEasyContext)
        {
            _context = pedidosEasyContext;
        }

        public async Task<Pedidos> Crear(Pedidos pedido)
        {
            if (pedido == null)
            {
                throw new NullReferenceException();
            }

            foreach (var detalle in pedido.DetallePedidos)
            {
                var producto = await _context.Productos.SingleOrDefaultAsync(t => t.IdProducto == detalle.IdProducto);
                detalle.Descripcion = producto.Descripcion;
            }

            _context.Add(pedido);

            await _context.SaveChangesAsync();

            return pedido;
        }

        public async Task<List<Pedidos>> Get()
        {
            var pedidos = await _context.Pedidos.Include(t => t.DetallePedidos).ToListAsync();

            return pedidos;
        }

        public async Task<Pedidos> GetById(int id)
        {
            var pedido = await _context.Pedidos.SingleOrDefaultAsync(t => t.IdPedido == id);

            return pedido;
        }

        public async Task Eliminar(int id)
        {
            var pedido = await _context.Pedidos.FirstOrDefaultAsync(x => x.IdPedido == id);

            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
                var resultado = await _context.SaveChangesAsync();
            }
        }
    }
}
