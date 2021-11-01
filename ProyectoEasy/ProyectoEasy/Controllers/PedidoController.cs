using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoEasy.Aplicacion.Dtos;
using ProyectoEasy.Aplicacion.Servicios;
using ProyectoEasy.Domain.Entities;
using ProyectoEasy.Infraestructura;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoEasy.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PedidosController : ControllerBase
    {
        private readonly IPedidoServicio _pedidoServicio;
        public PedidosController(IPedidoServicio pedidoServicio)
        {
            _pedidoServicio = pedidoServicio;
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


