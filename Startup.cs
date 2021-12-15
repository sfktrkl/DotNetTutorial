using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Tutorial
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

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
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello");
                });
            });
        }

        // https://www.youtube.com/watch?v=10AWqnAph2g&list=PLaFzfwmPR7_LTXu0Vz9Zz_Y0OMMC7ArHZ&index=9
        public void Configure_Tutorial8(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from first middleware\n");

                // Use next to send the request to the second middleware.
                await next();

                await context.Response.WriteAsync("Hello from first middleware response\n");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from second middleware\n");

                await next();

                await context.Response.WriteAsync("Hello from second middleware response\n");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from third middleware\n");

                await next();

                await context.Response.WriteAsync("Hello from third middleware response\n");
            });

            // Before using end points routing should be used.
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // MapGet matches all HTTP Get requests.
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello\n");
                });
            });

            app.UseEndpoints(endpoints =>
            {
                // Map matches all HTTP requests.
                endpoints.Map("/World", async context =>
                {
                    await context.Response.WriteAsync("Hello World\n");
                });
            });
        }
    }
}
