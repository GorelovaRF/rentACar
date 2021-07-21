
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
public class LineaFacturaRESTCAD : LineaFacturaCAD
{
public LineaFacturaRESTCAD()
        : base ()
{
}

public LineaFacturaRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
