using BlogApplication.Domain.Interfaces;
using BlogApplication.Domain.Services;
using BlogApplication.Infrastructure.Context;
using BlogApplication.Infrastructure.Repositories;

namespace BlogApplication.Api.Configurations;

public static class DependencyInjection
{
    public static void AddInfrastructureApi(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        services.AddNpgsql<BlogApplicationContext>(connectionString);
        services.AddScoped<IPostService, PostService>();
        services.AddScoped<IPostRepository, PostRepository>();
        
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
}