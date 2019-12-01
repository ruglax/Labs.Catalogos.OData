using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Labs.Catalogos.OData.DataAccess;
using Labs.Catalogos.OData.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Labs.Catalogos.OData.Controllers
{
    [EnableQuery]
    [EnableCors("_myAllowSpecificOrigins")]
    public class AduanasController : ODataBaseController
    {
        public IQueryable<c_Aduana> Get()
        {
            return DbCatalogContext.Aduanas;
        }
    }
}
