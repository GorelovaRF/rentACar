
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
 * Clase Proveedor:
 *
 */

namespace RentACarRESTGenNHibernate.CAD.RentACarREST
{
public partial class ProveedorCAD : BasicCAD, IProveedorCAD
{
public ProveedorCAD() : base ()
{
}

public ProveedorCAD(ISession sessionAux) : base (sessionAux)
{
}



public ProveedorEN ReadOIDDefault (int id
                                   )
{
        ProveedorEN proveedorEN = null;

        try
        {
                SessionInitializeTransaction ();
                proveedorEN = (ProveedorEN)session.Get (typeof(ProveedorEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in ProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return proveedorEN;
}

public System.Collections.Generic.IList<ProveedorEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ProveedorEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ProveedorEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ProveedorEN>();
                        else
                                result = session.CreateCriteria (typeof(ProveedorEN)).List<ProveedorEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in ProveedorCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ProveedorEN proveedor)
{
        try
        {
                SessionInitializeTransaction ();
                ProveedorEN proveedorEN = (ProveedorEN)session.Load (typeof(ProveedorEN), proveedor.Id);

                session.Update (proveedorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in ProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ProveedorEN proveedor)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (proveedor);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in ProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return proveedor.Id;
}

public void Modify (ProveedorEN proveedor)
{
        try
        {
                SessionInitializeTransaction ();
                ProveedorEN proveedorEN = (ProveedorEN)session.Load (typeof(ProveedorEN), proveedor.Id);
                session.Update (proveedorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in ProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                ProveedorEN proveedorEN = (ProveedorEN)session.Load (typeof(ProveedorEN), id);
                session.Delete (proveedorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in ProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AsignarCoche (int p_Proveedor_OID, System.Collections.Generic.IList<int> p_coche_OIDs)
{
        RentACarRESTGenNHibernate.EN.RentACarREST.ProveedorEN proveedorEN = null;
        try
        {
                SessionInitializeTransaction ();
                proveedorEN = (ProveedorEN)session.Load (typeof(ProveedorEN), p_Proveedor_OID);
                RentACarRESTGenNHibernate.EN.RentACarREST.CocheEN cocheENAux = null;
                if (proveedorEN.Coche == null) {
                        proveedorEN.Coche = new System.Collections.Generic.List<RentACarRESTGenNHibernate.EN.RentACarREST.CocheEN>();
                }

                foreach (int item in p_coche_OIDs) {
                        cocheENAux = new RentACarRESTGenNHibernate.EN.RentACarREST.CocheEN ();
                        cocheENAux = (RentACarRESTGenNHibernate.EN.RentACarREST.CocheEN)session.Load (typeof(RentACarRESTGenNHibernate.EN.RentACarREST.CocheEN), item);
                        cocheENAux.Proveedor.Add (proveedorEN);

                        proveedorEN.Coche.Add (cocheENAux);
                }


                session.Update (proveedorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in ProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
