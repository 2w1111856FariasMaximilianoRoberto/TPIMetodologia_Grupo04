using FluentValidation;
using ProyectoEasy.Aplicacion.Servicios;
using ProyectoEasy.Servicios.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEasy.Servicios.Validaciones
{
    public class MarcaServicioActualizarValidacion : AbstractValidator<MarcaDto>
    {
        private readonly IMarcaServicio _marcaServicio;
        public MarcaServicioActualizarValidacion(IMarcaServicio marcaServicio)
        {
            _marcaServicio = marcaServicio;

            RuleFor(x => x.Descripcion)
                .NotEmpty().WithMessage("Debe ingresar una Desscripcion");
        }
    }
}
