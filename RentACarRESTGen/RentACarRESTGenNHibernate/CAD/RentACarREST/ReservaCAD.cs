
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
 * Clase Reserva:
 *
 */

namespace RentACarRESTGenNHibernate.CAD.RentACarREST
{
public partial class ReservaCAD : BasicCAD, IReservaCAD
{
public ReservaCAD() : base ()
{
}

public ReservaCAD(ISession sessionAux) : base (sessionAux)
{
}



public ReservaEN ReadOIDDefault (int id
                                 )
{
        ReservaEN reservaEN = null;

        try
        {
                SessionInitializeTransaction ();
                reservaEN = (ReservaEN)session.Get (typeof(ReservaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in ReservaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return reservaEN;
}

public System.Collections.Generic.IList<ReservaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ReservaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ReservaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ReservaEN>();
                        else
                                result = session.CreateCriteria (typeof(ReservaEN)).List<ReservaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in ReservaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ReservaEN reserva)
{
        try
        {
                SessionInitializeTransaction ();
                ReservaEN reservaEN = (ReservaEN)session.Load (typeof(ReservaEN), reserva.Id);




                reservaEN.Inicio = reserva.Inicio;


                reservaEN.Final = reserva.Final;

                session.Update (reservaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in ReservaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearReserva (ReservaEN reserva)
{
        try
        {
                SessionInitializeTransaction ();
                if (reserva.Cliente != null) {
                        // Argumento OID y no colección.
                        reserva.Cliente = (RentACarRESTGenNHibernate.EN.RentACarREST.ClienteEN)session.Load (typeof(RentACarRESTGenNHibernate.EN.RentACarREST.ClienteEN), reserva.Cliente.DNI);

                        reserva.Cliente.Reserva
                        .Add (reserva);
                }

                session.Save (reserva);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in ReservaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return reserva.Id;
}

public void BorrarReserva (int id
                           )
{
        try
        {
                SessionInitializeTransaction ();
                ReservaEN reservaEN = (ReservaEN)session.Load (typeof(ReservaEN), id);
                session.Delete (reservaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in ReservaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AsignarCoche (int p_Reserva_OID, string p_cliente_OID)
{
        RentACarRESTGenNHibernate.EN.RentACarREST.ReservaEN reservaEN = null;
        try
        {
                SessionInitializeTransaction ();
                reservaEN = (ReservaEN)session.Load (typeof(ReservaEN), p_Reserva_OID);
                reservaEN.Cliente = (RentACarRESTGenNHibernate.EN.RentACarREST.ClienteEN)session.Load (typeof(RentACarRESTGenNHibernate.EN.RentACarREST.ClienteEN), p_cliente_OID);

                reservaEN.Cliente.Reserva.Add (reservaEN);



                session.Update (reservaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in ReservaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
