using System;
using System.Collections.Generic;
using RentACarRESTGenNHibernate.EN.RentACarREST;
using RentACarRESTGenRentACarRESTRESTAzure.DTO;

namespace RentACarRESTGenRentACarRESTRESTAzure.AssemblersDTO
{
public class FacturaAssemblerDTO {
public static IList<FacturaEN> ConvertList (IList<FacturaDTO> lista)
{
        IList<FacturaEN> result = new List<FacturaEN>();
        foreach (FacturaDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static FacturaEN Convert (FacturaDTO dto)
{
        FacturaEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new FacturaEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Fecha = dto.Fecha;
                        newinstance.EsPagada = dto.EsPagada;
                        newinstance.EsAnulada = dto.EsAnulada;
                        if (dto.Cliente_oid != null) {
                                RentACarRESTGenNHibernate.CAD.RentACarREST.IClienteCAD clienteCAD = new RentACarRESTGenNHibernate.CAD.RentACarREST.ClienteCAD ();

                                newinstance.Cliente = clienteCAD.ReadOIDDefault (dto.Cliente_oid);
                        }

                        if (dto.LineaFactura != null) {
                                RentACarRESTGenNHibernate.CAD.RentACarREST.ILineaFacturaCAD lineaFacturaCAD = new RentACarRESTGenNHibernate.CAD.RentACarREST.LineaFacturaCAD ();

                                newinstance.LineaFactura = new System.Collections.Generic.List<RentACarRESTGenNHibernate.EN.RentACarREST.LineaFacturaEN>();
                                foreach (LineaFacturaDTO entry in dto.LineaFactura) {
                                        newinstance.LineaFactura.Add (LineaFacturaAssemblerDTO.Convert (entry));
                                }
                        }
                        newinstance.Total = dto.Total;
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
