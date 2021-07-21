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
public static class ClienteAnonimoAssembler
{
public static ClienteAnonimoDTOA Convert (ClienteEN en, NHibernate.ISession session = null)
{
        ClienteAnonimoDTOA dto = null;
        ClienteAnonimoRESTCAD clienteAnonimoRESTCAD = null;
        ClienteCEN clienteCEN = null;
        ClienteCP clienteCP = null;

        if (en != null) {
                dto = new ClienteAnonimoDTOA ();
                clienteAnonimoRESTCAD = new ClienteAnonimoRESTCAD (session);
                clienteCEN = new ClienteCEN (clienteAnonimoRESTCAD);
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
