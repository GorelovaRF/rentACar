
using System;
// Definición clase CocheEN
namespace RentACarRESTGenNHibernate.EN.RentACarREST
{
public partial class CocheEN
{
/**
 *	Atributo reserva
 */
private RentACarRESTGenNHibernate.EN.RentACarREST.ReservaEN reserva;



/**
 *	Atributo numLicencia
 */
private int numLicencia;



/**
 *	Atributo categoria
 */
private RentACarRESTGenNHibernate.Enumerated.RentACarREST.CategoriaCocheEnum categoria;



/**
 *	Atributo estado
 */
private RentACarRESTGenNHibernate.Enumerated.RentACarREST.EstadoCocheEnum estado;



/**
 *	Atributo proveedor
 */
private System.Collections.Generic.IList<RentACarRESTGenNHibernate.EN.RentACarREST.ProveedorEN> proveedor;






public virtual RentACarRESTGenNHibernate.EN.RentACarREST.ReservaEN Reserva {
        get { return reserva; } set { reserva = value;  }
}



public virtual int NumLicencia {
        get { return numLicencia; } set { numLicencia = value;  }
}



public virtual RentACarRESTGenNHibernate.Enumerated.RentACarREST.CategoriaCocheEnum Categoria {
        get { return categoria; } set { categoria = value;  }
}



public virtual RentACarRESTGenNHibernate.Enumerated.RentACarREST.EstadoCocheEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual System.Collections.Generic.IList<RentACarRESTGenNHibernate.EN.RentACarREST.ProveedorEN> Proveedor {
        get { return proveedor; } set { proveedor = value;  }
}





public CocheEN()
{
        proveedor = new System.Collections.Generic.List<RentACarRESTGenNHibernate.EN.RentACarREST.ProveedorEN>();
}



public CocheEN(int numLicencia, RentACarRESTGenNHibernate.EN.RentACarREST.ReservaEN reserva, RentACarRESTGenNHibernate.Enumerated.RentACarREST.CategoriaCocheEnum categoria, RentACarRESTGenNHibernate.Enumerated.RentACarREST.EstadoCocheEnum estado, System.Collections.Generic.IList<RentACarRESTGenNHibernate.EN.RentACarREST.ProveedorEN> proveedor
               )
{
        this.init (NumLicencia, reserva, categoria, estado, proveedor);
}


public CocheEN(CocheEN coche)
{
        this.init (NumLicencia, coche.Reserva, coche.Categoria, coche.Estado, coche.Proveedor);
}

private void init (int numLicencia
                   , RentACarRESTGenNHibernate.EN.RentACarREST.ReservaEN reserva, RentACarRESTGenNHibernate.Enumerated.RentACarREST.CategoriaCocheEnum categoria, RentACarRESTGenNHibernate.Enumerated.RentACarREST.EstadoCocheEnum estado, System.Collections.Generic.IList<RentACarRESTGenNHibernate.EN.RentACarREST.ProveedorEN> proveedor)
{
        this.NumLicencia = numLicencia;


        this.Reserva = reserva;

        this.Categoria = categoria;

        this.Estado = estado;

        this.Proveedor = proveedor;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CocheEN t = obj as CocheEN;
        if (t == null)
                return false;
        if (NumLicencia.Equals (t.NumLicencia))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.NumLicencia.GetHashCode ();
        return hash;
}
}
}
