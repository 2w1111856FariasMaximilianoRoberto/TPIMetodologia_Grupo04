using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoEasy.Aplicacion.Dtos;
using ProyectoEasy.Aplicacion.Servicios;
using ProyectoEasy.Domain.Entities;
using ProyectoEasy.Infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoEasy.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PedidosController : ControllerBase
    {
        private readonly IPedidoServicio _pedidoServicio;
        private readonly PedidosEasyContext _context;
        public PedidosController(IPedidoServicio pedidoServicio, PedidosEasyContext context)
        {
            _pedidoServicio = pedidoServicio;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidoDto>>> Get()
        {
            try
            {
                var pedidos = await _pedidoServicio.Get();

                if (pedidos != null)
                {
                    var respuesta = pedidos.Adapt<PedidoDto>();

                    return Ok(respuesta);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{fecha1},{fecha2}")]
        public async Task<ActionResult<double>> GetReporteTotalPorFecha(DateTime fecha1, DateTime fecha2)
        {
            try
            {
                var reporte = await _context.Pedidos.Where(x => x.Fecha >= fecha1 && x.Fecha <= fecha2).ToListAsync();
                var detalles = await _context.DetallePedidos.ToListAsync();

                double total = 0;

                foreach (var x in reporte)
                {
                    foreach (var i in detalles)
                    {
                        if (x.IdPedido == i.IdPedido)
                        {
                            total += i.Cantidad * i.PrecioUnitario;
                        }
                    }
                }
                return total;

                //if (pedidos != null)
                //{
                //    var respuesta = pedidos.Adapt<PedidoDto>();

                //    return Ok(respuesta);
                //}
                //else
                //{
                //    return BadRequest();
                //}
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Pedidos>> Get(int id)
        {
            try
            {
                var pedido = await _pedidoServicio.GetById(id);
                if (pedido != null)
                {
                    return Ok(pedido);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        //A este metodo por ahora queda asi pero seguramente lo modifiquemos para agregar tmb los detalles
        [HttpPost]
        public async Task<ActionResult<PedidoDto>> Post(PedidoDto p)
        {
            try
            {
                var pedido = p.Adapt<Pedidos>();

                var resultado = await _pedidoServicio.Crear(pedido);

                if (resultado != null)
                {
                    var respuesta = resultado.Adapt<PedidoDto>();
                    return Ok(respuesta);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Pedidos>> Delete(int id)
        {
            try
            {
                await _pedidoServicio.Eliminar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}


