
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

namespace RentACarRESTGenRentACarRESTRESTAzure.CAD
{
public class ClienteRegistradoRESTCAD : ClienteCAD
{
public ClienteRegistradoRESTCAD()
        : base ()
{
}

public ClienteRegistradoRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public IList<ReservaEN> DameReservas (string DNI)
{
        IList<ReservaEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM ReservaEN self inner join self.Cliente as target with target.DNI=:p_DNI";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_DNI", DNI);




                result = query.List<ReservaEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException) throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in ClienteRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public IList<FacturaEN> Facturas (string DNI)
{
        IList<FacturaEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM FacturaEN self inner join self.Cliente as target with target.DNI=:p_DNI";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_DNI", DNI);




                result = query.List<FacturaEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException) throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in ClienteRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
