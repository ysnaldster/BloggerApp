using BlogApplication.Api;
using BlogApplication.Infrastructure.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using test.Setup;

namespace test.Configuration.Containers;

public class AppFactoryTestContainer : WebApplicationFactory<Startup>
{
    private readonly string _connectionString;

    public AppFactoryTestContainer(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.RemoveDbContext<BlogApplicationContext>();
            services.AddDbContext<BlogApplicationContext>(options => { options.UseNpgsql(_connectionString); });
            services.EnsureDbCreated<BlogApplicationContext>();
        });
    }

}