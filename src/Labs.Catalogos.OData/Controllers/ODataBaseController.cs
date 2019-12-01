using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labs.Catalogos.OData.DataAccess;
using Microsoft.AspNet.OData;
using Microsoft.Extensions.DependencyInjection;

namespace Labs.Catalogos.OData.Controllers
{
    public abstract class ODataBaseController : ODataController
    {
        private DbCatalogContext _dbCatalogContext;

        protected ODataBaseController()
        {
        }

        protected DbCatalogContext DbCatalogContext
        {
            get
            {

                _dbCatalogContext = _dbCatalogContext ?? HttpContext.RequestServices.GetService<DbCatalogContext>();
                return _dbCatalogContext;
            }
        }
    }
}
