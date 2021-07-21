using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using RentACarRESTGenRentACarRESTRESTAzure.DTO;
using RentACarRESTGenRentACarRESTRESTAzure.DTOA;
using RentACarRESTGenRentACarRESTRESTAzure.CAD;
using RentACarRESTGenRentACarRESTRESTAzure.Assemblers;
using RentACarRESTGenRentACarRESTRESTAzure.AssemblersDTO;
using RentACarRESTGenNHibernate.EN.RentACarREST;
using RentACarRESTGenNHibernate.CEN.RentACarREST;
using RentACarRESTGenNHibernate.CP.RentACarREST;


/*PROTECTED REGION ID(usingRentACarRESTGenRentACarRESTRESTAzure_ReservaControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace RentACarRESTGenRentACarRESTRESTAzure.Controllers
{
[RoutePrefix ("~/api/Reserva")]
public class ReservaController : BasicController
{
// Voy a generar el readAll







[HttpGet]





[Route ("~/api/Reserva/DameReservas")]

public HttpResponseMessage DameReservas (string idClienteRegistrado)
{
        // CAD, EN
        ClienteRegistradoRESTCAD clienteRegistradoRESTCAD = null;
        ClienteEN clienteEN = null;

        // returnValue
        List<ReservaEN> en = null;
        List<ReservaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                clienteRegistradoRESTCAD = new ClienteRegistradoRESTCAD (session);

                // Exists ClienteRegistrado
                clienteEN = clienteRegistradoRESTCAD.ReadOIDDefault (idClienteRegistrado);
                if (clienteEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "ClienteRegistrado#" + idClienteRegistrado + " not found"));

                // Rol
                // TODO: paginación


                en = clienteRegistradoRESTCAD.DameReservas (idClienteRegistrado).ToList ();



                // Convert return
                if (en != null) {
                        returnValue = new List<ReservaDTOA>();
                        foreach (ReservaEN entry in en)
                                returnValue.Add (ReservaAssembler.Convert (entry, session));
                }
        }

        catch (Exception e)
        {
                if (e.GetType () == typeof(HttpResponseException)) throw e;
                else if (e.GetType () == typeof(RentACarRESTGenNHibernate.Exceptions.ModelException) && e.Message.Equals ("El token es incorrecto")) throw new HttpResponseException (HttpStatusCode.Forbidden);
                else if (e.GetType () == typeof(RentACarRESTGenNHibernate.Exceptions.ModelException) || e.GetType () == typeof(RentACarRESTGenNHibernate.Exceptions.DataLayerException)) throw new HttpResponseException (HttpStatusCode.BadRequest);
                else throw new HttpResponseException (HttpStatusCode.InternalServerError);
        }
        finally
        {
                SessionClose ();
        }

        // Return 204 - Empty
        if (returnValue == null || returnValue.Count == 0)
                return this.Request.CreateResponse (HttpStatusCode.NoContent);
        // Return 200 - OK
        else return this.Request.CreateResponse (HttpStatusCode.OK, returnValue);
}



























/*PROTECTED REGION ID(RentACarRESTGenRentACarRESTRESTAzure_ReservaControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
