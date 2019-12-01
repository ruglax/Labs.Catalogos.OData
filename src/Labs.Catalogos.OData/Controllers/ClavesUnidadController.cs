using System.Collections;
using System.Collections.Generic;
using Labs.Catalogos.OData.DataAccess;
using Labs.Catalogos.OData.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Labs.Catalogos.OData.Controllers
{
    [EnableQuery]
    public class ClavesUnidadController : ODataBaseController
    {
        [EnableCors("_myAllowSpecificOrigins")]
        public IEnumerable<c_ClaveUnidad> Get()
        {
            return DbCatalogContext.ClavesUnindad;
        }
    }
}
