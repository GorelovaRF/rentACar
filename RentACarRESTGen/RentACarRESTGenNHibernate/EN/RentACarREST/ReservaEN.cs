
using System;
// Definición clase ReservaEN
namespace RentACarRESTGenNHibernate.EN.RentACarREST
{
public partial class ReservaEN
{
/**
 *	Atributo cliente
 */
private RentACarRESTGenNHibernate.EN.RentACarREST.ClienteEN cliente;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo coche
 */
private RentACarRESTGenNHibernate.EN.RentACarREST.CocheEN coche;



/**
 *	Atributo lineaFactura
 */
private RentACarRESTGenNHibernate.EN.RentACarREST.LineaFacturaEN lineaFactura;



/**
 *	Atributo inicio
 */
private Nullable<DateTime> inicio;



/**
 *	Atributo final
 */
private Nullable<DateTime> final;






public virtual RentACarRESTGenNHibernate.EN.RentACarREST.ClienteEN Cliente {
        get { return cliente; } set { cliente = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual RentACarRESTGenNHibernate.EN.RentACarREST.CocheEN Coche {
        get { return coche; } set { coche = value;  }
}



public virtual RentACarRESTGenNHibernate.EN.RentACarREST.LineaFacturaEN LineaFactura {
        get { return lineaFactura; } set { lineaFactura = value;  }
}



public virtual Nullable<DateTime> Inicio {
        get { return inicio; } set { inicio = value;  }
}



public virtual Nullable<DateTime> Final {
        get { return final; } set { final = value;  }
}





public ReservaEN()
{
}



public ReservaEN(int id, RentACarRESTGenNHibernate.EN.RentACarREST.ClienteEN cliente, RentACarRESTGenNHibernate.EN.RentACarREST.CocheEN coche, RentACarRESTGenNHibernate.EN.RentACarREST.LineaFacturaEN lineaFactura, Nullable<DateTime> inicio, Nullable<DateTime> final
                 )
{
        this.init (Id, cliente, coche, lineaFactura, inicio, final);
}


public ReservaEN(ReservaEN reserva)
{
        this.init (Id, reserva.Cliente, reserva.Coche, reserva.LineaFactura, reserva.Inicio, reserva.Final);
}

private void init (int id
                   , RentACarRESTGenNHibernate.EN.RentACarREST.ClienteEN cliente, RentACarRESTGenNHibernate.EN.RentACarREST.CocheEN coche, RentACarRESTGenNHibernate.EN.RentACarREST.LineaFacturaEN lineaFactura, Nullable<DateTime> inicio, Nullable<DateTime> final)
{
        this.Id = id;


        this.Cliente = cliente;

        this.Coche = coche;

        this.LineaFactura = lineaFactura;

        this.Inicio = inicio;

        this.Final = final;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ReservaEN t = obj as ReservaEN;
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
