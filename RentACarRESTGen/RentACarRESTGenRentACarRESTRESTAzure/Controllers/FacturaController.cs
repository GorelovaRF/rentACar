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


/*PROTECTED REGION ID(usingRentACarRESTGenRentACarRESTRESTAzure_FacturaControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace RentACarRESTGenRentACarRESTRESTAzure.Controllers
{
[RoutePrefix ("~/api/Factura")]
public class FacturaController : BasicController
{
// Voy a generar el readAll






























[HttpPost]

[Route ("~/api/Factura/Factura_dameTotal")]

public HttpResponseMessage Factura_dameTotal (int p_oid)
{
        // CP, returnValue
        FacturaCP facturaCP = null;

        double returnValue;

        try
        {
                SessionInitializeTransaction ();




                facturaCP = new FacturaCP (session);

                // Operation
                returnValue = facturaCP.DameTotal (p_oid);
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
        return this.Request.CreateResponse (HttpStatusCode.OK, returnValue);
}





/*PROTECTED REGION ID(RentACarRESTGenRentACarRESTRESTAzure_FacturaControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
