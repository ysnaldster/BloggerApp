using BlogApplication.Domain.Interfaces;
using BlogApplication.Domain.Services;
using BlogApplication.Infrastructure.Context;
using BlogApplication.Infrastructure.Repositories;

namespace BlogApplication.Api;

public class Startup
{
   public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
   
       public void ConfigureServices(IServiceCollection services)
       {
           var connectionString = Configuration.GetConnectionString("DefaultConnection");

           services.AddNpgsql<BlogApplicationContext>(connectionString);
           services.AddScoped<IPostService, PostService>();
           services.AddScoped<IPostRepository, PostRepository>();
           services.AddSwaggerGen();
           services.AddAuthorization();
           services.AddControllers();
           AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
       }

       private IConfiguration Configuration { get; }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseCors();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
}