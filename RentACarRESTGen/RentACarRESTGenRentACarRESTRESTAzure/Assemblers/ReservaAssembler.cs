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
public static class ReservaAssembler
{
public static ReservaDTOA Convert (ReservaEN en, NHibernate.ISession session = null)
{
        ReservaDTOA dto = null;
        ReservaRESTCAD reservaRESTCAD = null;
        ReservaCEN reservaCEN = null;
        ReservaCP reservaCP = null;

        if (en != null) {
                dto = new ReservaDTOA ();
                reservaRESTCAD = new ReservaRESTCAD (session);
                reservaCEN = new ReservaCEN (reservaRESTCAD);
                reservaCP = new ReservaCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Inicio = en.Inicio;


                dto.Final = en.Final;


                //
                // TravesalLink

                /* Rol: Reserva o--> Coche */
                dto.Coches = CocheAssembler.Convert ((CocheEN)en.Coche, session);


                //
                // Service
        }

        return dto;
}
}
}
