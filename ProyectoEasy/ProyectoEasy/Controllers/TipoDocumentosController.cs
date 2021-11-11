using Mapster;
using Microsoft.AspNetCore.Cors;
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
    [EnableCors("easy")]

    public class TipoDocuentosController : ControllerBase
    {
        private readonly ITipoDocumentoServicio _tipoDocuentoServicio;


        public TipoDocuentosController(ITipoDocumentoServicio tipoDocuentoServicio)
        {
            _tipoDocuentoServicio = tipoDocuentoServicio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoDocumentos>>> Get()
        {
            try
            {
                var tiposDoc = await _tipoDocuentoServicio.Get();

                if (tiposDoc != null)
                {
                    return Ok(tiposDoc);
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
        public async Task<ActionResult<TipoDocumentos>> Get(int id)
        {
            try
            {
                var tipo = await _tipoDocuentoServicio.GetById(id);

                if (tipo != null)
                {
                    return Ok(tipo);
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
        public async Task<ActionResult<TipoDto>> Post(TipoDto t)
        {
            try
            {
                var tipo = t.Adapt<TipoDocumentos>();
                var resultado = await _tipoDocuentoServicio.Crear(tipo);

                if (resultado != null)
                {
                    var respuesta = resultado.Adapt<TipoDto>();
                    return Ok(tipo);
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
        public async Task<ActionResult> Put(TipoDto t)
        {
            try
            {
                var tipo = new TipoDocumentos
                {

                    Descripcion = t.Descripcion,
                };

                var resultado = await _tipoDocuentoServicio.Actualizar(tipo);

                if (resultado != null)
                {

                    return Ok(tipo);
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
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _tipoDocuentoServicio.Eliminar(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


    }
}


