using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProyectoEasy.Aplicacion.Servicios;
using ProyectoEasy.Aplicacion.Servicios.FormasDePago;
using ProyectoEasy.Infraestructura;
using ProyectoEasy.Servicios.Validaciones;
using Swashbuckle.AspNetCore.Filters;

namespace ProyectoEasy
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson()
                .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<ClienteServicioActualizarValidacion>());

            services.AddDbContext<PedidosEasyContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IBarrioServicio, BarrioServicio>();
            services.AddTransient<IClienteServicio, ClienteServicio>();
            services.AddTransient<IFormaPagoServicio, FormaPagoServicio>();
            services.AddTransient<IMarcaServicio, MarcaServicio>();
            services.AddTransient<IPedidoServicio, PedidoServicio>();
            services.AddTransient<IProductoServicio, ProductoServicio>();
            services.AddTransient<IRubroServicio, RubroServicio>();
            services.AddTransient<ITipoDocumentoServicio, TipoDocumentoServicio>();
            services.AddTransient<IRolServicio, RolServicio>();
            services.AddTransient<IUsuarioServicio, UsuarioServicio>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            System.Text.Encoding.ASCII.GetBytes(
                                Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<SecurityRequirementsOperationFilter>();

                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Autorizacion Standar, Usar Bearer. Ejemplo \" bearer {token} \"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
            });

            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()); });
            services.AddRouting(r => r.SuppressCheckForUnhandledSecurityMetadata = true);
            services.AddCors(o => o.AddPolicy("easy", builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();

            }));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("easy");
            //Si trabajamos con un framework desde el front lo siguiente no hace falta
            app.Use((context, next) =>
            {
                context.Items["__CorsMiddlewareInvoked"] = true;
                return next();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
