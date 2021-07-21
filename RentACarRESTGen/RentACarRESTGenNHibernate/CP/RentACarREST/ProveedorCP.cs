
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
public partial class ProveedorCP : BasicCP
{
public ProveedorCP() : base ()
{
}

public ProveedorCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
