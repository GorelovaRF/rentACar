
using System;
using RentACarRESTGenNHibernate.EN.RentACarREST;

namespace RentACarRESTGenNHibernate.CAD.RentACarREST
{
public partial interface ICocheCAD
{
CocheEN ReadOIDDefault (int numLicencia
                        );

void ModifyDefault (CocheEN coche);

System.Collections.Generic.IList<CocheEN> ReadAllDefault (int first, int size);



int CrearCoche (CocheEN coche);

void BorrarCoche (int numLicencia
                  );


void AsignarReserva (int p_Coche_OID, int p_reserva_OID);

void DesasignarReserva (int p_Coche_OID, int p_reserva_OID);



void Modificar (CocheEN coche);


System.Collections.Generic.IList<RentACarRESTGenNHibernate.EN.RentACarREST.CocheEN> DameCochesDisponibles (int first, int size);
}
}
