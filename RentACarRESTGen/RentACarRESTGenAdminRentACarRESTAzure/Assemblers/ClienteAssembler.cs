using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;

using RentACarRESTGenAdminRentACarRESTAzure.DTOA;
using RentACarRESTGenAdminRentACarRESTAzure.CAD;
using RentACarRESTGenNHibernate.EN.RentACarREST;
using RentACarRESTGenNHibernate.CEN.RentACarREST;
using RentACarRESTGenNHibernate.CAD.RentACarREST;
using RentACarRESTGenNHibernate.CP.RentACarREST;

namespace RentACarRESTGenAdminRentACarRESTAzure.Assemblers
{
public static class ClienteAssembler
{
public static ClienteDTOA Convert (ClienteEN en, NHibernate.ISession session = null)
{
        ClienteDTOA dto = null;
        ClienteRESTCAD clienteRESTCAD = null;
        ClienteCEN clienteCEN = null;
        ClienteCP clienteCP = null;

        if (en != null) {
                dto = new ClienteDTOA ();
                clienteRESTCAD = new ClienteRESTCAD (session);
                clienteCEN = new ClienteCEN (clienteRESTCAD);
                clienteCP = new ClienteCP (session);





                //
                // Attributes

                dto.DNI = en.DNI;

                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
