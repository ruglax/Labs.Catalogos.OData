using System.Collections.Generic;
using Labs.Catalogos.OData.Internal;
using Labs.Excel.Loader.Model;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Cors;

namespace Labs.Catalogos.OData.Controllers
{
    [EnableQuery]
    public class CodigoPostalController : ODataBaseController
    {
        [EnableCors(Constantes.CorsPolicy)]
        public IEnumerable<c_CodigoPostal> Get()
        {
            return DbCatalogContext.CodigoPostal;
        }
    }
}