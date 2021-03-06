using FluentValidation;
using ProyectoEasy.Aplicacion.Servicios;
using ProyectoEasy.Aplicacion.Servicios.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEasy.Servicios.Validaciones
{
    public class RubroServicioInsertarValidacion : AbstractValidator<RubroDto>
    {
        private readonly IRubroServicio _rubroServicio;
        public RubroServicioInsertarValidacion(IRubroServicio rubroServicio)
        {
            _rubroServicio = rubroServicio;

            RuleFor(x => x.Descripcion)
                .NotEmpty().WithMessage("Debe ingresar una Desscripcion");
        }
    }
}
