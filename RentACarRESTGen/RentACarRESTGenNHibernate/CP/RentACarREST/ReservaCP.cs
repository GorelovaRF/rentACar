
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using RentACarRESTGenNHibernate.Exceptions;
using RentACarRESTGenNHibernate.EN.RentACarREST;
using RentACarRESTGenNHibernate.CAD.RentACarREST;
using RentACarRESTGenNHibernate.CEN.RentACarREST;



namespace RentACarRESTGenNHibernate.CP.RentACarREST
{
public partial class ReservaCP : BasicCP
{
public ReservaCP() : base ()
{
}

public ReservaCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
