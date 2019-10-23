using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DatingApp.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.models;

namespace DatingApp.API
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration) 
        {
            this.Configuration = configuration;
               
        }
                public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(x=>x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
           services.AddTransient<Seed>();
          services.AddMvc(option => option.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddNewtonsoftJson(opt=> {
              opt.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore;
          });
        services.AddCors();
       services.AddAutoMapper(typeof(Startup));
        services.AddScoped<IDatingRepository,DatingRepository>();
        services.AddScoped<IAuthRepository,AuthRepository>();

            
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)  
           .AddJwtBearer(options =>  
           {  
               options.TokenValidationParameters = new TokenValidationParameters  
               {  
                   ValidateIssuer = false,  
                   ValidateAudience = false,  
                   ValidateIssuerSigningKey = true,  
                  IssuerSigningKey = new SymmetricSecurityKey (Encoding.ASCII
                    .GetBytes (Configuration.GetSection ("AppSettings:Token").Value)) 
               };  
           });  
     
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,Seed seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

          // app.UseHttpsRedirection();

         //  app.UseRouting();
         seeder.SeedUsers();
       app.UseAuthorization();
         app.UseCors(x=>x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
         app.UseMvc();
        

      
        }
    }
}
