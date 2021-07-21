
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using RentACarRESTGenNHibernate.EN.RentACarREST;
using RentACarRESTGenNHibernate.CAD.RentACarREST;
using RentACarRESTGenNHibernate.CEN.RentACarREST;



/*PROTECTED REGION ID(usingRentACarRESTGenNHibernate.CP.RentACarREST_Factura_dameTotal) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace RentACarRESTGenNHibernate.CP.RentACarREST
{
public partial class FacturaCP : BasicCP
{
public double DameTotal (int p_oid)
{
        /*PROTECTED REGION ID(RentACarRESTGenNHibernate.CP.RentACarREST_Factura_dameTotal) ENABLED START*/

        IFacturaCAD facturaCAD = null;
        FacturaCEN facturaCEN = null;

        double result = 0;


        try
        {
                SessionInitializeTransaction ();
                facturaCAD = new FacturaCAD (session);
                facturaCEN = new  FacturaCEN (facturaCAD);



                // Write here your custom transaction ...
                FacturaEN factura = facturaCAD.ReadOIDDefault (p_oid);
                foreach (LineaFacturaEN linea in factura.LineaFactura) {
                        result += linea.Precio;
                }


                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
