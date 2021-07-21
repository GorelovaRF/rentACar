

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
 *      Definition of the class ProveedorCEN
 *
 */
public partial class ProveedorCEN
{
private IProveedorCAD _IProveedorCAD;

public ProveedorCEN()
{
        this._IProveedorCAD = new ProveedorCAD ();
}

public ProveedorCEN(IProveedorCAD _IProveedorCAD)
{
        this._IProveedorCAD = _IProveedorCAD;
}

public IProveedorCAD get_IProveedorCAD ()
{
        return this._IProveedorCAD;
}

public int New_ ()
{
        ProveedorEN proveedorEN = null;
        int oid;

        //Initialized ProveedorEN
        proveedorEN = new ProveedorEN ();
        //Call to ProveedorCAD

        oid = _IProveedorCAD.New_ (proveedorEN);
        return oid;
}

public void Modify (int p_Proveedor_OID)
{
        ProveedorEN proveedorEN = null;

        //Initialized ProveedorEN
        proveedorEN = new ProveedorEN ();
        proveedorEN.Id = p_Proveedor_OID;
        //Call to ProveedorCAD

        _IProveedorCAD.Modify (proveedorEN);
}

public void Destroy (int id
                     )
{
        _IProveedorCAD.Destroy (id);
}

public void AsignarCoche (int p_Proveedor_OID, System.Collections.Generic.IList<int> p_coche_OIDs)
{
        //Call to ProveedorCAD

        _IProveedorCAD.AsignarCoche (p_Proveedor_OID, p_coche_OIDs);
}
}
}
