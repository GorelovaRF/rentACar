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
public static class ClienteRegistradoAssembler
{
public static ClienteRegistradoDTOA Convert (ClienteEN en, NHibernate.ISession session = null)
{
        ClienteRegistradoDTOA dto = null;
        ClienteRegistradoRESTCAD clienteRegistradoRESTCAD = null;
        ClienteCEN clienteCEN = null;
        ClienteCP clienteCP = null;

        if (en != null) {
                dto = new ClienteRegistradoDTOA ();
                clienteRegistradoRESTCAD = new ClienteRegistradoRESTCAD (session);
                clienteCEN = new ClienteCEN (clienteRegistradoRESTCAD);
                clienteCP = new ClienteCP (session);





                //
                // Attributes

                dto.DNI = en.DNI;

                dto.Nombre = en.Nombre;


                dto.Direccion = en.Direccion;


                dto.Telefono = en.Telefono;


                //
                // TravesalLink

                /* Rol: ClienteRegistrado o--> Factura */
                dto.Facturas = null;
                List<FacturaEN> Facturas = clienteRegistradoRESTCAD.Facturas (en.DNI).ToList ();
                if (Facturas != null) {
                        dto.Facturas = new List<FacturaDTOA>();
                        foreach (FacturaEN entry in Facturas)
                                dto.Facturas.Add (FacturaAssembler.Convert (entry, session));
                }


                //
                // Service
        }

        return dto;
}
}
}
