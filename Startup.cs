using EmployeeManagement.DataAccessProviders;
using EmployeeManagement.DataAccessProviders.Interfaces;
using EmployeeManagement.DBContext;
using EmployeeManagement.Util;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EmployeeManagement
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
            services.AddCors();
            services.Configure<BaseSettings>(Configuration);
            services.AddDbContext<dbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddScoped<IEmployeeDAP, EmployeeDAP>();
            /*services.AddSingleton<IJsonLogger, JsonLogger>()*/;
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            //services.Configure<FormOptions>(x =>
            //{
            //    x.ValueLengthLimit = int.MaxValue;
            //    x.MultipartBodyLengthLimit = int.MaxValue; // In case of multipart
            //});
            services.AddSwaggerGen();
            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors(builder => builder
                     .AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader());
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Authentication API v1");
            });
        }
    }
}
