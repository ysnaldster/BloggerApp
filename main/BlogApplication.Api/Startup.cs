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
       public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
}