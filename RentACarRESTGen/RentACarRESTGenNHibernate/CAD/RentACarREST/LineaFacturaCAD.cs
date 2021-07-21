
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
 * Clase LineaFactura:
 *
 */

namespace RentACarRESTGenNHibernate.CAD.RentACarREST
{
public partial class LineaFacturaCAD : BasicCAD, ILineaFacturaCAD
{
public LineaFacturaCAD() : base ()
{
}

public LineaFacturaCAD(ISession sessionAux) : base (sessionAux)
{
}



public LineaFacturaEN ReadOIDDefault (int numLinea
                                      )
{
        LineaFacturaEN lineaFacturaEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineaFacturaEN = (LineaFacturaEN)session.Get (typeof(LineaFacturaEN), numLinea);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in LineaFacturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaFacturaEN;
}

public System.Collections.Generic.IList<LineaFacturaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<LineaFacturaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(LineaFacturaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<LineaFacturaEN>();
                        else
                                result = session.CreateCriteria (typeof(LineaFacturaEN)).List<LineaFacturaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in LineaFacturaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (LineaFacturaEN lineaFactura)
{
        try
        {
                SessionInitializeTransaction ();
                LineaFacturaEN lineaFacturaEN = (LineaFacturaEN)session.Load (typeof(LineaFacturaEN), lineaFactura.NumLinea);



                lineaFacturaEN.Precio = lineaFactura.Precio;

                session.Update (lineaFacturaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in LineaFacturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearLinea (LineaFacturaEN lineaFactura)
{
        try
        {
                SessionInitializeTransaction ();
                if (lineaFactura.Factura != null) {
                        // Argumento OID y no colección.
                        lineaFactura.Factura = (RentACarRESTGenNHibernate.EN.RentACarREST.FacturaEN)session.Load (typeof(RentACarRESTGenNHibernate.EN.RentACarREST.FacturaEN), lineaFactura.Factura.Id);

                        lineaFactura.Factura.LineaFactura
                        .Add (lineaFactura);
                }
                if (lineaFactura.Reserva != null) {
                        // Argumento OID y no colección.
                        lineaFactura.Reserva = (RentACarRESTGenNHibernate.EN.RentACarREST.ReservaEN)session.Load (typeof(RentACarRESTGenNHibernate.EN.RentACarREST.ReservaEN), lineaFactura.Reserva.Id);

                        lineaFactura.Reserva.LineaFactura
                                = lineaFactura;
                }

                session.Save (lineaFactura);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in LineaFacturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaFactura.NumLinea;
}
}
}
