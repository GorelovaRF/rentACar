

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
 *      Definition of the class LineaFacturaCEN
 *
 */
public partial class LineaFacturaCEN
{
private ILineaFacturaCAD _ILineaFacturaCAD;

public LineaFacturaCEN()
{
        this._ILineaFacturaCAD = new LineaFacturaCAD ();
}

public LineaFacturaCEN(ILineaFacturaCAD _ILineaFacturaCAD)
{
        this._ILineaFacturaCAD = _ILineaFacturaCAD;
}

public ILineaFacturaCAD get_ILineaFacturaCAD ()
{
        return this._ILineaFacturaCAD;
}

public int CrearLinea (int p_factura, int p_reserva, double p_precio)
{
        LineaFacturaEN lineaFacturaEN = null;
        int oid;

        //Initialized LineaFacturaEN
        lineaFacturaEN = new LineaFacturaEN ();

        if (p_factura != -1) {
                // El argumento p_factura -> Property factura es oid = false
                // Lista de oids numLinea
                lineaFacturaEN.Factura = new RentACarRESTGenNHibernate.EN.RentACarREST.FacturaEN ();
                lineaFacturaEN.Factura.Id = p_factura;
        }


        if (p_reserva != -1) {
                // El argumento p_reserva -> Property reserva es oid = false
                // Lista de oids numLinea
                lineaFacturaEN.Reserva = new RentACarRESTGenNHibernate.EN.RentACarREST.ReservaEN ();
                lineaFacturaEN.Reserva.Id = p_reserva;
        }

        lineaFacturaEN.Precio = p_precio;

        //Call to LineaFacturaCAD

        oid = _ILineaFacturaCAD.CrearLinea (lineaFacturaEN);
        return oid;
}
}
}
