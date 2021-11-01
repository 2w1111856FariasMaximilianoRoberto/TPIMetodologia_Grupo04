using Microsoft.EntityFrameworkCore;
using ProyectoEasy.Domain.Entities;
using ProyectoEasy.Infraestructura;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoEasy.Aplicacion.Servicios
{
    public class MarcaServicio : IMarcaServicio
    {
        private readonly PedidosEasyContext _context;

        public MarcaServicio(PedidosEasyContext pedidosEasyContext)
        {
            _context = pedidosEasyContext;
        }

        public async Task<Marcas> Crear(Marcas marca)
        {
            if (marca == null)
            {
                throw new NullReferenceException();
            }


            _context.Add(marca);
            await _context.SaveChangesAsync();

            return marca;
        }

        public async Task<List<Marcas>> Get()
        {
            var marca = await _context.Marcas.ToListAsync();

            return marca;
        }

        public async Task<Marcas> GetById(int id)
        {
            var marca = await _context.Marcas.SingleOrDefaultAsync(t => t.IdMarca == id);

            return marca;
        }

        public async Task<Marcas> Actualizar(Marcas m)
        {
            var marca = await _context.Marcas.FirstOrDefaultAsync(x => x.IdMarca == m.IdMarca);
            if (marca != null)
            {
                marca.Descripcion = m.Descripcion;
                var resultado = await _context.SaveChangesAsync();
            }
            return marca;
        }

        public async Task Eliminar(int id)
        {
            var marca = await _context.Marcas.FirstOrDefaultAsync(x => x.IdMarca == id);

            if (marca != null)
            {
                _context.Marcas.Remove(marca);
                var resultado = await _context.SaveChangesAsync();

            }
        }

        public async Task<bool> ValidarNombreMarca(string nom)
        {
            if ( await _context.Marcas.SingleOrDefaultAsync(p => p.Descripcion == nom) == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
