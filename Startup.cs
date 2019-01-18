using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using keepr.Repositories;
using Keepr.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace Keepr
{
  public class Startup
  {
    private readonly string _connectionString = "";
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
      _connectionString = configuration.GetSection("DB").GetValue<string>("mySQLConnectionString");
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      //ADD USER AUTH through JWT
      services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
          options.LoginPath = "/Account/Login";
          options.Events.OnRedirectToLogin = (context) =>
                  {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                  };
        });
      services.AddCors(options =>
          {
            options.AddPolicy("CorsDevPolicy", builder =>
                  {
                    builder
                              .WithOrigins(new string[]{
                                "http://localhost:8080"
                          })
                              .AllowAnyMethod()
                              .AllowAnyHeader()
                              .AllowCredentials();
                  });
          });

      services.AddMvc();

      services.AddTransient<IDbConnection>(x => CreateDBContext());
      services.AddTransient<UserRepository>();
      services.AddTransient<KeepRepository>();
      services.AddTransient<VaultRepository>();
      services.AddTransient<VaultKeepRepository>();


    }

    private IDbConnection CreateDBContext()
    {
      var connection = new MySqlConnection(_connectionString);
      connection.Open();
      return connection;
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseCors("CorsDevPolicy");
      }
      else
      {
        app.UseHsts();
      }
      app.UseAuthentication();
      app.UseDefaultFiles();
      app.UseStaticFiles();
      app.UseMvc();
    }
  }
}
