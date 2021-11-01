using Microsoft.EntityFrameworkCore;
using ProyectoEasy.Domain.Entities;
using ProyectoEasy.Infraestructura;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEasy.Aplicacion.Servicios
{
   public class RolServicio : IRolServicio
    {
        private readonly PedidosEasyContext _context;

        public RolServicio(PedidosEasyContext pedidosEasyContext)
        {
            _context = pedidosEasyContext;
        }

        public async Task<TipoRoles> Crear(TipoRoles tipo)
        {
            if (tipo == null)
            {
                throw new NullReferenceException();
            }

            _context.Add(tipo);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return tipo;
        }

        public async Task<List<TipoRoles>> Get()
        {
            var tipo = await _context.TipoRoles.ToListAsync();
            return tipo;
        }

        public async Task<TipoRoles> GetById(int id)
        {
            var tipo = await _context.TipoRoles.SingleOrDefaultAsync(t => t.IdTipoRol == id);
            return tipo;
        }

        public async Task<TipoRoles> Actualizar(TipoRoles t)
        {
            var tipo = await _context.TipoRoles.FirstOrDefaultAsync(x => x.IdTipoRol == t.IdTipoRol);
            if (tipo != null)
            {
                tipo.Descripcion =t.Descripcion;
                var resultado = await _context.SaveChangesAsync();
            }
            return tipo;
        }

        public async Task Eliminar(int id)
        {
            var tipo = await _context.TipoRoles.FirstOrDefaultAsync(x => x.IdTipoRol== id);

            if (tipo != null)
            {
                _context.TipoRoles.Remove(tipo);
                var resultado = await _context.SaveChangesAsync();
             }
        }

        public async Task<bool> ExisteNombreRol(string nom)
        {
            var tipo = await _context.TipoRoles.SingleOrDefaultAsync(p => p.Descripcion == nom);
            
            if (tipo != null)
            {    return true; }
            else
            {   return false;  }
        }
    }
}

