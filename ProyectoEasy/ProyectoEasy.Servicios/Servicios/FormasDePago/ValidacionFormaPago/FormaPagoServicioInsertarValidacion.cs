using FluentValidation;
using ProyectoEasy.Aplicacion.Servicios;
using ProyectoEasy.Aplicacion.Servicios.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace ProyectoEasy.Servicios.Validaciones
{
    public class FormaPagoServicioInsertarValidacion : AbstractValidator<FormasPagoDto>
    {
        private readonly IFormaPagoServicio _formaPagoServicio;
        public FormaPagoServicioInsertarValidacion(IFormaPagoServicio formaPagoServicio)
        {
            _formaPagoServicio = formaPagoServicio;

            RuleFor(x => x.Descripcion)
                .NotEmpty().WithMessage("Debe ingresar una Descripcion");

            RuleFor(x => x).CustomAsync(Validar);
        }

        private async Task Validar(FormasPagoDto forma, ValidationContext<FormasPagoDto> context, CancellationToken token)
        {
            bool res = await _formaPagoServicio.Existe(forma.Descripcion);
            if (res)
            {
                context.AddFailure("Forma de Pago no disponible");
            }
        }
    }
}
