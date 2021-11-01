using FluentValidation;
using ProyectoEasy.Aplicacion.Servicios;
using ProyectoEasy.Aplicacion.Servicios.Dtos;
using ProyectoEasy.Servicios.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace ProyectoEasy.Servicios.Validaciones
{
    public class ProductoServicioActualizarValidacion : AbstractValidator<ProductoDto>
    {
        private readonly IProductoServicio _productoServicio;
        public ProductoServicioActualizarValidacion(IProductoServicio productoServicio)
        {
            _productoServicio = productoServicio;

            RuleFor(x => x.Descripcion)
                .NotEmpty().WithMessage("Debe ingresar una Descripción")
                .Length(2, 50).WithMessage("El Nombre debe tener entre 2 y 50 caracteres")
                .Matches("[a-zA-Z0-9 ]").WithMessage("Solo puede ingresar Valores alfanumericos");

            RuleFor(x => x.Color)
                .NotEmpty().WithMessage("Debe ingresar un Color")
                .Length(3, 50).WithMessage("El Nombre debe tener entre 2 y 50 caracteres")
                .Matches("[a-zA-Z ]").WithMessage("Solo puede ingresar letras");

            RuleFor(x => x.Dimenciones)
                .NotEmpty().WithMessage("Debe insgresar una Dimensión");

            RuleFor(x => x.Modelo)
                .NotEmpty().WithMessage("Debe ingresar un Modelo")
                .Length(2, 20).WithMessage("El Modelo debe tener entre 2 y 20 caracteres")
                .Matches("[a-zA-Z0-9]").WithMessage("Solo puede ingresar Valores alfanumericos");

            RuleFor(x => x.PrecioCompra)
                .NotEmpty().WithMessage("Debe insgresar un precio de Compra");

            RuleFor(x => x.PrecioVenta)
                .NotEmpty().WithMessage("Debe insgresar un precio de Venta");

            RuleFor(x => x.IdMarca)
                .NotEmpty().WithMessage("Debe insgresar una Marca");

            RuleFor(x => x.IdRubro)
                .NotEmpty().WithMessage("Debe insgresar un Rubro");

            RuleFor(x => x.Stock)
                .NotEmpty().WithMessage("Debe insgresar un Stock");



        }
    }
}
