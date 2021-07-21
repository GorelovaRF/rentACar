

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
 *      Definition of the class ReservaCEN
 *
 */
public partial class ReservaCEN
{
private IReservaCAD _IReservaCAD;

public ReservaCEN()
{
        this._IReservaCAD = new ReservaCAD ();
}

public ReservaCEN(IReservaCAD _IReservaCAD)
{
        this._IReservaCAD = _IReservaCAD;
}

public IReservaCAD get_IReservaCAD ()
{
        return this._IReservaCAD;
}

public int CrearReserva (string p_cliente, Nullable<DateTime> p_inicio, Nullable<DateTime> p_final)
{
        ReservaEN reservaEN = null;
        int oid;

        //Initialized ReservaEN
        reservaEN = new ReservaEN ();

        if (p_cliente != null) {
                // El argumento p_cliente -> Property cliente es oid = false
                // Lista de oids id
                reservaEN.Cliente = new RentACarRESTGenNHibernate.EN.RentACarREST.ClienteEN ();
                reservaEN.Cliente.DNI = p_cliente;
        }

        reservaEN.Inicio = p_inicio;

        reservaEN.Final = p_final;

        //Call to ReservaCAD

        oid = _IReservaCAD.CrearReserva (reservaEN);
        return oid;
}

public void BorrarReserva (int id
                           )
{
        _IReservaCAD.BorrarReserva (id);
}

public void AsignarCoche (int p_Reserva_OID, string p_cliente_OID)
{
        //Call to ReservaCAD

        _IReservaCAD.AsignarCoche (p_Reserva_OID, p_cliente_OID);
}
}
}
