using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoEasy.Aplicacion.Servicios;
using ProyectoEasy.Domain.Entities;
using ProyectoEasy.Infraestructura;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoEasy.Aplicacion.Servicios.Dtos;
using Mapster;
using ProyectoEasy.Servicios.Dtos;

namespace ProyectoEasy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("easy")]

    public class TipoRolesController : ControllerBase
    {
        private readonly IRolServicio _tipoRolServicio;


        public TipoRolesController(IRolServicio tipoRolServicio)
        {
            _tipoRolServicio = tipoRolServicio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoRoles>>> Get()
        {
            try
            {
                var tipoRol = await _tipoRolServicio.Get();

                if (tipoRol != null)
                {
                    return Ok(tipoRol);
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
        public async Task<ActionResult<TipoRoles>> Get(int id)
        {
            try
            {
                var tipo = await _tipoRolServicio.GetById(id);

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
        public async Task<ActionResult<TipoDto>> Post(RolDto t)
        {
            try
            {
                var tipo = t.Adapt<TipoRoles>();
                var resultado = await _tipoRolServicio.Crear(tipo);

                if (resultado != null)
                {
                    var respuesta = resultado.Adapt<RolDto>();
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
        public async Task<ActionResult> Put(RolDto r)
        {
            try
            {
                var tipo = new TipoRoles
                {

                    Descripcion = r.Descripcion,
                };

                var resultado = await _tipoRolServicio.Actualizar(tipo);

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
                await _tipoRolServicio.Eliminar(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



    }
}

