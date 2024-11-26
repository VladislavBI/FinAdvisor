using System.Reflection;
using FinAdvisor.UserModule.Domain.Users;
using FinAdvisor.UserModule.Infrastructure.Database;
using FinAdvisor.UserModule.Infrastructure.Database.Interceptors;
using FinAdvisor.UserModule.Infrastructure.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinAdvisor.UserModule.Infrastructure;

public static class UserModuleInfrastructureConfiguration
{
    public static IServiceCollection AddUserModuleInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISaveChangesInterceptor, DomainEventInterceptors>();
        services.AddPooledDbContextFactory<UserModuleDbContext>(options =>
        {

            var interceptor = services.BuildServiceProvider()
                .GetRequiredService<ISaveChangesInterceptor>();

            options.AddInterceptors(interceptor);
            options.UseSqlServer(configuration.GetConnectionString("DbConnection"),
            sqlOptions =>
            {
                sqlOptions.MigrationsHistoryTable("__EFMigrationsHistory", Schemas.Users);
                sqlOptions.MigrationsAssembly(Assembly.GetAssembly(typeof(FinAdvisorUserModule))!.FullName);
            });
        });

        services.AddSingleton<IUserRepository, UserRepository>();

        return services;
    }
}