
using System;
using RentACarRESTGenNHibernate.EN.RentACarREST;

namespace RentACarRESTGenNHibernate.CAD.RentACarREST
{
public partial interface IClienteCAD
{
ClienteEN ReadOIDDefault (string DNI
                          );

void ModifyDefault (ClienteEN cliente);

System.Collections.Generic.IList<ClienteEN> ReadAllDefault (int first, int size);



string CrearCliente (ClienteEN cliente);

void BorrarCliente (string DNI
                    );


void Modificar (ClienteEN cliente);


ClienteEN ReadOID (string DNI
                   );


System.Collections.Generic.IList<ClienteEN> ReadAll (int first, int size);
}
}
