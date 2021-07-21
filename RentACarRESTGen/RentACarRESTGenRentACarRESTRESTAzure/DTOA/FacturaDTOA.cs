using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace RentACarRESTGenRentACarRESTRESTAzure.DTOA
{
public class FacturaDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private Nullable<DateTime> fecha;
public Nullable<DateTime> Fecha
{
        get { return fecha; }
        set { fecha = value; }
}

private bool esPagada;
public bool EsPagada
{
        get { return esPagada; }
        set { esPagada = value; }
}

private bool esAnulada;
public bool EsAnulada
{
        get { return esAnulada; }
        set { esAnulada = value; }
}


/* Rol: Factura o--> LineaFactura */
private IList<LineaFacturaDTOA> lineas;
public IList<LineaFacturaDTOA> Lineas
{
        get { return lineas; }
        set { lineas = value; }
}


/* ServiceLink: dameTotal */
private double dameTotal;
public double DameTotal
{
        get { return dameTotal; }
        set { dameTotal = value; }
}
}
}
