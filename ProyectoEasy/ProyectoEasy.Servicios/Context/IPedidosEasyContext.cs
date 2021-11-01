using Microsoft.EntityFrameworkCore;
using ProyectoEasy.Domain.Entities;

namespace ProyectoEasy.Aplicacion.Context
{
    public interface IPedidosEasyContext
    {
        public DbSet<Barrios> Barrios { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<DetallePedidos> DetallePedidos { get; set; }
        public DbSet<FormasPago> FormasPago { get; set; }
        public DbSet<Marcas> Marcas { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Rubros> Rubros { get; set; }
        public DbSet<TipoDocumentos> TipoDocumentos { get; set; }
        public DbSet<TipoRoles> TipoRoles { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
