using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labs.Catalogos.OData.DataAccess;
using Labs.Catalogos.OData.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OData.Edm;

namespace Labs.Catalogos.OData
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers();
            services.AddOData();
            services.AddODataQueryFilter();
            services.AddDbContext<DbCatalogContext>(ctx =>
            {
                string connectionString = Configuration.GetConnectionString("DBCataloogsV4");
                ctx.UseSqlServer(connectionString);
            });
            services.AddMvc(options => { options.EnableEndpointRouting = false; });
            services.AddCors(opt =>
            {
                opt.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });

            });

        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();
            //app.UseOData("odata", "odata", CeateEdmModel());
            app.UseMvc(builder =>
            {
                builder.Select().Filter().OrderBy().Expand().Count().MaxTop(100);
                builder.MapODataServiceRoute("odata", "odata", CeateEdmModel());
                builder.EnableDependencyInjection();
            });
            app.UseCors(MyAllowSpecificOrigins);


        }

        private static IEdmModel CeateEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<c_Aduana>("Aduanas");
            builder.EntitySet<c_ClaveUnidad>("ClavesUnidad");
            builder.EntitySet<c_CodigoPostal>("CodigosPostales");
            return builder.GetEdmModel();
        }
    }
}
