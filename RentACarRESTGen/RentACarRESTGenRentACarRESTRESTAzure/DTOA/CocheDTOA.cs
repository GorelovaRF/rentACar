using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace RentACarRESTGenRentACarRESTRESTAzure.DTOA
{
public class CocheDTOA
{
private int numLicencia;
public int NumLicencia
{
        get { return numLicencia; }
        set { numLicencia = value; }
}

private RentACarRESTGenNHibernate.Enumerated.RentACarREST.CategoriaCocheEnum categoria;
public RentACarRESTGenNHibernate.Enumerated.RentACarREST.CategoriaCocheEnum Categoria
{
        get { return categoria; }
        set { categoria = value; }
}

private RentACarRESTGenNHibernate.Enumerated.RentACarREST.EstadoCocheEnum estado;
public RentACarRESTGenNHibernate.Enumerated.RentACarREST.EstadoCocheEnum Estado
{
        get { return estado; }
        set { estado = value; }
}
}
}
