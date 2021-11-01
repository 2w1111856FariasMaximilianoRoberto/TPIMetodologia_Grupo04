using FluentValidation;
using ProyectoEasy.Servicios.Barrios.Dtos;

namespace ProyectoEasy.Servicios.Validaciones
{

    public class BarrioServiciosInsertarValidacion : AbstractValidator<BarrioDto>
    {
        public BarrioServiciosInsertarValidacion()
        {
            RuleFor(x => x.Descripcion)
                .NotEmpty().WithMessage("Debe indicar una descripcion")
                .Length(3, 50).WithMessage("La Descripcion debe tener una longitud entre 3 y 50 caracteres");
        }
    }
}
