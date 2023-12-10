using System.Text;
using ListaTarefas.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ListaTarefas.Persistence;
using Microsoft.Extensions.Options;

namespace ListaTarefas.Configuration
{
       public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfig(this IServiceCollection services,
            IConfiguration configuration)
        {
        
        var connectionString = configuration.GetConnectionString("DefaultConnection");

            //AddDbContext
            services.AddDbContext<ApplicationDbContext>( options => 
                options.UseMySql(connectionString,
                ServerVersion.AutoDetect(connectionString)));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
                
            return services;
        }
    }
}