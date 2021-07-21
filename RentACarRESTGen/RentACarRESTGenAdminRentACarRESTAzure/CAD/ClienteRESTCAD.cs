
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

namespace RentACarRESTGenAdminRentACarRESTAzure.CAD
{
public class ClienteRESTCAD : ClienteCAD
{
public ClienteRESTCAD()
        : base ()
{
}

public ClienteRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
