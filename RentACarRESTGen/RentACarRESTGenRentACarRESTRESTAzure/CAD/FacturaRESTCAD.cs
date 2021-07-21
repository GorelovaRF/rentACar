
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
public class FacturaRESTCAD : FacturaCAD
{
public FacturaRESTCAD()
        : base ()
{
}

public FacturaRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public IList<LineaFacturaEN> Lineas (int id)
{
        IList<LineaFacturaEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM LineaFacturaEN self inner join self.Factura as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<LineaFacturaEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException) throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in FacturaRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
