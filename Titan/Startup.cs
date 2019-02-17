﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Titan.Entity;
using Titan.Interface.BaseInterface;
using Titan.Interface.RepositoryInterface;
using Titan.Interface.ServiceInterface;
using Titan.Middleware;
using Titan.Model;
using Titan.Repository;
using Titan.Repository.Base;
using Titan.Service;
using UnitOfWorkWithRepositoryPartens.Repository.Base;

namespace Titan
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

            services.AddDbContext<TitanDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("TitanDatabase")));

            services.AddCors();

            services.AddMvc();

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<IEnumerable<TestDto>, IEnumerable<TestEntity>>();
                cfg.CreateMap<TestDto,TestEntity>();
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);
            services.AddScoped<IDisposable, UnitOfWork>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITestService, TestService>();
            services.AddScoped<ITestRepository, TestRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
              .AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());


            loggerFactory.AddFile("Logs/Titan-{Date}.txt");

            app.UseMiddleware<CustomExceptionMiddleware>();

            app.UseStaticFiles();


            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc();

        }
    }
}
