
using System;
using System.Text;
using RentACarRESTGenNHibernate.CEN.RentACarREST;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using RentACarRESTGenNHibernate.EN.RentACarREST;
using RentACarRESTGenNHibernate.Exceptions;


/*
 * Clase Factura:
 *
 */

namespace RentACarRESTGenNHibernate.CAD.RentACarREST
{
public partial class FacturaCAD : BasicCAD, IFacturaCAD
{
public FacturaCAD() : base ()
{
}

public FacturaCAD(ISession sessionAux) : base (sessionAux)
{
}



public FacturaEN ReadOIDDefault (int id
                                 )
{
        FacturaEN facturaEN = null;

        try
        {
                SessionInitializeTransaction ();
                facturaEN = (FacturaEN)session.Get (typeof(FacturaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in FacturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return facturaEN;
}

public System.Collections.Generic.IList<FacturaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<FacturaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(FacturaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<FacturaEN>();
                        else
                                result = session.CreateCriteria (typeof(FacturaEN)).List<FacturaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in FacturaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (FacturaEN factura)
{
        try
        {
                SessionInitializeTransaction ();
                FacturaEN facturaEN = (FacturaEN)session.Load (typeof(FacturaEN), factura.Id);

                facturaEN.Fecha = factura.Fecha;


                facturaEN.EsPagada = factura.EsPagada;


                facturaEN.EsAnulada = factura.EsAnulada;




                facturaEN.Total = factura.Total;

                session.Update (facturaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in FacturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearFactura (FacturaEN factura)
{
        try
        {
                SessionInitializeTransaction ();
                if (factura.Cliente != null) {
                        // Argumento OID y no colección.
                        factura.Cliente = (RentACarRESTGenNHibernate.EN.RentACarREST.ClienteEN)session.Load (typeof(RentACarRESTGenNHibernate.EN.RentACarREST.ClienteEN), factura.Cliente.DNI);

                        factura.Cliente.Factura
                        .Add (factura);
                }
                if (factura.LineaFactura != null) {
                        foreach (RentACarRESTGenNHibernate.EN.RentACarREST.LineaFacturaEN item in factura.LineaFactura) {
                                item.Factura = factura;
                                session.Save (item);
                        }
                }

                session.Save (factura);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in FacturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return factura.Id;
}
}
}
