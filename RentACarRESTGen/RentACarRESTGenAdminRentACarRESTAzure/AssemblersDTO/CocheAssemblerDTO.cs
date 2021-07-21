using System;
using System.Collections.Generic;
using RentACarRESTGenNHibernate.EN.RentACarREST;
using RentACarRESTGenAdminRentACarRESTAzure.DTO;

namespace RentACarRESTGenAdminRentACarRESTAzure.AssemblersDTO
{
public class CocheAssemblerDTO {
public static IList<CocheEN> ConvertList (IList<CocheDTO> lista)
{
        IList<CocheEN> result = new List<CocheEN>();
        foreach (CocheDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static CocheEN Convert (CocheDTO dto)
{
        CocheEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new CocheEN ();



                        if (dto.Reserva_oid != -1) {
                                RentACarRESTGenNHibernate.CAD.RentACarREST.IReservaCAD reservaCAD = new RentACarRESTGenNHibernate.CAD.RentACarREST.ReservaCAD ();

                                newinstance.Reserva = reservaCAD.ReadOIDDefault (dto.Reserva_oid);
                        }
                        newinstance.NumLicencia = dto.NumLicencia;
                        newinstance.Categoria = dto.Categoria;
                        newinstance.Estado = dto.Estado;
                        if (dto.Proveedor_oid != null) {
                                RentACarRESTGenNHibernate.CAD.RentACarREST.IProveedorCAD proveedorCAD = new RentACarRESTGenNHibernate.CAD.RentACarREST.ProveedorCAD ();

                                newinstance.Proveedor = new System.Collections.Generic.List<RentACarRESTGenNHibernate.EN.RentACarREST.ProveedorEN>();
                                foreach (int entry in dto.Proveedor_oid) {
                                        newinstance.Proveedor.Add (proveedorCAD.ReadOIDDefault (entry));
                                }
                        }
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
