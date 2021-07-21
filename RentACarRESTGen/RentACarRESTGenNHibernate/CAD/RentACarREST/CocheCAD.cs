
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
 * Clase Coche:
 *
 */

namespace RentACarRESTGenNHibernate.CAD.RentACarREST
{
public partial class CocheCAD : BasicCAD, ICocheCAD
{
public CocheCAD() : base ()
{
}

public CocheCAD(ISession sessionAux) : base (sessionAux)
{
}



public CocheEN ReadOIDDefault (int numLicencia
                               )
{
        CocheEN cocheEN = null;

        try
        {
                SessionInitializeTransaction ();
                cocheEN = (CocheEN)session.Get (typeof(CocheEN), numLicencia);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in CocheCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cocheEN;
}

public System.Collections.Generic.IList<CocheEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CocheEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CocheEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CocheEN>();
                        else
                                result = session.CreateCriteria (typeof(CocheEN)).List<CocheEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in CocheCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CocheEN coche)
{
        try
        {
                SessionInitializeTransaction ();
                CocheEN cocheEN = (CocheEN)session.Load (typeof(CocheEN), coche.NumLicencia);


                cocheEN.Categoria = coche.Categoria;


                cocheEN.Estado = coche.Estado;


                session.Update (cocheEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in CocheCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearCoche (CocheEN coche)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (coche);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in CocheCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return coche.NumLicencia;
}

public void BorrarCoche (int numLicencia
                         )
{
        try
        {
                SessionInitializeTransaction ();
                CocheEN cocheEN = (CocheEN)session.Load (typeof(CocheEN), numLicencia);
                session.Delete (cocheEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in CocheCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AsignarReserva (int p_Coche_OID, int p_reserva_OID)
{
        RentACarRESTGenNHibernate.EN.RentACarREST.CocheEN cocheEN = null;
        try
        {
                SessionInitializeTransaction ();
                cocheEN = (CocheEN)session.Load (typeof(CocheEN), p_Coche_OID);
                cocheEN.Reserva = (RentACarRESTGenNHibernate.EN.RentACarREST.ReservaEN)session.Load (typeof(RentACarRESTGenNHibernate.EN.RentACarREST.ReservaEN), p_reserva_OID);

                cocheEN.Reserva.Coche = cocheEN;




                session.Update (cocheEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in CocheCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DesasignarReserva (int p_Coche_OID, int p_reserva_OID)
{
        try
        {
                SessionInitializeTransaction ();
                RentACarRESTGenNHibernate.EN.RentACarREST.CocheEN cocheEN = null;
                cocheEN = (CocheEN)session.Load (typeof(CocheEN), p_Coche_OID);

                if (cocheEN.Reserva.Id == p_reserva_OID) {
                        cocheEN.Reserva = null;
                        RentACarRESTGenNHibernate.EN.RentACarREST.ReservaEN reservaEN = (RentACarRESTGenNHibernate.EN.RentACarREST.ReservaEN)session.Load (typeof(RentACarRESTGenNHibernate.EN.RentACarREST.ReservaEN), p_reserva_OID);
                        reservaEN.Coche = null;
                }
                else
                        throw new ModelException ("The identifier " + p_reserva_OID + " in p_reserva_OID you are trying to unrelationer, doesn't exist in CocheEN");

                session.Update (cocheEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in CocheCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Modificar (CocheEN coche)
{
        try
        {
                SessionInitializeTransaction ();
                CocheEN cocheEN = (CocheEN)session.Load (typeof(CocheEN), coche.NumLicencia);

                cocheEN.Categoria = coche.Categoria;


                cocheEN.Estado = coche.Estado;

                session.Update (cocheEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in CocheCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<RentACarRESTGenNHibernate.EN.RentACarREST.CocheEN> DameCochesDisponibles (int first, int size)
{
        System.Collections.Generic.IList<RentACarRESTGenNHibernate.EN.RentACarREST.CocheEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CocheEN self where FROM CocheEN coche where coche.Reserva is empty";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CocheENdameCochesDisponiblesHQL");

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<RentACarRESTGenNHibernate.EN.RentACarREST.CocheEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in CocheCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
