using FluentValidation;
using ProyectoEasy.Aplicacion.Servicios;
using ProyectoEasy.Servicios.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEasy.Aplicacion.Servicios.Validaciones
{
    public class MarcaServicioInsertarValidacion : AbstractValidator<MarcaDto>
    {
        private readonly IMarcaServicio _marcaServicio;
        public MarcaServicioInsertarValidacion(IMarcaServicio marcaServicio)
        {
            _marcaServicio = marcaServicio;
            RuleFor(x => x.Descripcion)
                .NotEmpty().WithMessage("Debe ingresar una Desscripcion");
        }
    }
}
