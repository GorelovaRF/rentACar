
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
public partial class LineaFacturaCP : BasicCP
{
public LineaFacturaCP() : base ()
{
}

public LineaFacturaCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
