using Microsoft.EntityFrameworkCore;
using ProyectoEasy.Domain.Entities;
using ProyectoEasy.Infraestructura;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEasy.Aplicacion.Servicios.FormasDePago
{
    public class FormaPagoServicio : IFormaPagoServicio
    {
        private readonly PedidosEasyContext _context;
        public FormaPagoServicio(PedidosEasyContext context)
        {
            _context = context;
        }

        public async Task<FormasPago> Crear(FormasPago formasPago)
        {
            if (formasPago == null)
            {
                throw new NullReferenceException();
            }
            _context.Add(formasPago);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return formasPago;
        }

        public async Task<List<FormasPago>> Get()
        {
            var formasPago = await _context.FormasPago.ToListAsync();
            if (formasPago == null)
            {
                throw new NullReferenceException();
            }
            return formasPago;
        }

        public async Task<FormasPago> GetById(int id)
        {
            var formaPago = await _context.FormasPago.SingleOrDefaultAsync(x => x.IdFormaPago == id);

            if (formaPago == null)
            {
                throw new NullReferenceException();
            }
            return formaPago;
        }
        public async Task<FormasPago> Actualizar(FormasPago formasPago)
        {
            var formaPago = await _context.FormasPago.FirstOrDefaultAsync(x => x.IdFormaPago == formasPago.IdFormaPago);

            if (formaPago != null)
            {
                formaPago.Descripcion = formasPago.Descripcion;

                var resultado = await _context.SaveChangesAsync();
            }
            return formaPago;
        }

        

        public async Task Eliminar(int id)
        {
            var formaPago = await _context.FormasPago.SingleOrDefaultAsync(x => x.IdFormaPago == id);
            if (formaPago != null)
            {
                _context.FormasPago.Remove(formaPago);
                var resultado = _context.SaveChangesAsync();
            }
        }

        public async Task<bool> Existe(string desc)
        {
            var formaPago = await _context.FormasPago.SingleOrDefaultAsync(x => x.Descripcion == desc);
            if (formaPago != null)
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
