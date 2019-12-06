using System.Linq;
using Labs.Catalogos.OData.Internal;
using Labs.Excel.Loader.Model;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Cors;

namespace Labs.Catalogos.OData.Controllers
{
    [EnableQuery]
    [EnableCors(Constantes.CorsPolicy)]
    public class PatenteAduanalController : ODataBaseController
    {
        public IQueryable<c_PatenteAduanal> Get()
        {
            return DbCatalogContext.PatenteAduanal;
        }
    }
}
