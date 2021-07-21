
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using RentACarRESTGenNHibernate.Exceptions;
using RentACarRESTGenNHibernate.EN.RentACarREST;
using RentACarRESTGenNHibernate.CAD.RentACarREST;


/*PROTECTED REGION ID(usingRentACarRESTGenNHibernate.CEN.RentACarREST_Factura_crearFactura) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace RentACarRESTGenNHibernate.CEN.RentACarREST
{
public partial class FacturaCEN
{
public int CrearFactura (Nullable<DateTime> p_fecha, bool p_esPagada, bool p_esAnulada, string p_cliente, System.Collections.Generic.IList<RentACarRESTGenNHibernate.EN.RentACarREST.LineaFacturaEN> p_lineaFactura)
{
        /*PROTECTED REGION ID(RentACarRESTGenNHibernate.CEN.RentACarREST_Factura_crearFactura_customized) START*/

        FacturaEN facturaEN = null;

        int oid;

        //Initialized FacturaEN
        facturaEN = new FacturaEN ();
        facturaEN.Fecha = p_fecha;

        facturaEN.EsPagada = p_esPagada;

        facturaEN.EsAnulada = p_esAnulada;


        if (p_cliente != null) {
                facturaEN.Cliente = new RentACarRESTGenNHibernate.EN.RentACarREST.ClienteEN ();
                facturaEN.Cliente.DNI = p_cliente;
        }

        facturaEN.LineaFactura = p_lineaFactura;

        //Call to FacturaCAD

        oid = _IFacturaCAD.CrearFactura (facturaEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
