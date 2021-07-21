
using System;
// Definición clase FacturaEN
namespace RentACarRESTGenNHibernate.EN.RentACarREST
{
public partial class FacturaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo esPagada
 */
private bool esPagada;



/**
 *	Atributo esAnulada
 */
private bool esAnulada;



/**
 *	Atributo cliente
 */
private RentACarRESTGenNHibernate.EN.RentACarREST.ClienteEN cliente;



/**
 *	Atributo lineaFactura
 */
private System.Collections.Generic.IList<RentACarRESTGenNHibernate.EN.RentACarREST.LineaFacturaEN> lineaFactura;



/**
 *	Atributo total
 */
private float total;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual bool EsPagada {
        get { return esPagada; } set { esPagada = value;  }
}



public virtual bool EsAnulada {
        get { return esAnulada; } set { esAnulada = value;  }
}



public virtual RentACarRESTGenNHibernate.EN.RentACarREST.ClienteEN Cliente {
        get { return cliente; } set { cliente = value;  }
}



public virtual System.Collections.Generic.IList<RentACarRESTGenNHibernate.EN.RentACarREST.LineaFacturaEN> LineaFactura {
        get { return lineaFactura; } set { lineaFactura = value;  }
}



public virtual float Total {
        get { return total; } set { total = value;  }
}





public FacturaEN()
{
        lineaFactura = new System.Collections.Generic.List<RentACarRESTGenNHibernate.EN.RentACarREST.LineaFacturaEN>();
}



public FacturaEN(int id, Nullable<DateTime> fecha, bool esPagada, bool esAnulada, RentACarRESTGenNHibernate.EN.RentACarREST.ClienteEN cliente, System.Collections.Generic.IList<RentACarRESTGenNHibernate.EN.RentACarREST.LineaFacturaEN> lineaFactura, float total
                 )
{
        this.init (Id, fecha, esPagada, esAnulada, cliente, lineaFactura, total);
}


public FacturaEN(FacturaEN factura)
{
        this.init (Id, factura.Fecha, factura.EsPagada, factura.EsAnulada, factura.Cliente, factura.LineaFactura, factura.Total);
}

private void init (int id
                   , Nullable<DateTime> fecha, bool esPagada, bool esAnulada, RentACarRESTGenNHibernate.EN.RentACarREST.ClienteEN cliente, System.Collections.Generic.IList<RentACarRESTGenNHibernate.EN.RentACarREST.LineaFacturaEN> lineaFactura, float total)
{
        this.Id = id;


        this.Fecha = fecha;

        this.EsPagada = esPagada;

        this.EsAnulada = esAnulada;

        this.Cliente = cliente;

        this.LineaFactura = lineaFactura;

        this.Total = total;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        FacturaEN t = obj as FacturaEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
