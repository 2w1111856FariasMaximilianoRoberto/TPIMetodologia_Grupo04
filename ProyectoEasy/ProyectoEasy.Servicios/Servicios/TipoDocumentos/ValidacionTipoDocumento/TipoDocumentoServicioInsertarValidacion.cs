using FluentValidation;
using ProyectoEasy.Aplicacion.Servicios;
using ProyectoEasy.Aplicacion.Servicios.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEasy.Servicios.Validaciones
{
    public class TipoDocumentoServicioInsertarValidacion : AbstractValidator<TipoDto>
    {
        private readonly ITipoDocumentoServicio _tipoDocuementoServicio;
        public TipoDocumentoServicioInsertarValidacion(ITipoDocumentoServicio tipoDocuementosServicio)
        {
            _tipoDocuementoServicio = tipoDocuementosServicio;

            RuleFor(x => x.Descripcion)
                .NotEmpty().WithMessage("Debe ingresar una Desscripcion");
        }
    }
}
