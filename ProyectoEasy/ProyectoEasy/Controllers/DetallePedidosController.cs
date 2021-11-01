using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoEasy.Domain.Entities;
using ProyectoEasy.Infraestructura;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoEasy.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class DetallePedidosController : ControllerBase
    {
        private readonly PedidosEasyContext context;
        public DetallePedidosController(PedidosEasyContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<List<DetallePedidos>>> Get()
        {
            try
            {
                var detalles = await context.DetallePedidos.ToListAsync();
                if (detalles != null)
                {
                    return Ok(detalles);
                }
                else
                {
                    return NoContent();
                }
                 
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<DetallePedidos>> Get(int id)
        {
            try
            {
                var detalle = await context.DetallePedidos.FirstOrDefaultAsync(x => x.IdDetallePedido == id);
                if (detalle != null)
                {
                    return Ok(detalle);
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


        //Este metodo post por ahora lo dejo pero no se si lo vamos a necesitar porque al cargar el pedido, tmb debemos cargar el detalle en el mismo metodo.
        [HttpPost]
        public async Task<ActionResult<DetallePedidos>> Post(DetallePedidos d)
        {
            try
            {
                var detalle = new DetallePedidos
                {
                    Descripcion = d.Descripcion,
                    Cantidad = d.Cantidad,
                    PrecioUnitario = d.PrecioUnitario,
                    IdProducto = d.IdProducto,
                    IdPedido = d.IdPedido,

                };
                context.DetallePedidos.Add(detalle);
                await context.SaveChangesAsync();
                return Ok(detalle);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, DetallePedidos d)
        {
            try
            {
                var detalle = await context.DetallePedidos.FirstOrDefaultAsync(x => x.IdDetallePedido == id);
                if (detalle != null)
                {
                    detalle.Descripcion = d.Descripcion;
                    detalle.Cantidad = d.Cantidad;
                    detalle.PrecioUnitario = d.PrecioUnitario;
                    detalle.IdProducto = d.IdProducto;
                    detalle.IdPedido = d.IdPedido;

                    context.DetallePedidos.Update(detalle);
                    await context.SaveChangesAsync();
                    return Ok(detalle);
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
        public async Task<ActionResult<DetallePedidos>> Delete(int id)
        {
            try
            {
                var detalle = await context.DetallePedidos.FirstOrDefaultAsync(x => x.IdDetallePedido == id);
                if (detalle != null)
                {
                    context.DetallePedidos.Remove(detalle);
                    var resultado = await context.SaveChangesAsync();
                    if (resultado > 0)
                    {
                        return Ok(await context.DetallePedidos.ToListAsync());
                    }
                    else
                    {
                        return BadRequest();
                    } 
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
    }
}