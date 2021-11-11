using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoEasy.Aplicacion.Servicios;
using ProyectoEasy.Domain.Entities;
using ProyectoEasy.Infraestructura;
using ProyectoEasy.Servicios.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoEasy.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProdutosController : ControllerBase
    {
        private readonly IProductoServicio _productoServicio;
        public ProdutosController(IProductoServicio productoServicio)
        {
            _productoServicio = productoServicio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductosDto>>> Get()
        {
            try
            {
                var productos = await _productoServicio.Get();

                if (productos != null)
                {
                    return Ok(productos);
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
        public async Task<ActionResult<Productos>> Get(int id)
        {
            try
            {
                var producto = await _productoServicio.GetById(id);
                if (producto != null)
                {
                    return Ok(producto);
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
        public async Task<ActionResult<ProductoDto>> Post(ProductoDto p)
        {
            try
            {
                //var producto = new Productos
                //{
                //    Descripcion = p.Descripcion,
                //    Color = p.Color,
                //    Dimenciones = p.Dimenciones,
                //    Modelo = p.Modelo,
                //    PrecioCompra = p.PrecioCompra,
                //    PrecioVenta = p.PrecioVenta,
                //    IdMarca = p.IdMarca,
                //    IdRubro = p.IdRubro,
                //    Stock = p.Stock,
                //};


                var producto = p.Adapt<Productos>();

                var resultado = await _productoServicio.Crear(producto);

                if (resultado != null)
                {
                    var respuesta = resultado.Adapt<ProductoDto>();
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
        public async Task<ActionResult> Put(int id, Productos p)
        {
            try
            {
                var producto = new Productos
                {
                    Descripcion = p.Descripcion,
                    Color = p.Color,
                    Dimenciones = p.Dimenciones,
                    Modelo = p.Modelo,
                    PrecioCompra = p.PrecioCompra,
                    PrecioVenta = p.PrecioVenta,
                    IdMarca = p.IdMarca,
                    IdRubro = p.IdRubro,
                    Stock = p.Stock
                };

                var resultado = await _productoServicio.Actualizar(producto);


                if (resultado != null)
                {
                    return Ok(producto);
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
        public async Task<ActionResult<Productos>> Delete(int id)
        {
            try
            {
                await _productoServicio.Eliminar(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}