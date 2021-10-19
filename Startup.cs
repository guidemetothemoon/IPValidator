
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Threading.Tasks;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddMvc(options =>
        {
            options.EnableEndpointRouting = false;
        });
        services.AddAuthentication();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo() { Title = "RequestValidator", Version = "v1" });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {           
            app.UseDeveloperExceptionPage();            
        }
        else
        {
            app.UseHsts();
        }

        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "Request Validator v1"));
        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
        });

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthentication();

        app.UseMvc(x =>
        {
            x.MapRoute("Default", "{controller}", defaults: new { controller = "RequestValidator" });
        });
    }

    public static async Task Main(string[] args)
    {
        await WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build()
            .RunAsync();
    }
}

