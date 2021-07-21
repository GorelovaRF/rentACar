
using System;
using RentACarRESTGenNHibernate.EN.RentACarREST;

namespace RentACarRESTGenNHibernate.CAD.RentACarREST
{
public partial interface IReservaCAD
{
ReservaEN ReadOIDDefault (int id
                          );

void ModifyDefault (ReservaEN reserva);

System.Collections.Generic.IList<ReservaEN> ReadAllDefault (int first, int size);



int CrearReserva (ReservaEN reserva);

void BorrarReserva (int id
                    );


void AsignarCoche (int p_Reserva_OID, string p_cliente_OID);
}
}
