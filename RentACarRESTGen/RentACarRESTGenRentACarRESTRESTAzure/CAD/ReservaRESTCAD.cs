
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
public class ReservaRESTCAD : ReservaCAD
{
public ReservaRESTCAD()
        : base ()
{
}

public ReservaRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public CocheEN Coches (int id)
{
        CocheEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Coche FROM ReservaEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<CocheEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is RentACarRESTGenNHibernate.Exceptions.ModelException) throw ex;
                throw new RentACarRESTGenNHibernate.Exceptions.DataLayerException ("Error in ReservaRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
