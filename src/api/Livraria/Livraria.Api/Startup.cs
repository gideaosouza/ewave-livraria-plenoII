using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using Livraria.Domain.Entities;
using Livraria.Domain.Validations;
using Livraria.Infrastructure.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Livraria.Application.Interfaces;
using Livraria.Application.Services;
using Livraria.Infrastructure.Repository;
using Livraria.Infrastructure.Repository.Interfaces;
using Swashbuckle.Swagger;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;

namespace Livraria.Api
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
            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder.WithOrigins(Configuration.GetValue<string>("AngularClient")).AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddControllers().AddNewtonsoftJson(options =>
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );

            //Services
            services.AddTransient<IInstituicaoEnsinoService, InstituicaoEnsinoService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<ILivroService, LivroService>();
            services.AddTransient<ILivroReservaService, LivroReservaService>();
            services.AddTransient<ILivroEmprestimoService, LivroEmprestimoService>();

            //Upload
            services.AddTransient<IUploadFileService, UploadFileService>();
            //Respository
            services.AddTransient<IRepositoryInstituicaoEnsino, InstituicaoEnsinoRepository>();
            services.AddTransient<IRepositoryUsuario, UsuarioRepository>();
            services.AddTransient<IRepositoryLivro, LivroRepository>();
            services.AddTransient<IRepositoryLivroReserva, LivroReservaRepository>();
            services.AddTransient<IRepositoryLivroEmprestimo, LivroEmprestimoRepository>();
            //File Manager
            services.AddTransient<IFileManager, FileManager>();
            //Validações
            services.AddMvc().AddFluentValidation();
            services.AddTransient<IValidator<InstituicaoEnsino>, InstituicaoEnsinoValidator>();
            services.AddTransient<IValidator<Usuario>, UsuarioValidator>();
            services.AddTransient<IValidator<Livro>, LivroValidator>();
            services.AddTransient<IValidator<LivroReserva>, LivroReservaValidator>();
            services.AddTransient<IValidator<EmprestimoLivro>, EmprestimoLivroValidator>();

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LivrariaConnectionString")));

            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Livraria Ewave",
                        Version = "v1",
                        Description = "Api da Livraria Ewave",
                        Contact = new OpenApiContact
                        {
                            Name = "Gideão Souza",
                            Url = new Uri("https://github.com/gideaosouza"),
                            Email = "gideao_souza@outlook.com"
                        }
                    }
                    );
                // Set the comments path for the Swagger JSON and UI.**
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Livraria Ewave V1");
            });

            app.UseCors("ApiCorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
