﻿using Infrastructure.Persistence.EFCore.Context;
using Microsoft.EntityFrameworkCore;

namespace ProjetoTesteWebApiNovo.Extension
{
    public static class ContextExtension
    {
        public static IServiceCollection ConfigureContext(this IServiceCollection services, IConfiguration configuration)
        {
            string mySqlConnection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));
            return services;
        }
    }
}
