using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoEasy.Aplicacion.Dto;
using ProyectoEasy.Aplicacion.Servicios;
using ProyectoEasy.Aplicacion.Servicios.Dtos;
using ProyectoEasy.Domain.Entities;
using ProyectoEasy.Servicios.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoEasy.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioServicio _usuarioServicio;

        public UsuariosController(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuarios>>> Get()
        {
            try
            {
                var usuarios = await _usuarioServicio.Get();
                if (usuarios != null)
                {
                    return Ok(usuarios);
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

        [AllowAnonymous]
        [HttpGet("listado")]
        public async Task<ActionResult<List<UsuarioListadoDto>>> GetDto()
        {
            try
            {
                var usuarios = await _usuarioServicio.GetDto();

                if (usuarios != null)
                {
                    return Ok(usuarios);
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
        public async Task<ActionResult<Usuarios>> Get(int id)
        {
            try
            {
                var usuario = await _usuarioServicio.GetById(id);
                if (usuario != null)
                {
                    return Ok(usuario);
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
        public async Task<ActionResult<UsuarioDto>> Post(UsuarioDto u)
        {
            try
            {
                var usaurio = u.Adapt<Usuarios>();

                var resultado = await _usuarioServicio.Crear(usaurio);

                if (resultado != null)
                {
                    var respuesta = resultado.Adapt<UsuarioDto>();
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
        public async Task<ActionResult> Put(UsuarioDto u)
        {
            try
            {
                var usuario = new Usuarios
                {
                    Nombre = u.Nombre,
                    NombreUsuario = u.NombreUsuario,
                    Apellido = u.Apellido,
                    Contraseña = u.Contraseña,
                    Email = u.Email,
                    Telefono = u.Telefono,
                    Documento = u.Documento,
                    Direccion = u.Direccion,
                    IdRol = u.IdRol,
                    IdTipoDocumento = u.IdTipoDocumento,
                    IdBarrio = u.IdBarrio
                };

                var resultado = await _usuarioServicio.Actualizar(usuario);

                if (resultado != null)
                {
                    return Ok(usuario);
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
                await _usuarioServicio.Eliminar(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginUsuarioDto login)
        {
            try
            {
                var usuario = await _usuarioServicio.Login(login);
                if (usuario != null)
                {
                    return Ok(usuario);
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




        //[HttpGet("{username}/{password}")]
        //public ActionResult<List<Usuarios>> IniciarSesion(string nombreUsuario, string Contraseña)
        //{
        //    try
        //    {
        //        var usuario = context.Usuarios.Where(x => x.NombreUsuario.Equals(nombreUsuario) && x.Contraseña.Equals(Contraseña)).ToList();
        //        if (usuario != null)
        //        {
        //            return Ok(usuario);
        //        }
        //        else
        //        {
        //            return NoContent();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
