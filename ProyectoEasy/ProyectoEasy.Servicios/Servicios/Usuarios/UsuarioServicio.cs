using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProyectoEasy.Aplicacion.Servicios.Dtos;
using ProyectoEasy.Domain.Entities;
using ProyectoEasy.Infraestructura;
using ProyectoEasy.Servicios.Dtos;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEasy.Aplicacion.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly PedidosEasyContext _context;
        private readonly IConfiguration _configuration;
        public UsuarioServicio(PedidosEasyContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        public async Task<Usuarios> Crear(Usuarios usuario)
        {
            if (usuario == null)
            {
                throw new NullReferenceException();
            }

            _context.Add(usuario);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            return usuario;
        }


        public async Task<List<Usuarios>> Get()
        {
            var usuarios = await _context.Usuarios.ToListAsync();

            return usuarios;
        }

        public async Task<List<UsuarioListadoDto>> GetDto()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            var usuariosDto = new List<UsuarioListadoDto>();

            if (usuarios != null)
            {
                foreach (var x in usuarios)
                {
                    var tipoDoc = await _context.TipoDocumentos.SingleOrDefaultAsync(t => t.IdTipoDocumento == x.IdTipoDocumento);
                    var rol = await _context.TipoRoles.SingleOrDefaultAsync(r => r.IdTipoRol == x.IdRol);

                    var usuarioDto = new UsuarioListadoDto
                    {
                        NombreCompleto = x.Nombre + " " + x.Apellido,
                        NombreUsuario = x.NombreUsuario,
                        TipoDocumento = tipoDoc.Descripcion,
                        Documento = x.Documento,
                        Telefono = x.Telefono,
                        Rol = rol.Descripcion
                    };
                    usuariosDto.Add(usuarioDto);
                }
            }

            return usuariosDto;
        }



        public async Task<Usuarios> GetById(int id)
        {
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(x => x.IdUsuario == id);

            return usuario;
        }
    


        public async Task<Usuarios> Actualizar(Usuarios u)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == u.IdUsuario);
            if (usuario != null)
            {
                usuario.Nombre = u.Nombre;
                usuario.NombreUsuario = u.NombreUsuario;
                usuario.Apellido = u.Apellido;
                usuario.Contraseña = u.Contraseña;
                usuario.Email = u.Email;
                usuario.Telefono = u.Telefono;
                usuario.Documento = u.Documento;
                usuario.Direccion = u.Direccion;
                usuario.IdRol = u.IdRol;
                usuario.IdTipoDocumento = u.IdTipoDocumento;
                usuario.IdBarrio = u.IdBarrio;

                var resultado = await _context.SaveChangesAsync();
            }
            
            return usuario;
        }

        
        public async Task Eliminar(int id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == id);

            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                var resultado = await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExisteEmail(string email)
        {
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(x => x.Email == email);
            if (usuario != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> ExisteNombreUsuario(string nomUsu)
        {
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(x => x.NombreUsuario == nomUsu);
            if (usuario != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public async Task<UsuarioSesionDto> Login(LoginUsuarioDto login)
        {
            var resultado = await _context.Usuarios.SingleOrDefaultAsync(x => x.NombreUsuario == login.NombreUsuario && x.Contraseña == login.Contraseña);

            var rol = await _context.TipoRoles.SingleOrDefaultAsync(x => x.IdTipoRol == resultado.IdRol);

            if (resultado != null)
            {
                var usuarioSesion = new UsuarioSesionDto
                {
                    Nombre = resultado.Nombre,
                    Apellido = resultado.Apellido,
                    NombreUsuario = resultado.NombreUsuario,
                    Email = resultado.Email,
                    Rol = rol.Descripcion,
                    Token = CrearToken(resultado)
                };
                return usuarioSesion;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        private string CrearToken(Usuarios u)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, u.IdUsuario.ToString()),
                new Claim(ClaimTypes.Name, u.NombreUsuario)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }

}
