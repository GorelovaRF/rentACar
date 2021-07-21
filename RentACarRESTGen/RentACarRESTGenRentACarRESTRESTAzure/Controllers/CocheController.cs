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


/*PROTECTED REGION ID(usingRentACarRESTGenRentACarRESTRESTAzure_CocheControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace RentACarRESTGenRentACarRESTRESTAzure.Controllers
{
[RoutePrefix ("~/api/Coche")]
public class CocheController : BasicController
{
// Voy a generar el readAll













// Pasa el slEnables


//Pasa el serviceLinkValid

// ReadFilter Generado a partir del serviceLink

[HttpGet]

[Route ("~/api/Coche/Coche_dameCochesDisponibles")]

public HttpResponseMessage Coche_dameCochesDisponibles (int first)
{
        // CAD, CEN, EN, returnValue

        CocheRESTCAD cocheRESTCAD = null;
        CocheCEN cocheCEN = null;

        System.Collections.Generic.List<CocheEN> en;
        List<CocheDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();



                cocheRESTCAD = new CocheRESTCAD (session);
                cocheCEN = new CocheCEN (cocheRESTCAD);


                // CEN return


                // paginación

                en = cocheCEN.DameCochesDisponibles (first, 10).ToList ();



                // Convert return
                if (en != null) {
                        returnValue = new List<CocheDTOA>();
                        foreach (CocheEN entry in en)
                                returnValue.Add (CocheAssembler.Convert (entry, session));
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






[HttpPost]


[Route ("~/api/Coche/CrearCoche")]




public HttpResponseMessage CrearCoche ( [FromBody] CocheDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        CocheRESTCAD cocheRESTCAD = null;
        CocheCEN cocheCEN = null;
        CocheDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                cocheRESTCAD = new CocheRESTCAD (session);
                cocheCEN = new CocheCEN (cocheRESTCAD);

                // Create
                returnOID = cocheCEN.CrearCoche (
                        //Atributo Primitivo: p_categoria
                        dto.Categoria,                                                                                                                                      //Atributo Primitivo: p_estado
                        dto.Estado);
                SessionCommit ();

                // Convert return
                returnValue = CocheAssembler.Convert (cocheRESTCAD.ReadOIDDefault (returnOID), session);
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

        // Return 201 - Created
        response = this.Request.CreateResponse (HttpStatusCode.Created, returnValue);

        // Location Header
        /*
         * Dictionary<string, object> routeValues = new Dictionary<string, object>();
         *
         * // TODO: y rolPaths
         * routeValues.Add("id", returnOID);
         *
         * uri = Url.Link("GetOIDCoche", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}






[HttpPut]



[Route ("~/api/Coche/Modificar")]

public HttpResponseMessage Modificar (int idCoche, [FromBody] CocheDTO dto)
{
        // CAD, CEN, returnValue
        CocheRESTCAD cocheRESTCAD = null;
        CocheCEN cocheCEN = null;
        CocheDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                cocheRESTCAD = new CocheRESTCAD (session);
                cocheCEN = new CocheCEN (cocheRESTCAD);

                // Modify
                cocheCEN.Modificar (idCoche,
                        dto.Categoria
                        ,
                        dto.Estado
                        );

                // Return modified object
                returnValue = CocheAssembler.Convert (cocheRESTCAD.ReadOIDDefault (idCoche), session);

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

        // Return 404 - Not found
        if (returnValue == null)
                return this.Request.CreateResponse (HttpStatusCode.NotFound);
        // Return 200 - OK
        else{
                response = this.Request.CreateResponse (HttpStatusCode.OK, returnValue);

                return response;
        }
}





[HttpDelete]


[Route ("~/api/Coche/BorrarCoche")]

public HttpResponseMessage BorrarCoche (int p_coche_oid)
{
        // CAD, CEN
        CocheRESTCAD cocheRESTCAD = null;
        CocheCEN cocheCEN = null;

        try
        {
                SessionInitializeTransaction ();


                cocheRESTCAD = new CocheRESTCAD (session);
                cocheCEN = new CocheCEN (cocheRESTCAD);

                cocheCEN.BorrarCoche (p_coche_oid);
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

        // Return 204 - No Content
        return this.Request.CreateResponse (HttpStatusCode.NoContent);
}









/*PROTECTED REGION ID(RentACarRESTGenRentACarRESTRESTAzure_CocheControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
