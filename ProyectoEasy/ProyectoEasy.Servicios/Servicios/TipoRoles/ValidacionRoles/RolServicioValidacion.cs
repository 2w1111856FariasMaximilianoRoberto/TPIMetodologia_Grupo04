using FluentValidation;
using ProyectoEasy.Aplicacion.Servicios;
using ProyectoEasy.Servicios.Dtos;

namespace ProyectoEasy.Servicios.Validaciones
{
    public class RolServicioValidacion : AbstractValidator<RolDto>
    {
        private readonly IRolServicio _rolServicio;
        public RolServicioValidacion(IRolServicio rolServicio)
        {
            _rolServicio = rolServicio;

            RuleFor(x => x.Descripcion)
                .NotEmpty().WithMessage("Debe ingresar una Desscripcion");
        }
    }
}
