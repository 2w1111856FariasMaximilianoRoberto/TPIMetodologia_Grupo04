using Microsoft.EntityFrameworkCore;
using ProyectoEasy.Domain.Entities;
using ProyectoEasy.Infraestructura;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoEasy.Aplicacion.Servicios
{
    public class ProductoServicio : IProductoServicio
    {
        private readonly PedidosEasyContext _context;

        public ProductoServicio(PedidosEasyContext pedidosEasyContext)
        {
            _context = pedidosEasyContext;
        }

        public async Task<Productos> Crear(Productos producto)
        {
            if (producto == null)
            {
                throw new NullReferenceException();
            }


            _context.Add(producto);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

            return producto;
        }

        public async Task<List<Productos>> Get()
        {
            var productos = await _context.Productos.ToListAsync();

            return productos;
        }

        public async Task<Productos> GetById(int id)
        {
            var producto = await _context.Productos.SingleOrDefaultAsync(t => t.IdProducto == id);

            return producto;
        }

        public async Task<Productos> Actualizar(Productos p)
        {
            var producto = await _context.Productos.FirstOrDefaultAsync(x => x.IdProducto == p.IdProducto);
            if (producto != null)
            {

                producto.Descripcion = p.Descripcion;
                producto.Color = p.Color;
                producto.Dimenciones = p.Dimenciones;
                producto.Modelo = p.Modelo;
                producto.PrecioCompra = p.PrecioCompra;
                producto.PrecioVenta = p.PrecioVenta;
                producto.IdMarca = p.IdMarca;
                producto.IdRubro = p.IdRubro;
                producto.Stock = p.Stock;

                var resultado = await _context.SaveChangesAsync();
            }
            return producto;
        }

        public async Task Eliminar(int id)
        {
            var producto = await _context.Productos.FirstOrDefaultAsync(x => x.IdProducto == id);

            if (producto != null)
            {
                _context.Productos.Remove(producto);
                var resultado = await _context.SaveChangesAsync();

            }
        }
    }
}