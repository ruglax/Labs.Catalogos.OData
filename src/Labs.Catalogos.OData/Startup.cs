using Labs.Catalogos.OData.Internal;
using Labs.Excel.Loader.Database;
using Labs.Excel.Loader.Model;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddDbContext<DbCatalogosContext>(ctx =>
            {
                string connectionString = Configuration.GetConnectionString("DBCataloogsV4");
                ctx.UseSqlServer(connectionString);
            });
            services.AddMvc(options => { options.EnableEndpointRouting = false; });
            services.AddCors(opt =>
            {
                opt.AddPolicy(Constantes.CorsPolicy,
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });

            });

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(builder =>
            {
                builder.Select().Filter().OrderBy().Expand().Count().MaxTop(100);
                builder.MapODataServiceRoute("odata", "odata", CeateEdmModel());
                builder.EnableDependencyInjection();
            });

            app.UseCors(Constantes.CorsPolicy);
        }

        private static IEdmModel CeateEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<c_Aduana>("Aduana");
            builder.EntitySet<c_ClaveProdServ>("ClaveProdServ");
            builder.EntitySet<c_ClaveUnidad>("ClaveUnidad");
            builder.EntitySet<c_CodigoPostal>("CodigoPostal");
            builder.EntitySet<c_FormaPago>("FormaPago");
            builder.EntitySet<c_Impuesto>("Impuesto");
            builder.EntitySet<c_MetodoPago>("MetodoPago");
            builder.EntitySet<c_Moneda>("Moneda");
            builder.EntitySet<c_NumPedimentoAduana>("NumPedimentoAduana");
            builder.EntitySet<c_Pais>("Pais");
            builder.EntitySet<c_PatenteAduanal>("PatenteAduanal");
            builder.EntitySet<c_RegimenFiscal>("RegimenFiscal");
            builder.EntitySet<c_TasaOCuota>("TasaOCuota");
            builder.EntitySet<c_TipoDeComprobante>("TipoDeComprobante");
            builder.EntitySet<c_TipoFactor>("TipoFactor");
            builder.EntitySet<c_TipoRelacion>("TipoRelacion");
            builder.EntitySet<c_UsoCFDI>("UsoCFDI");
            return builder.GetEdmModel();
        }
    }
}
