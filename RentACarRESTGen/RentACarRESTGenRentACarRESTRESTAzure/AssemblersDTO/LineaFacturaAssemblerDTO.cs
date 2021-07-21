using System;
using System.Collections.Generic;
using RentACarRESTGenNHibernate.EN.RentACarREST;
using RentACarRESTGenRentACarRESTRESTAzure.DTO;

namespace RentACarRESTGenRentACarRESTRESTAzure.AssemblersDTO
{
public class LineaFacturaAssemblerDTO {
public static IList<LineaFacturaEN> ConvertList (IList<LineaFacturaDTO> lista)
{
        IList<LineaFacturaEN> result = new List<LineaFacturaEN>();
        foreach (LineaFacturaDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static LineaFacturaEN Convert (LineaFacturaDTO dto)
{
        LineaFacturaEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new LineaFacturaEN ();



                        if (dto.Factura_oid != -1) {
                                RentACarRESTGenNHibernate.CAD.RentACarREST.IFacturaCAD facturaCAD = new RentACarRESTGenNHibernate.CAD.RentACarREST.FacturaCAD ();

                                newinstance.Factura = facturaCAD.ReadOIDDefault (dto.Factura_oid);
                        }
                        newinstance.NumLinea = dto.NumLinea;
                        if (dto.Reserva_oid != -1) {
                                RentACarRESTGenNHibernate.CAD.RentACarREST.IReservaCAD reservaCAD = new RentACarRESTGenNHibernate.CAD.RentACarREST.ReservaCAD ();

                                newinstance.Reserva = reservaCAD.ReadOIDDefault (dto.Reserva_oid);
                        }
                        newinstance.Precio = dto.Precio;
                }
        }
        catch (Exception ex)
        {
                throw ex;
        }
        return newinstance;
}
}
}
