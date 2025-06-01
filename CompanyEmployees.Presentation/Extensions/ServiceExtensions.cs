using Contracts.Domain;
using Repository.Infrastructure;
using Service.Contracts;
using Service;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployees.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
           services.AddScoped<IRepositoryManager, RepositoryManager>();
        public static void ConfigureServiceManager(this IServiceCollection services) =>
           services.AddScoped<IServiceManager, ServiceManager>();
        public static void ConfigureSqlContext(this IServiceCollection services,
         IConfiguration configuration) =>
         services.AddDbContext<RepositoryContext>(opts =>
        opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        public static IMvcBuilder AddCustomCSVFormatter(this IMvcBuilder builder) =>
         builder.AddMvcOptions(config => config.OutputFormatters.Add(new
         CsvOutputFormatter()));

    }
}
