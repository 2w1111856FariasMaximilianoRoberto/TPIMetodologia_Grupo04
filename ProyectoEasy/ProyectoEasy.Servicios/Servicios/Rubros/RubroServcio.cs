using Microsoft.EntityFrameworkCore;
using ProyectoEasy.Domain.Entities;
using ProyectoEasy.Infraestructura;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoEasy.Aplicacion.Servicios
{
    public class RubroServicio : IRubroServicio
    {
        private readonly PedidosEasyContext _context;

        public RubroServicio(PedidosEasyContext pedidosEasyContext)
        {
            _context = pedidosEasyContext;
        }

        public async Task<Rubros> Crear(Rubros rubro)
        {
            if (rubro == null)
            {
                throw new NullReferenceException();
            }

             _context.Add(rubro);
            await _context.SaveChangesAsync();

            return rubro;
        }

        public async Task<List<Rubros>> Get()
        {
            var rubro = await _context.Rubros.ToListAsync();

            return rubro;
        }

        public async Task<Rubros> GetById(int id)
        {
            var rubro = await _context.Rubros.SingleOrDefaultAsync(t => t.IdRubro == id);

            return rubro;
        }

        public async Task<Rubros> Actualizar(Rubros r)
        {
            var rubro = await _context.Rubros.FirstOrDefaultAsync(x => x.IdRubro == r.IdRubro);
           
            if (rubro != null)
            {
                rubro.Descripcion = r.Descripcion;
                var resultado = await _context.SaveChangesAsync();
            }
            return rubro;
        }

        public async Task Eliminar(int id)
        {
            var rubro = await _context.Rubros.FirstOrDefaultAsync(x => x.IdRubro == id);

            if (rubro != null)
            {
                _context.Rubros.Remove(rubro);
                var resultado = await _context.SaveChangesAsync();

            }
        }

        public async Task<bool> ValidarNombreRubro(string nom)
        {
            if (await _context.Marcas.SingleOrDefaultAsync(p => p.Descripcion == nom) == null)
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
