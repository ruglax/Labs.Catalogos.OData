using System.Linq;
using Labs.Catalogos.OData.Internal;
using Labs.Excel.Loader.Model;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Cors;

namespace Labs.Catalogos.OData.Controllers
{
    [EnableQuery]
    [EnableCors(Constantes.CorsPolicy)]
    public class MonedaController : ODataBaseController
    {
        public IQueryable<c_Moneda> Get()
        {
            return DbCatalogContext.Moneda;
        }
    }
}
