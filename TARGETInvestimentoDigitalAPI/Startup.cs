using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using TARGETInvestimentoDigitalAPI.Data;
using TARGETInvestimentoDigitalAPI.Interfaces.Clientes;
using TARGETInvestimentoDigitalAPI.Interfaces.Dominio;
using TARGETInvestimentoDigitalAPI.Services.Clientes;
using TARGETInvestimentoDigitalAPI.Services.Dominio;

namespace TARGETInvestimentoDigitalAPI
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
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TARGETInvestimentoDigitalConnection")));
            services.AddMvc();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TARGETInvestimentoDigitalAPI", Version = "v1" });
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
            services.AddScoped<ICadastroClienteService, CadastroClienteService>();
            services.AddScoped<IRecuperarClientesPorDataCadastroService, RecuperarClientesPorDataCadastroService>();
            services.AddScoped<IRecuperarClientesPorRendaMensalService, RecuperarClientesPorRendaMensalService>();
            services.AddScoped<IRecuperarDadosDoEnderecoClienteService, RecuperarDadosDoEnderecoClienteService>();
            services.AddScoped<IAlteraEnderecoService, AlteraEnderecoService>();
            services.AddScoped<IIndiceAdesaoGeralService, IndiceAdesaoGeralService>();
            services.AddScoped<IRecuperaUfsService, RecuperaUfsService>();
            services.AddScoped<IRecuperaMunicipiosService, RecuperaMunicipiosService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TARGETInvestimentoDigitalAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
