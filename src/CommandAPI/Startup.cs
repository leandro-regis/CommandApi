using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CommandAPI
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;

    }
    //Server=.;Database=CmdApi;Trusted_Connection=True;
    public void ConfigureServices(IServiceCollection services)
    {
      var builder = new SqlConnectionStringBuilder();
      builder.ConnectionString = Configuration["DefaultConnection"];

      services.AddDbContext<CommandContext>(options => options.UseSqlServer(builder.ConnectionString));
      services.AddControllers();
      // services.AddScoped<ICommandAPIRepo, MockCommandAPIRepo>();
      services.AddScoped<ICommandAPIRepo, SqlCommandAPIRepo>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();

      });
    }
  }
}
