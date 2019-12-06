﻿using System.Collections.Generic;
using Labs.Catalogos.OData.Internal;
using Labs.Excel.Loader.Model;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Cors;

namespace Labs.Catalogos.OData.Controllers
{
    [EnableQuery]
    public class ClaveProdServController : ODataBaseController
    {
        [EnableCors(Constantes.CorsPolicy)]
        public IEnumerable<c_ClaveProdServ> Get()
        {
            return DbCatalogContext.ClavesProdServ;
        }
    }
}