using Microsoft.EntityFrameworkCore;
using ProyectoEasy.Domain.Entities;
using ProyectoEasy.Infraestructura;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoEasy.Aplicacion.Servicios
{

    public class BarrioServicio : IBarrioServicio
    {
        private readonly PedidosEasyContext _context;

        public BarrioServicio(PedidosEasyContext pedidosEasyContext)
        {
            _context = pedidosEasyContext;
        }

        public async Task<Barrios> Crear(Barrios barrio)
        {
            if (barrio == null)
            {
                throw new NullReferenceException();
            }


            _context.Add(barrio);
            await _context.SaveChangesAsync();

            return barrio;
        }

        public async Task<List<Barrios>> Get()
        {
            var barrios = await _context.Barrios.ToListAsync();

            return barrios;
        }

        public async Task<Barrios> GetById(int id)
        {
            var barrio = await _context.Barrios.SingleOrDefaultAsync(t => t.IdBarrio == id);

            return barrio;
        }

        public async Task<Barrios> Actualizar(Barrios b)
        {
            var barrio = await _context.Barrios.FirstOrDefaultAsync(x => x.IdBarrio == b.IdBarrio);
            if (barrio != null)
            {
                barrio.Descripcion = b.Descripcion;
                var resultado = await _context.SaveChangesAsync();
            }
            return barrio;
        }

        public async Task Eliminar(int id)
        {
            var barrio = await _context.Barrios.FirstOrDefaultAsync(x => x.IdBarrio == id);

            if (barrio != null)
            {
                _context.Barrios.Remove(barrio);
                var resultado = await _context.SaveChangesAsync();

            }
        }

        public async Task<bool> ValidarNombreBarrio(string nom)
        {
            if (await _context.Barrios.SingleOrDefaultAsync(p => p.Descripcion == nom) == null)
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

