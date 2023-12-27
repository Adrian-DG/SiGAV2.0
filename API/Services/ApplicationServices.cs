using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Helpers;
using Infrastructure.Data;
using Infrastructure.Helpers;
using Infrastructure.Repositories;

namespace API.Services
{
    public static class ApplicationServices
    {
        public static IServiceCollection GetApplicationServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        return services
        .AddSingleton<JwtService>()
        .AddScoped<IUnitOfWork, UnitOfWork>()
        .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
        .AddScoped(typeof(ISpecification<>), typeof(Specification<>));
    }
    }
}