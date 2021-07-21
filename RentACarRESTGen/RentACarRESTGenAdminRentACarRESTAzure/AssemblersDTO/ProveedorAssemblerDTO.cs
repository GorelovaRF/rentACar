using System;
using System.Collections.Generic;
using RentACarRESTGenNHibernate.EN.RentACarREST;
using RentACarRESTGenAdminRentACarRESTAzure.DTO;

namespace RentACarRESTGenAdminRentACarRESTAzure.AssemblersDTO
{
public class ProveedorAssemblerDTO {
public static IList<ProveedorEN> ConvertList (IList<ProveedorDTO> lista)
{
        IList<ProveedorEN> result = new List<ProveedorEN>();
        foreach (ProveedorDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static ProveedorEN Convert (ProveedorDTO dto)
{
        ProveedorEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new ProveedorEN ();



                        newinstance.Id = dto.Id;
                        if (dto.Coche_oid != null) {
                                RentACarRESTGenNHibernate.CAD.RentACarREST.ICocheCAD cocheCAD = new RentACarRESTGenNHibernate.CAD.RentACarREST.CocheCAD ();

                                newinstance.Coche = new System.Collections.Generic.List<RentACarRESTGenNHibernate.EN.RentACarREST.CocheEN>();
                                foreach (int entry in dto.Coche_oid) {
                                        newinstance.Coche.Add (cocheCAD.ReadOIDDefault (entry));
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
