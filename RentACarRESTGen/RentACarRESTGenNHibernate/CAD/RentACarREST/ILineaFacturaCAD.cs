
using System;
using RentACarRESTGenNHibernate.EN.RentACarREST;

namespace RentACarRESTGenNHibernate.CAD.RentACarREST
{
public partial interface ILineaFacturaCAD
{
LineaFacturaEN ReadOIDDefault (int numLinea
                               );

void ModifyDefault (LineaFacturaEN lineaFactura);

System.Collections.Generic.IList<LineaFacturaEN> ReadAllDefault (int first, int size);



int CrearLinea (LineaFacturaEN lineaFactura);
}
}
