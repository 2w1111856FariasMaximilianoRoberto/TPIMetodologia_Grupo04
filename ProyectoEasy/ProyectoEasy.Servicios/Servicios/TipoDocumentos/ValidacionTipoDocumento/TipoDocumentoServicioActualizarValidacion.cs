using FluentValidation;
using ProyectoEasy.Aplicacion.Servicios;
using ProyectoEasy.Aplicacion.Servicios.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEasy.Servicios.Validaciones
{
    public class TipoDocumentoServicioActualizarValidacion : AbstractValidator<TipoDto>
    {
        private readonly ITipoDocumentoServicio _tipoDocumentoServicio;
        public TipoDocumentoServicioActualizarValidacion(ITipoDocumentoServicio tipoDocumentoServicio)
        {
            _tipoDocumentoServicio = tipoDocumentoServicio;

            RuleFor(x => x.Descripcion)
                .NotEmpty().WithMessage("Debe ingresar una Desscripcion");
        }
    }
}
