using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.AspNet.Hosting;
using BaudiService.Models;

namespace BaudiService
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940]

        public Startup(IHostingEnvironment env)
        {
            Configuration = new Configuration().AddJsonFile("DBconnection.json").AddEnvironmentVariables();
            BaudiServiceDbContext dbcontext = new BaudiServiceDbContext();
            dbcontext.Buildings.Add(new Building());

        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseWelcomePage();
        }
    }
}
