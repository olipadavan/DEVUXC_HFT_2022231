using DEVUXC_HFT_2022231.EndPoint;
using DEVUXC_HFT_2022231.Logic.Intefaces;
using DEVUXC_HFT_2022231.Logic.Logics;
using DEVUXC_HFT_2022231.Models;
using DEVUXC_HFT_2022231.Repository;
using DEVUXC_HFT_2022231.Repository.Interfaces;
using DEVUXC_HFT_2022231.Repository.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVUXC._HFT_2022231.EndPoint
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
            services.AddSingleton<F1DbContext>();

            services.AddTransient<IRepository<Sponsor>, SponsorRepository>();
            services.AddTransient<IRepository<Team>, TeamRepository>();
            services.AddTransient<IRepository<Season>, SeasonRepository>();

            services.AddTransient<ISponsorLogic, SponsorLogic>();
            services.AddTransient<ITeamLogic, TeamLogic>();
            services.AddTransient<ISeasonLogic, SeasonLogic>();

            services.AddSignalR();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DEVUXC._HFT_2022231.EndPoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DEVUXC._HFT_2022231.EndPoint v1"));
            }

            app.UseExceptionHandler(c => c.Run(async context =>
            {
            var exception = context.Features.Get<IExceptionHandlerPathFeature>().Error;
            var resoponse = new { Msg = exception.Message };
            await context.Response.WriteAsJsonAsync(resoponse);
            }));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");

            });
        }
    }
}
