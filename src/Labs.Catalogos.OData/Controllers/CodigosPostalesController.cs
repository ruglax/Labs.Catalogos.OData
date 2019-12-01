using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labs.Catalogos.OData.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Labs.Catalogos.OData.Controllers
{
    [EnableQuery]
    public class CodigosPostalesController : ODataBaseController
    {
        [EnableCors("_myAllowSpecificOrigins")]
        public IEnumerable<c_CodigoPostal> Get()
        {
            return DbCatalogContext.CodigosPostales;
        }
    }
}