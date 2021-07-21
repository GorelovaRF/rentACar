
using System;
using RentACarRESTGenNHibernate.EN.RentACarREST;

namespace RentACarRESTGenNHibernate.CAD.RentACarREST
{
public partial interface IProveedorCAD
{
ProveedorEN ReadOIDDefault (int id
                            );

void ModifyDefault (ProveedorEN proveedor);

System.Collections.Generic.IList<ProveedorEN> ReadAllDefault (int first, int size);



int New_ (ProveedorEN proveedor);

void Modify (ProveedorEN proveedor);


void Destroy (int id
              );


void AsignarCoche (int p_Proveedor_OID, System.Collections.Generic.IList<int> p_coche_OIDs);
}
}
