using System;
using System.Collections.Generic;
using RentACarRESTGenNHibernate.EN.RentACarREST;
using RentACarRESTGenRentACarRESTRESTAzure.DTO;

namespace RentACarRESTGenRentACarRESTRESTAzure.AssemblersDTO
{
public class ReservaAssemblerDTO {
public static IList<ReservaEN> ConvertList (IList<ReservaDTO> lista)
{
        IList<ReservaEN> result = new List<ReservaEN>();
        foreach (ReservaDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static ReservaEN Convert (ReservaDTO dto)
{
        ReservaEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new ReservaEN ();



                        if (dto.Cliente_oid != null) {
                                RentACarRESTGenNHibernate.CAD.RentACarREST.IClienteCAD clienteCAD = new RentACarRESTGenNHibernate.CAD.RentACarREST.ClienteCAD ();

                                newinstance.Cliente = clienteCAD.ReadOIDDefault (dto.Cliente_oid);
                        }
                        newinstance.Id = dto.Id;
                        if (dto.Coche_oid != -1) {
                                RentACarRESTGenNHibernate.CAD.RentACarREST.ICocheCAD cocheCAD = new RentACarRESTGenNHibernate.CAD.RentACarREST.CocheCAD ();

                                newinstance.Coche = cocheCAD.ReadOIDDefault (dto.Coche_oid);
                        }
                        if (dto.LineaFactura_oid != -1) {
                                RentACarRESTGenNHibernate.CAD.RentACarREST.ILineaFacturaCAD lineaFacturaCAD = new RentACarRESTGenNHibernate.CAD.RentACarREST.LineaFacturaCAD ();

                                newinstance.LineaFactura = lineaFacturaCAD.ReadOIDDefault (dto.LineaFactura_oid);
                        }
                        newinstance.Inicio = dto.Inicio;
                        newinstance.Final = dto.Final;
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
