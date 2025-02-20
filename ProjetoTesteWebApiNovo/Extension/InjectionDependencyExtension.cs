using Domain.Interface.Repository;
using Domain.Interface.Service.Brand;
using Domain.Service.Registration.Brand;
using Infrastructure.Persistence.EFCore.Repository.Registration;

namespace ProjetoTesteWebApiNovo.Extension
{
    internal static class InjectionDependencyExtension
    {
        public static IServiceCollection ConfigureInjectionDependency(this IServiceCollection services)
        {
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IBrandValidateService, BrandValidateService>();
            services.AddScoped<IBrandRepository, BrandRepository>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<ICustomerAddressRepository, CustomerAddressRepository>();

            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}