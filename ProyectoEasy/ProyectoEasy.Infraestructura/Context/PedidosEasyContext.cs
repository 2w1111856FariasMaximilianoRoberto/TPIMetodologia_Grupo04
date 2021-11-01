using Microsoft.EntityFrameworkCore;
using ProyectoEasy.Domain.Entities;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoEasy.Infraestructura
{
    public partial class PedidosEasyContext : DbContext
    {
        //public PedidosEasyContext()
        //{
        //}

        public PedidosEasyContext(DbContextOptions<PedidosEasyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Barrios> Barrios { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<DetallePedidos> DetallePedidos { get; set; }
        public virtual DbSet<FormasPago> FormasPago { get; set; }
        public virtual DbSet<Marcas> Marcas { get; set; }
        public virtual DbSet<Pedidos> Pedidos { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Rubros> Rubros { get; set; }
        public virtual DbSet<TipoDocumentos> TipoDocumentos { get; set; }
        public virtual DbSet<TipoRoles> TipoRoles { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer( "User ID = sa; Password = 123456; Server = DESKTOP - PMF239P\\SQLEXPRESS2019; Database = PedidosEasy; Integrated Security = true; Pooling = true");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Barrios>(entity =>
            {
                entity.HasKey(e => e.IdBarrio)
                    .HasName("PK__Barrios__42F23FF801FD461E");

                entity.Property(e => e.IdBarrio).HasColumnName("idBarrio");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Clientes__885457EE937D55A9");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.ApellidoCliente)
                    .IsRequired()
                    .HasColumnName("apellidoCliente")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .HasColumnName("contraseña")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Documento)
                    .HasColumnName("documento")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdBarrio).HasColumnName("idBarrio");

                entity.Property(e => e.IdTipoDocumento).HasColumnName("idTipoDocumento");

                entity.Property(e => e.IdTipoRol).HasColumnName("idTipoRol");

                entity.Property(e => e.NombreCliente)
                    .IsRequired()
                    .HasColumnName("nombreCliente")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasColumnName("nombreUsuario")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo).HasColumnName("sexo");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("telefono")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetallePedidos>(entity =>
            {
                entity.HasKey(e => e.IdDetallePedido)
                    .HasName("PK__DetalleP__49CD10372FC1CEE6");

                entity.Property(e => e.IdDetallePedido).HasColumnName("idDetallePedido");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdPedido).HasColumnName("idPedido");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.PrecioUnitario).HasColumnName("precioUnitario");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.DetallePedidos)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_idPedidos_Detalle");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetallePedidos)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_idProducto");
            });

            modelBuilder.Entity<FormasPago>(entity =>
            {
                entity.HasKey(e => e.IdFormaPago)
                    .HasName("PK__FormasPa__952893F645ACDAA9");

                entity.Property(e => e.IdFormaPago).HasColumnName("idFormaPago");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Marcas>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PK__Marcas__70331812069B3011");

                entity.Property(e => e.IdMarca).HasColumnName("idMarca");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pedidos>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PK__Pedidos__A9F619B7E118FB69");

                entity.Property(e => e.IdPedido).HasColumnName("idPedido");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.IdFormaPago).HasColumnName("idFormaPago");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_idCliente");

                entity.HasOne(d => d.IdFormaPagoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdFormaPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_idFormaPago");
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto__07F4A13285220439");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasColumnName("color")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dimenciones).HasColumnName("dimenciones");

                entity.Property(e => e.IdMarca).HasColumnName("idMarca");

                entity.Property(e => e.IdRubro).HasColumnName("idRubro");

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasColumnName("modelo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioCompra).HasColumnName("precioCompra");

                entity.Property(e => e.PrecioVenta).HasColumnName("precioVenta");

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_idMarca");

                entity.HasOne(d => d.IdRubroNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdRubro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_idCategoria");
            });

            modelBuilder.Entity<Rubros>(entity =>
            {
                entity.HasKey(e => e.IdRubro)
                    .HasName("PK__Rubros__A32E887461C2E9DB");

                entity.Property(e => e.IdRubro).HasColumnName("idRubro");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoDocumentos>(entity =>
            {
                entity.HasKey(e => e.IdTipoDocumento)
                    .HasName("PK__TipoDocu__61FDF9F576389F48");

                entity.Property(e => e.IdTipoDocumento).HasColumnName("idTipoDocumento");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoRoles>(entity =>
            {
                entity.HasKey(e => e.IdTipoRol)
                    .HasName("PK__TipoRole__F81762AA54F914DC");

                entity.Property(e => e.IdTipoRol).HasColumnName("idTipoRol");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__645723A650BCC813");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnName("apellido")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .HasColumnName("contraseña")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Documento)
                    .HasColumnName("documento")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdBarrio).HasColumnName("idBarrio");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.IdTipoDocumento).HasColumnName("idTipoDocumento");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasColumnName("nombreUsuario")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("telefono")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBarrioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdBarrio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_idBarrios");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_idTipoRoles");

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_idTipoDocumentos_Usuarios");
            });

            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
