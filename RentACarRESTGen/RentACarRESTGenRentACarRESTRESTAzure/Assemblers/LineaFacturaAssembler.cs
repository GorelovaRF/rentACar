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
public static class LineaFacturaAssembler
{
public static LineaFacturaDTOA Convert (LineaFacturaEN en, NHibernate.ISession session = null)
{
        LineaFacturaDTOA dto = null;
        LineaFacturaRESTCAD lineaFacturaRESTCAD = null;
        LineaFacturaCEN lineaFacturaCEN = null;
        LineaFacturaCP lineaFacturaCP = null;

        if (en != null) {
                dto = new LineaFacturaDTOA ();
                lineaFacturaRESTCAD = new LineaFacturaRESTCAD (session);
                lineaFacturaCEN = new LineaFacturaCEN (lineaFacturaRESTCAD);
                lineaFacturaCP = new LineaFacturaCP (session);





                //
                // Attributes

                dto.NumLinea = en.NumLinea;

                dto.Precio = en.Precio;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
