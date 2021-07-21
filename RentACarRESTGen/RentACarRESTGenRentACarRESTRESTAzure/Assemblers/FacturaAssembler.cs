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
public static class FacturaAssembler
{
public static FacturaDTOA Convert (FacturaEN en, NHibernate.ISession session = null)
{
        FacturaDTOA dto = null;
        FacturaRESTCAD facturaRESTCAD = null;
        FacturaCEN facturaCEN = null;
        FacturaCP facturaCP = null;

        if (en != null) {
                dto = new FacturaDTOA ();
                facturaRESTCAD = new FacturaRESTCAD (session);
                facturaCEN = new FacturaCEN (facturaRESTCAD);
                facturaCP = new FacturaCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Fecha = en.Fecha;


                dto.EsPagada = en.EsPagada;


                dto.EsAnulada = en.EsAnulada;


                //
                // TravesalLink

                /* Rol: Factura o--> LineaFactura */
                dto.Lineas = null;
                List<LineaFacturaEN> Lineas = facturaRESTCAD.Lineas (en.Id).ToList ();
                if (Lineas != null) {
                        dto.Lineas = new List<LineaFacturaDTOA>();
                        foreach (LineaFacturaEN entry in Lineas)
                                dto.Lineas.Add (LineaFacturaAssembler.Convert (entry, session));
                }


                //
                // Service

                /* ServiceLink: dameTotal */
                dto.DameTotal = facturaCP.DameTotal (en.Id);
        }

        return dto;
}
}
}
