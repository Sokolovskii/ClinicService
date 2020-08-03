using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using SokolovskiyClinicService.BusinessLogic.AdminServices;
using SokolovskiyClinicService.BusinessLogic.AuthorizationServices;
using SokolovskiyClinicService.BusinessLogic.CommonServices;
using SokolovskiyClinicService.BusinessLogic.DoctorServices;
using SokolovskiyClinicService.BusinessLogic.UserServices;
using SokolovskiyClinicService.Entity;
using SokolovskiyClinicService.Entity.Repository.DoctorRepository;
using SokolovskiyClinicService.Entity.Repository.ProfessionRepository;
using SokolovskiyClinicService.Entity.Repository.ScheduleRepository;
using SokolovskiyClinicService.Entity.Repository.SessionRepository;
using SokolovskiyClinicService.Entity.Repository.UserRepository;
using SokolovskiyClinicService.Entity.Repository.WorkDayRepository;
using SokolovskiyClinicService.Exceptions;
using SokolovskiyClinicService.Lockers;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace SokolovskiyClinicService
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
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProfessionRepository, ProfessionRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<IWorkDayRepository, WorkDayRepository>();

            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IAdminServices, AdminServices>();
            services.AddScoped<IAuthorizationServices, AuthorizationServices>();
            services.AddScoped<ICommonServices, CommonServices>();
            services.AddScoped<IDoctorServices, DoctorServices>();
            services.AddSingleton<Locker>();

            services.AddControllers().AddNewtonsoftJson();
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddSwaggerGen(c =>
            {
                var securityDefinition = new OpenApiSecurityScheme
                {
                    Name = "Bearer",
                    BearerFormat = "JWT",
                    Scheme = "bearer",
                    Description = "Specify the authorization token.",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                };
                c.AddSecurityDefinition("jwt_auth", securityDefinition);
                
                var securityScheme = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "jwt_auth",
                        Type = ReferenceType.SecurityScheme
                    }
                };
                
                var securityRequirements= new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { }},
                };
                c.AddSecurityRequirement(securityRequirements);
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clinic Service");
                c.DocExpansion(DocExpansion.None);
            });
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(routes =>
            {
                routes.MapControllerRoute(
                    name:"default",
                    pattern:"{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

