using System.Web.Http;
using WebActivatorEx;
using Swashbuckle.Application;
using Swashbuckle.Swagger;
using System.Web.Http.Description;
using System.Collections.Generic;
using Proyecto1;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]
namespace Proyecto1
{
    /*
     * La clase SwaggerConfig , agrega configuracion al API
     */
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "Tarea1_API");
                })
                .EnableSwaggerUi();
        }

    }
}