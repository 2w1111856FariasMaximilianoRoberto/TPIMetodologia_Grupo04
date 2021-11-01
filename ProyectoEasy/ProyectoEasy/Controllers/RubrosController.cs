using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoEasy.Aplicacion.Servicios;
using ProyectoEasy.Aplicacion.Servicios.Dtos;
using ProyectoEasy.Domain.Entities;
using ProyectoEasy.Infraestructura;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoEasy.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class RubroController : ControllerBase
    {
        private readonly IRubroServicio _rubroServicio;
        public RubroController(IRubroServicio rubroServicio)
        {
            _rubroServicio= rubroServicio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Rubros>>> Get()
        {
            try
            {
                var rubros = await _rubroServicio.Get();

                if (rubros != null)
                {
                    return Ok(rubros);
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
        public async Task<ActionResult<Rubros>> Get(int id)
        {
            try
            {
                var rubro = await _rubroServicio.GetById(id);

                if (rubro != null)
                {
                    return Ok(rubro);
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
        public async Task<ActionResult<Rubros>> Post(RubroDto r)
        {
            try
            {
                var rubro = r.Adapt<Rubros>();

                var resultado = await _rubroServicio.Crear(rubro);

                if (resultado != null)
                {
                    var respuesta = resultado.Adapt<RubroDto>();
                    return Ok(rubro);
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
        public async Task<ActionResult> Put(RubroDto r)
        {
            try
            {
                var rubro = new Rubros{

                Descripcion = r.Descripcion,
                };

                var resultado = await _rubroServicio.Actualizar(rubro);

                 if (resultado != null){

                   return Ok(rubro);
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
                await _rubroServicio.Eliminar(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



    }
}


