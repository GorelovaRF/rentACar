

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using RentACarRESTGenNHibernate.Exceptions;

using RentACarRESTGenNHibernate.EN.RentACarREST;
using RentACarRESTGenNHibernate.CAD.RentACarREST;


namespace RentACarRESTGenNHibernate.CEN.RentACarREST
{
/*
 *      Definition of the class CocheCEN
 *
 */
public partial class CocheCEN
{
private ICocheCAD _ICocheCAD;

public CocheCEN()
{
        this._ICocheCAD = new CocheCAD ();
}

public CocheCEN(ICocheCAD _ICocheCAD)
{
        this._ICocheCAD = _ICocheCAD;
}

public ICocheCAD get_ICocheCAD ()
{
        return this._ICocheCAD;
}

public int CrearCoche (RentACarRESTGenNHibernate.Enumerated.RentACarREST.CategoriaCocheEnum p_categoria, RentACarRESTGenNHibernate.Enumerated.RentACarREST.EstadoCocheEnum p_estado)
{
        CocheEN cocheEN = null;
        int oid;

        //Initialized CocheEN
        cocheEN = new CocheEN ();
        cocheEN.Categoria = p_categoria;

        cocheEN.Estado = p_estado;

        //Call to CocheCAD

        oid = _ICocheCAD.CrearCoche (cocheEN);
        return oid;
}

public void BorrarCoche (int numLicencia
                         )
{
        _ICocheCAD.BorrarCoche (numLicencia);
}

public void AsignarReserva (int p_Coche_OID, int p_reserva_OID)
{
        //Call to CocheCAD

        _ICocheCAD.AsignarReserva (p_Coche_OID, p_reserva_OID);
}
public void DesasignarReserva (int p_Coche_OID, int p_reserva_OID)
{
        //Call to CocheCAD

        _ICocheCAD.DesasignarReserva (p_Coche_OID, p_reserva_OID);
}
public void Modificar (int p_Coche_OID, RentACarRESTGenNHibernate.Enumerated.RentACarREST.CategoriaCocheEnum p_categoria, RentACarRESTGenNHibernate.Enumerated.RentACarREST.EstadoCocheEnum p_estado)
{
        CocheEN cocheEN = null;

        //Initialized CocheEN
        cocheEN = new CocheEN ();
        cocheEN.NumLicencia = p_Coche_OID;
        cocheEN.Categoria = p_categoria;
        cocheEN.Estado = p_estado;
        //Call to CocheCAD

        _ICocheCAD.Modificar (cocheEN);
}

public System.Collections.Generic.IList<RentACarRESTGenNHibernate.EN.RentACarREST.CocheEN> DameCochesDisponibles (int first, int size)
{
        return _ICocheCAD.DameCochesDisponibles (first, size);
}
}
}
