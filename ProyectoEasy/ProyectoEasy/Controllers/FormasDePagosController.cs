using Mapster;
using Microsoft.AspNetCore.Mvc;
using ProyectoEasy.Aplicacion.Servicios;
using ProyectoEasy.Aplicacion.Servicios.Dtos;
using ProyectoEasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoEasy.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class FormasDePagoController : ControllerBase
    {
        private readonly IFormaPagoServicio _formaPagoServicio;
        public FormasDePagoController(IFormaPagoServicio formaPagoServicio)
        {
            _formaPagoServicio = formaPagoServicio;
        }

        [HttpGet]
        public async Task<ActionResult<List<FormasPago>>> Get()
        {
            try
            {
                var FormasPago = await _formaPagoServicio.Get();
                if (FormasPago != null)
                {
                    return Ok(FormasPago);
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
        public async Task<ActionResult<FormasPago>> Get(int id)
        {
            try
            {
                var formaPago = await _formaPagoServicio.GetById(id);
                if (formaPago != null)
                {
                    return Ok(formaPago);
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



        [HttpPost]
        public async Task<ActionResult<FormasPago>> Post(FormasPagoDto pagos)
        {
            try
            {
                var forma = pagos.Adapt<FormasPago>();

                var resultado = await _formaPagoServicio.Crear(forma);

                if (resultado != null)
                {
                    var respuesta = resultado.Adapt<FormasPagoDto>();
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



        [HttpPut("{id}")]
        public async Task<ActionResult> Put(FormasPagoDto pago)
        {
            try
            {
                var forma = new FormasPago
                {
                    Descripcion = pago.Descripcion
                };

                var resultado = await _formaPagoServicio.Actualizar(forma);

                if (resultado != null)
                {
                    return Ok(forma);
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
        public async Task<ActionResult<FormasPago>> Delete(int id)
        {
            try
            {
                await _formaPagoServicio.Eliminar(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



    }
}


