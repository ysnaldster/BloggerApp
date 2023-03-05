using BlogApplication.Application.Services;
using BlogApplication.Domain.Repositories;
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
           var connectionString = "User ID=postgres;Password=admin;Host=localhost;Port=8082;Database=blog_application_db;";

           services.AddNpgsql<BlogApplicationContext>(connectionString);
           services.AddScoped<IPostService, PostService>();
           services.AddScoped<IPostRepository, PostRepository>();
           services.AddScoped<IUserRepository, UserRepository>();
           services.AddScoped<IUserService, UserService>();
           services.AddScoped<ICommentService, CommentService>();
           services.AddScoped<ICommentRepository, CommentRepository>();
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

            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<BlogApplicationContext>();
            context.Database.EnsureCreated();
        }
}