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


/*PROTECTED REGION ID(usingRentACarRESTGenRentACarRESTRESTAzure_ClienteRegistradoControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace RentACarRESTGenRentACarRESTRESTAzure.Controllers
{
[RoutePrefix ("~/api/ClienteRegistrado")]
public class ClienteRegistradoController : BasicController
{
// Voy a generar el readAll











[HttpGet]
// [Route("{idClienteRegistrado}", Name="GetOIDClienteRegistrado")]

[Route ("~/api/ClienteRegistrado")]

public HttpResponseMessage ReadOID ()
{
        // CAD, CEN, EN, returnValue
        ClienteRegistradoRESTCAD clienteRegistradoRESTCAD = null;
        ClienteCEN clienteCEN = null;
        ClienteEN clienteEN = null;
        ClienteRegistradoDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                string id = new ClienteCEN ().CheckToken (token);



                clienteRegistradoRESTCAD = new ClienteRegistradoRESTCAD (session);
                clienteCEN = new ClienteCEN (clienteRegistradoRESTCAD);

                // Data
                clienteEN = clienteCEN.ReadOID (id);

                // Convert return
                if (clienteEN != null) {
                        returnValue = ClienteRegistradoAssembler.Convert (clienteEN, session);
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

        // Return 404 - Not found
        if (returnValue == null)
                return this.Request.CreateResponse (HttpStatusCode.NotFound);
        // Return 200 - OK
        else return this.Request.CreateResponse (HttpStatusCode.OK, returnValue);
}





















/*PROTECTED REGION ID(RentACarRESTGenRentACarRESTRESTAzure_ClienteRegistradoControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
