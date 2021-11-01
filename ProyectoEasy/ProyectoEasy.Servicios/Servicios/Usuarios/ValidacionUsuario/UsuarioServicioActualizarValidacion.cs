using FluentValidation;
using ProyectoEasy.Aplicacion.Dto;
using ProyectoEasy.Aplicacion.Servicios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProyectoEasy.Servicios.Validaciones
{
    public class UsuarioServicioActualizarValidacion : AbstractValidator<UsuarioDto>
    {
        private readonly IUsuarioServicio _usuarioServicio;
        public UsuarioServicioActualizarValidacion(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("Debe ingresar un Nombre")
                .Length(2, 50).WithMessage("El Nombre debe tener entre 2 y 50 caracteres")
                .Matches("[a-zA-Z ]").WithMessage("Solo puede ingresar letras");

            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage("Debe ingresar un Apellido")
                .Length(2, 50).WithMessage("El Apellido debe tener entre 2 y 50 caracteres")
                .Matches("[a-zA-Z ]").WithMessage("Solo puede ingresar letras");

            RuleFor(x => x.NombreUsuario)
                .NotEmpty().WithMessage("Debe ingresar un Nombre de Usuario")
                .Length(3, 10).WithMessage("El Nombre debe tener entre 3 y 10 caracteres")
                .Matches("[a-zA-Z0-9]").WithMessage("Solo puede ingresar valores alfanumericos");

            RuleFor(x => x.Contraseña)
                .NotEmpty().WithMessage("Debe ingresar una contraseña"); //Hay que modificar el tipo de dato en la bd para poder terminar de validar bien este campo.

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Debe ingresar un Email")
                .EmailAddress().WithMessage("El email ingresado no es correcto");

            RuleFor(x => x.Telefono)
                .NotEmpty().WithMessage("Debe ingresar un Número de Teléfono")
                .Matches("[0-9]{10,10}").WithMessage("El Número de Telefono no es valido");

            RuleFor(x => x.Documento)
                .NotEmpty().WithMessage("Debe ingresar un Numero de Documento"); //Modificar el tipo de dato en la bd para poder terminar de validar este campo.

            RuleFor(x => x.Direccion)
                .NotEmpty().WithMessage("Debe ingresar una Dirección")
                .Length(3, 30).WithMessage("La Dirección debe tener entre 3 y 30 caracteres")
                .Matches("(^[a-zA-Z0-9 ]+$)").WithMessage("El campo Dirección solo acepta número, letras o espacios");

            RuleFor(x => x.IdTipoDocumento)
                .NotEmpty().WithMessage("Debe ingresar un tipo de Documento");

            RuleFor(x => x.IdBarrio)
                .NotEmpty().WithMessage("Debe ingresar un Barrio");

            RuleFor(x => x.IdRol)
                .NotEmpty().WithMessage("Debe ingresar un rol");

            RuleFor(x => x).CustomAsync(ValidarNombreUsuario);

            RuleFor(x => x).CustomAsync(ValidarEmail);
        }

        private async Task ValidarNombreUsuario(UsuarioDto usuario, ValidationContext<UsuarioDto> context, CancellationToken token)
        {
            bool res = await _usuarioServicio.ExisteNombreUsuario(usuario.NombreUsuario);
            if (res)
            {
                context.AddFailure("Nombre de usuario no disponible");
            }
        }

        private async Task ValidarEmail(UsuarioDto usuario, ValidationContext<UsuarioDto> context, CancellationToken token)
        {
            bool res = await _usuarioServicio.ExisteEmail(usuario.Email);
            if (res)
            {
                context.AddFailure("Email no disponible");
            }
        }
    }
}
