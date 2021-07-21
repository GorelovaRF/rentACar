using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;

using RentACarRESTGenRentACarRESTRESTAzure.DTOA;
using RentACarRESTGenRentACarRESTRESTAzure.CAD;
using RentACarRESTGenNHibernate.EN.RentACarREST;
using RentACarRESTGenNHibernate.CEN.RentACarREST;
using RentACarRESTGenNHibernate.CAD.RentACarREST;
using RentACarRESTGenNHibernate.CP.RentACarREST;

namespace RentACarRESTGenRentACarRESTRESTAzure.Assemblers
{
public static class CocheAssembler
{
public static CocheDTOA Convert (CocheEN en, NHibernate.ISession session = null)
{
        CocheDTOA dto = null;
        CocheRESTCAD cocheRESTCAD = null;
        CocheCEN cocheCEN = null;
        CocheCP cocheCP = null;

        if (en != null) {
                dto = new CocheDTOA ();
                cocheRESTCAD = new CocheRESTCAD (session);
                cocheCEN = new CocheCEN (cocheRESTCAD);
                cocheCP = new CocheCP (session);





                //
                // Attributes

                dto.NumLicencia = en.NumLicencia;

                dto.Categoria = en.Categoria;


                dto.Estado = en.Estado;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
