using FluentValidation;
using ProyectoEasy.Servicios.Barrios.Dtos;
using ProyectoEasy.Aplicacion.Servicios;

namespace ProyectoEasy.Servicios.Barrios.ValidacionBarrio
{
    class BarrioServiciosActualizarValidacion : AbstractValidator<BarrioDto>
    {
        private readonly IBarrioServicio _barrioServicio;
        public BarrioServiciosActualizarValidacion(IBarrioServicio barrioServicio)
        {
            _barrioServicio = barrioServicio;
            RuleFor(x => x.Descripcion)
                .NotEmpty().WithMessage("Debe indicar una descripcion")
                .Length(3, 50).WithMessage("La Descripcion debe tener una longitud entre 3 y 50 caracteres");
        }
    }
}
