using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
    this IServiceCollection services,
    IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        #region JWT CONFIG (Application seviyesinde)


        #endregion

        #region AddScopedServices


        #endregion


        return services;
    }
}
