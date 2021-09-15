using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Alkemy_backend.models;
using Alkemy_backend.Models;
using Alkemy_backend.Services.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Alkemy_backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
          /*  JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); */
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(opt => opt.AddDefaultPolicy(
                builder => 
                 builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
                ));

            /*
            services.AddCors(opt => {
                opt.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });

               
            });
            */

            services.AddControllers().AddNewtonsoftJson(
                opt =>
                {
                  opt.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
                  opt.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm";
                }
                
            ); 


            services.AddScoped<IAdminRepository, AdminRepository>(); 
            
           


            services.AddDbContext<AlkemyContext>(options => options.UseSqlServer(Configuration.GetConnectionString("alkemyconexion")));


            /* services.AddIdentity<Admin, AlkemyRole>().AddEntityFrameworkStores<AlkemyContext>().AddDefaultTokenProviders(); */

            /* services.AddDefaultIdentity<AlkemyLoginUser>()
                 .AddRoles<IdentityRole>()

                 .AddEntityFrameworkStores<AlkemyContext>()
                 .AddDefaultTokenProviders()
                 .AddDefaultUI();*/

            // Jwt security and tokens


            /* var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString()); */
            /* var keytest = Encoding.ASCII.GetBytes("somethingyouwantwhichissecurewillworkk"); */
            services.ConfigureApplicationCookie(options =>

            {

                options.Events = new CookieAuthenticationEvents

                {

                    OnRedirectToLogin = x =>

                    {

                        x.Response.Redirect("Account/Login");

                        return Task.CompletedTask;

                    }

                };

            });

            

            services.AddAuthentication(x => {

                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
              /* x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; */
                
               

            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.IncludeErrorDetails = true;
    
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,

                    
                     ValidIssuer = "https://localhost:44325",
                     ValidAudience = "https://localhost:44325",

                    /*
                    ValidIssuer = "https://localhost:9055",
                    ValidAudience = "https://localhost:9055",
                    */

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("somethingyouwantwhichissecurewillworkk")),

                };

            });

            services.AddAuthorization(             
            opt =>
             {

                 /* opt.DefaultPolicy = new AuthorizationPolicyBuilder()
                 .RequireAuthenticatedUser()
                 .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                 .Build();
                 */


                 var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(
                JwtBearerDefaults.AuthenticationScheme);

                 defaultAuthorizationPolicyBuilder =
                     defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();

                 opt.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build(); 
             

                 /*
                 opt.AddPolicy("admin", policy =>
                 {
                     policy.RequireClaim(ClaimTypes.Role, "admin");
                 }); */

                 /*
                 opt.AddPolicy("alumno", policy =>
                 {
                     policy.RequireClaim(ClaimTypes.Role, "alumno");
                 }); */
             }

            );

            

           /* services.AddMvcCore(); */

           /* services.AddControllers(options => options.EnableEndpointRouting = false); */




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {



           /* app.UseCors("EnableCORS"); */

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            app.UseHttpsRedirection();
            app.UseRouting();

            // cors
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}