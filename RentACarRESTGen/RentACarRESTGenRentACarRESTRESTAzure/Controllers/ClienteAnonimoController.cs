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


/*PROTECTED REGION ID(usingRentACarRESTGenRentACarRESTRESTAzure_ClienteAnonimoControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace RentACarRESTGenRentACarRESTRESTAzure.Controllers
{
[RoutePrefix ("~/api/ClienteAnonimo")]
public class ClienteAnonimoController : BasicController
{
// Voy a generar el readAll















[HttpPost]

[Route ("~/api/ClienteAnonimo/Login")]


public HttpResponseMessage Login ( [FromBody] ClienteDTO dto)
{
        // CAD, CEN, returnValue
        ClienteAnonimoRESTCAD clienteAnonimoRESTCAD = null;
        ClienteCEN clienteCEN = null;
        string token = null;

        try
        {
                SessionInitializeTransaction ();
                clienteAnonimoRESTCAD = new ClienteAnonimoRESTCAD (session);
                clienteCEN = new ClienteCEN (clienteAnonimoRESTCAD);


                // Operation
                token = clienteCEN.Login (
                        dto.DNI
                        , dto.Pass
                        );

                SessionCommit ();
        }

        catch (Exception e)
        {
                SessionRollBack ();

                if (e.GetType () == typeof(HttpResponseException)) throw e;
                else if (e.GetType () == typeof(RentACarRESTGenNHibernate.Exceptions.ModelException) && e.Message.Equals ("El token es incorrecto")) throw new HttpResponseException (HttpStatusCode.Forbidden);
                else if (e.GetType () == typeof(RentACarRESTGenNHibernate.Exceptions.ModelException) || e.GetType () == typeof(RentACarRESTGenNHibernate.Exceptions.DataLayerException)) throw new HttpResponseException (HttpStatusCode.BadRequest);
                else throw new HttpResponseException (HttpStatusCode.InternalServerError);
        }
        finally
        {
                SessionClose ();
        }

        // Return 200 - OK
        if (token != null)
                return this.Request.CreateResponse (HttpStatusCode.OK, token);
        else
                return this.Request.CreateResponse (HttpStatusCode.Unauthorized, "");
}



















/*PROTECTED REGION ID(RentACarRESTGenRentACarRESTRESTAzure_ClienteAnonimoControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
