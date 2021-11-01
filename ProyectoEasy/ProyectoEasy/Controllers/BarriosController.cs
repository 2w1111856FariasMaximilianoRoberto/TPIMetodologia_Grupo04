using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoEasy.Aplicacion.Servicios;
using ProyectoEasy.Domain.Entities;
using ProyectoEasy.Infraestructura;
using ProyectoEasy.Servicios.Barrios.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoEasy.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class BarrioController : ControllerBase
    {
        private readonly IBarrioServicio _barrioServicio;

        public BarrioController(IBarrioServicio barrioServicio)
        {
            _barrioServicio = barrioServicio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Barrios>>> Get()
        {
            try
            {
                var barrios = await _barrioServicio.Get();

                if (barrios != null)
                {
                    return Ok(barrios);
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
        public async Task<ActionResult<Barrios>> Get(int id)
        {
            try
            {
                var barrio = await _barrioServicio.GetById(id);

                if (barrio != null)
                {
                    return Ok(barrio);
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
        public async Task<ActionResult<Barrios>> Post(BarrioDto b)
        {
            try
            {
                var barrio = b.Adapt<Barrios>();

                var resultado = await _barrioServicio.Crear(barrio);

                if (resultado != null)
                {
                    var respuesta = resultado.Adapt<BarrioDto>();
                    return Ok(barrio);
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
        public async Task<ActionResult> Put(BarrioDto b)
        {
            try
            {
                var barrio = new Barrios
                {
                    Descripcion = b.Descripcion,
                };

                var resultado = await _barrioServicio.Actualizar(barrio);

                if (resultado != null)
                {
                    return Ok(barrio);
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
                await _barrioServicio.Eliminar(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}


