using Mapster;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProyectoEasy.Aplicacion.Servicios;
using ProyectoEasy.Domain.Entities;
using ProyectoEasy.Servicios.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoEasy.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class MarcasController : ControllerBase
    {
        private readonly IMarcaServicio _marcaServicio;
       

        public MarcasController(IMarcaServicio marcaServicio)
        {
            _marcaServicio = marcaServicio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Marcas>>> Get()
        {
            try
            {
                var marcas = await _marcaServicio.Get();
                if (marcas != null)
                {
                    return Ok(marcas);
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
        public async Task<ActionResult<Marcas>> Get(int id)
        {
            try
            {
                var marca = await _marcaServicio.GetById(id);
                if (marca != null)
                {
                    return Ok(marca);
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
        public async Task<ActionResult<Marcas>> Post(Marcas m)
        {
            try
            {
                var marca = m.Adapt<Marcas>();
                var resultado = await _marcaServicio.Crear(marca);
                if (resultado != null)
                {
                    var respuesta = resultado.Adapt<MarcaDto>();
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
        public async Task<ActionResult> Put(MarcaDto m)
        {
            try
            {
                var marca = new Marcas
                {
                    Descripcion = m.Descripcion,
                };

                var resultado = await _marcaServicio.Actualizar(marca);

                if (resultado != null)
                {
                    return Ok(marca);
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
                await _marcaServicio.Eliminar(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



    }
}


