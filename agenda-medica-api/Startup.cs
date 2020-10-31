using agenda_medica_aplicacao;
using agenda_medica_aplicacao.Interfaces;
using agenda_medica_aplicacao.Interfaces.Mappers;
using agenda_medica_aplicacao.Mappers;
using agenda_medica_dominio.Interfaces.Data;
using agenda_medica_dominio.Interfaces.Repositorios;
using agenda_medica_dominio.Interfaces.Servicos;
using agenda_medica_dominio.Servicos;
using agenda_medica_infraestrutura;
using agenda_medica_infraestrutura.Data;
using agenda_medica_infraestrutura.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace agenda_medica_api
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
            services.AddControllers();

            services.AddMvc();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "API Agenda M�dica",
                        Version = "v1.0.0"
                    });
            });

            services.AddDbContext<ContextoDb>(options => options.UseSqlServer(Configuration.GetConnectionString("Conexao")));
            services.AddScoped<IAgendaRepositorio, AgendaRepositorio>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMapperAgenda, MapperAgenda>();
            services.AddScoped<IAgendaAplicacao, AgendaAplicacao>();
            services.AddScoped<IAgendaServico, AgendaServico>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
