using Mapster;
using Microsoft.AspNetCore.Authorization;
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
    [EnableCors("easy")]
    //[Authorize]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteServicio _clienteServicio;

        public ClientesController(IClienteServicio clienteServicio)
        {
            _clienteServicio = clienteServicio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Clientes>>> Get()
        {
            try
            {
                var clientes = await _clienteServicio.Get();

                if (clientes != null)
                {
                    return Ok(clientes);
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

        //[AllowAnonymous]
        [HttpGet("listado")]
        public async Task<ActionResult<List<ClienteListaDto>>> GetDto()
        {
            try
            {
                var clientes = await _clienteServicio.GetDto();

                if (clientes != null)
                {
                    return Ok(clientes);
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
        public async Task<ActionResult<Clientes>> GetById(int id)
        {
            try
            {
                var cliente = await _clienteServicio.GetById(id);
                if (cliente != null)
                {
                    return Ok(cliente);
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

        //[AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<ClienteDto>> Post(ClienteDto c)
        {
            try
            {
                //var cliente = new Clientes
                //{
                //    NombreCliente = c.NombreCliente,
                //    NombreUsuario = c.NombreUsuario,
                //    ApellidoCliente = c.ApellidoCliente,
                //    Sexo = c.Sexo,
                //    Contraseña = c.Contraseña,
                //    Email = c.Email,
                //    Telefono = c.Telefono,
                //    Documento = c.Documento,
                //    Direccion = c.Direccion,
                //    IdTipoDocumento = c.IdTipoDocumento,
                //    IdBarrio = c.IdBarrio,
                //};

                var cliente = c.Adapt<Clientes>();

                var resultado = await _clienteServicio.Crear(cliente);

                if (resultado != null)
                {
                    var respuesta = resultado.Adapt<ClienteDto>();
                    return Ok(respuesta);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(ClienteDto c)
        {
            try
            {
                var cliente = new Clientes
                {
                    NombreCliente = c.NombreCliente,
                    NombreUsuario = c.NombreUsuario,
                    ApellidoCliente = c.ApellidoCliente,
                    Sexo = c.Sexo,
                    Contraseña = c.Contraseña,
                    Email = c.Email,
                    Telefono = c.Telefono,
                    Documento = c.Documento,
                    Direccion = c.Direccion,
                    IdTipoDocumento = c.IdTipoDocumento,
                    IdBarrio = c.IdBarrio,
                };

                var resultado = await _clienteServicio.Actualizar(cliente);


                if (resultado != null)
                {
                    return Ok(cliente);
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
                await _clienteServicio.Eliminar(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        //[AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginClienteDto login)
        {
            try
            {
                var cliente = await _clienteServicio.Login(login);
                if (cliente != null)
                {
                    return Ok(cliente);
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
    }
}
