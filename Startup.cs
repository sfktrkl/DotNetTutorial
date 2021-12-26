using System.IO;
using Tutorial.Data;
using Tutorial.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.DependencyInjection;

namespace Tutorial
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // To tell the application to use the BookStoreContext.
            // Same connection stream can also be passed from here.
            // Then the OnConfiguring method is not needed.
            services.AddDbContext<BookStoreContext>();

            // To add MVC to our application.
            // services.AddMvc();

            // In version 3.1

            // To add controllers only, for a Web API
            // services.AddControllers();

            // To add views only, for a Razor pages
            // services.AddRazorPages();

            // To add controllers and views
            // We are currently planing to use controllers
            // and views for this application.
            services.AddControllersWithViews();

            // By default Razor file (.cshtml) compiled at two times.
            // Build and Publish.
            // This causes changes to not reflected to the view directly.
            // To fix this problem enable the run time compilation.
            // Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
            // Make changes in the startup file, add it conditionally,
            // so that it won't affect the performance.
#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation().AddViewOptions(option =>
            {
                // It is possible disabling client-side validation.
                // Still, better to apply it for the release version.
                option.HtmlHelperOptions.ClientValidationEnabled = false;
            });
#endif

            // To be able to use the BookRepository dependency.
            services.AddScoped<BookRepository, BookRepository>();
            services.AddScoped<ExtensionRepository, ExtensionRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Use this middleware to be able to use any static files.
            app.UseStaticFiles();

            // If static files are located in other location than wwwroot.
            app.UseStaticFiles(new StaticFileOptions() {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "MyStaticFiles")),
                RequestPath = "/MyStaticFiles"
            });

            // Routing is the process of mapping incoming HTTP requests
            // to a particular resource. It is possible to define a unique
            // URL for each resource. In Asp.net core, routing enabled through
            // middlewares UseRouting and UseEndpoints.
            // There are two types of routing Conventional and Attribute.
            // All the routes should be unique with combination of url + http method
            // For one resource it is possible to define multiple routes.
            // It is not possible to define same route for multiple resources.
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // Routing to HomeController class
                // This add the default pattern which is
                // "{controller=Home}/{action=Index}/{id?}"
                endpoints.MapDefaultControllerRoute();

                /*
                // Conventional routing
                // By using a pattern all HTTP requests should be mapped.
                endpoints.MapControllerRoute(
                    name: "Default",
                    // Create the patter which will map the requests.
                    // ? tells id parameter is optional
                    // /home/aboutus
                    //pattern: "{controller}/{action}/{id?}"
                    // It is possible changing the order of the pattern.
                    // /aboutus/home
                    //pattern: "{action}/{controller}/{id?}"
                    // It is possible to pass a parameter
                    // /aboutus/home/1
                    // It is also possible adding more than one parameter
                    // /aboutus/home/1?name=myname
                    //pattern: "{action}/{controller}/{id?}/{name?}"
                    // Some default values can be applied to the pattern.
                    //pattern: "{controller=Home}/{action=Index}/{id?}"
                );
                */

                // To setup some more routes, which will match with a particular pattern
                endpoints.MapControllerRoute(
                    name: "AboutUs",
                    // /about-us
                    pattern: "about-us",
                    defaults: new { controller = "Home", action = "AboutUs" }
                );
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
