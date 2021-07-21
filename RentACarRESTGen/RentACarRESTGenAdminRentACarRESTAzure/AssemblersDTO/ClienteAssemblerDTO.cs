using System;
using System.Collections.Generic;
using RentACarRESTGenNHibernate.EN.RentACarREST;
using RentACarRESTGenAdminRentACarRESTAzure.DTO;

namespace RentACarRESTGenAdminRentACarRESTAzure.AssemblersDTO
{
public class ClienteAssemblerDTO {
public static IList<ClienteEN> ConvertList (IList<ClienteDTO> lista)
{
        IList<ClienteEN> result = new List<ClienteEN>();
        foreach (ClienteDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static ClienteEN Convert (ClienteDTO dto)
{
        ClienteEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new ClienteEN ();



                        newinstance.DNI = dto.DNI;
                        newinstance.Nombre = dto.Nombre;
                        newinstance.Direccion = dto.Direccion;
                        newinstance.Telefono = dto.Telefono;
                        if (dto.Factura_oid != null) {
                                RentACarRESTGenNHibernate.CAD.RentACarREST.IFacturaCAD facturaCAD = new RentACarRESTGenNHibernate.CAD.RentACarREST.FacturaCAD ();

                                newinstance.Factura = new System.Collections.Generic.List<RentACarRESTGenNHibernate.EN.RentACarREST.FacturaEN>();
                                foreach (int entry in dto.Factura_oid) {
                                        newinstance.Factura.Add (facturaCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Reserva_oid != null) {
                                RentACarRESTGenNHibernate.CAD.RentACarREST.IReservaCAD reservaCAD = new RentACarRESTGenNHibernate.CAD.RentACarREST.ReservaCAD ();

                                newinstance.Reserva = new System.Collections.Generic.List<RentACarRESTGenNHibernate.EN.RentACarREST.ReservaEN>();
                                foreach (int entry in dto.Reserva_oid) {
                                        newinstance.Reserva.Add (reservaCAD.ReadOIDDefault (entry));
                                }
                        }
                        newinstance.Pass = dto.Pass;
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
