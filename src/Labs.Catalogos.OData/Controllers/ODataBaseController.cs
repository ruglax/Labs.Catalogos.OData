using Labs.Excel.Loader.Database;
using Microsoft.AspNet.OData;
using Microsoft.Extensions.DependencyInjection;

namespace Labs.Catalogos.OData.Controllers
{
    public abstract class ODataBaseController : ODataController
    {
        private DbCatalogosContext _dbCatalogContext;

        protected ODataBaseController()
        {
        }

        protected DbCatalogosContext DbCatalogContext
        {
            get
            {

                _dbCatalogContext = _dbCatalogContext ?? HttpContext.RequestServices.GetService<DbCatalogosContext>();
                return _dbCatalogContext;
            }
        }
    }
}
