using Corona.Api.Application.Dtos;
using Corona.Api.Application.Services;
using Corona.Api.Mapping;
using Glovali.Common.Application.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Corona.Api.Rest
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddConfigurations(Configuration);
            services.AddApplicationServices();
            //services.AddTransient<Testing>();

            //var provider = services.BuildServiceProvider();
            //_ = provider.GetRequiredService<Testing>().InitializeAsync();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }

    public class Testing
    {
        private readonly IJhuCsseService jhuCsseService;
        private readonly IService<ReportDto, string> service;

        public Testing(IJhuCsseService jhuCsseService, IService<ReportDto, string> service)
        {
            this.jhuCsseService = jhuCsseService;
            this.service = service;
        }

        public async Task InitializeAsync()
        {
            List<ReportDto> dtos =  await jhuCsseService.GetLatestDataAsync().ConfigureAwait(false);

            foreach (ReportDto dto in dtos)
            {
                _ = service.CreateAsync(dto);
            }
        }
    }
}
