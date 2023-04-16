using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Movie.API.Contracts.Interfaces;
using Movie.API.Providers.DBContext;
using Movie.API.Providers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.API.Providers
{
    public static class ProviderServiceRegistration
    {
        public static IServiceCollection AddProviderServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MovieDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("DbConnection")));
            services.AddScoped<IMovieService, MovieService>();
            return services;
        }
    }
}
