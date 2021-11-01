using Microsoft.EntityFrameworkCore;
using ProyectoEasy.Domain.Entities;
using ProyectoEasy.Infraestructura;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEasy.Aplicacion.Servicios
{
    public class TipoDocumentoServicio : ITipoDocumentoServicio
    {
        private readonly PedidosEasyContext _context;

        public TipoDocumentoServicio(PedidosEasyContext pedidosEasyContext)
        {
            _context = pedidosEasyContext;
        }

        public async Task<TipoDocumentos> Crear(TipoDocumentos tipo)
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

        public async Task<List<TipoDocumentos>> Get()
        {
            var tipo = await _context.TipoDocumentos.ToListAsync();

            return tipo;
        }

        public async Task<TipoDocumentos> GetById(int id)
        {
            var tipo = await _context.TipoDocumentos.SingleOrDefaultAsync(t => t.IdTipoDocumento == id);

            return tipo;
        }

        public async Task<TipoDocumentos> Actualizar(TipoDocumentos t)
        {
            var tipo = await _context.TipoDocumentos.FirstOrDefaultAsync(x => x.IdTipoDocumento == t.IdTipoDocumento);
            if (tipo != null)
            {
                tipo.Descripcion = t.Descripcion;
                
                var resultado = await _context.SaveChangesAsync();
            }
            return tipo;
        }

        public async Task Eliminar(int id)
        {
            var tipo = await _context.TipoDocumentos.FirstOrDefaultAsync(x => x.IdTipoDocumento == id);

            if (tipo != null)
            {
                _context.TipoDocumentos.Remove(tipo);
                var resultado = await _context.SaveChangesAsync();

            }
        }

        public async Task<bool> ExisteNombreTipoDocuemento(string nom)
        {
            var tipo = await _context.TipoDocumentos.SingleOrDefaultAsync(p => p.Descripcion == nom);
            if (tipo != null)
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

