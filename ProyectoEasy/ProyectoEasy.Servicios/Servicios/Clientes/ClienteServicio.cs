using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProyectoEasy.Domain.Entities;
using ProyectoEasy.Infraestructura;
using ProyectoEasy.Servicios.Dtos;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProyectoEasy.Aplicacion.Servicios
{
    public class ClienteServicio : IClienteServicio
    {
        private readonly PedidosEasyContext _context;
        private readonly IConfiguration _configuration;

        public ClienteServicio(PedidosEasyContext pedidosEasyContext, IConfiguration configuration)
        {
            _context = pedidosEasyContext;
            _configuration = configuration;
        }

        public async Task<Clientes> Crear(Clientes cliente)
        {
            if (cliente == null)
            {
                throw new NullReferenceException();
            }

            // validacion de negocio
            cliente.IdTipoRol = 2;
            // persistir cliente 
            _context.Add(cliente);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

            return cliente;
        }

        public async Task<List<Clientes>> Get()
        {
            var clientes = await _context.Clientes.ToListAsync();

            return clientes;
        }

        public async Task<List<ClienteListaDto>> GetDto()
        {
            var clientes = await _context.Clientes.ToListAsync();
            var clientesDto = new List<ClienteListaDto>();
            
            if (clientes != null)
            {
                foreach (var x in clientes)
                {
                    var tipoDoc = await _context.TipoDocumentos.SingleOrDefaultAsync(t => t.IdTipoDocumento == x.IdTipoDocumento);

                    var clienteDto = new ClienteListaDto
                    {
                        NombreCliente = x.NombreCliente,
                        ApellidoCliente = x.ApellidoCliente,
                        TipoDocumento = tipoDoc.Descripcion,
                        Documento = x.Documento,
                        Telefono = x.Telefono,
                        Email = x.Email
                    };
                    clientesDto.Add(clienteDto);
                }
            }

            return clientesDto;
        }

        public async Task<Clientes> GetById(int id)
        {
            var cliente = await _context.Clientes.SingleOrDefaultAsync(t => t.IdCliente == id);

            return cliente;
        }

        public async Task<Clientes> Actualizar(Clientes c)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.IdCliente == c.IdCliente);
            if (cliente != null)
            {
                cliente.NombreCliente = c.NombreCliente;
                cliente.NombreUsuario = c.NombreUsuario;
                cliente.ApellidoCliente = c.ApellidoCliente;
                cliente.Sexo = c.Sexo;
                cliente.Contraseña = c.Contraseña;
                cliente.Email = c.Email;
                cliente.Telefono = c.Telefono;
                cliente.Documento = c.Documento;
                cliente.Direccion = c.Direccion;
                cliente.IdTipoDocumento = c.IdTipoDocumento;
                cliente.IdBarrio = c.IdBarrio;


                var resultado = await _context.SaveChangesAsync();
            }
            return cliente;
        }

        public async Task Eliminar(int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.IdCliente == id);

            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                var resultado = await _context.SaveChangesAsync();

            }
        }

        public async Task<bool> ExisteNombreUsuario(string nom)
        {
            var cliente = await _context.Clientes.SingleOrDefaultAsync(p => p.NombreUsuario == nom);
            if (cliente != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<ClienteSesionDto> Login(LoginClienteDto login)
        {
            var resultado = await _context.Clientes.SingleOrDefaultAsync(x => x.NombreUsuario == login.NombreUsuario && x.Contraseña == login.Contraseña);

            var rol = await _context.TipoRoles.SingleOrDefaultAsync(x => x.IdTipoRol == resultado.IdTipoRol);

            if (resultado != null)
            {
                var clienteSesion = new ClienteSesionDto
                {
                    NombreCliente = resultado.NombreCliente,
                    ApellidoCliente = resultado.ApellidoCliente,
                    NombreUsuario = resultado.NombreUsuario,
                    Email = resultado.Email,
                    Rol = rol.Descripcion,
                    Token = CrearToken(resultado)
                };
                return clienteSesion;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        private string CrearToken(Clientes c)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, c.IdCliente.ToString()),
                new Claim(ClaimTypes.Name, c.NombreUsuario)
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
