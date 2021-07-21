

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using RentACarRESTGenNHibernate.Exceptions;

using RentACarRESTGenNHibernate.EN.RentACarREST;
using RentACarRESTGenNHibernate.CAD.RentACarREST;


namespace RentACarRESTGenNHibernate.CEN.RentACarREST
{
/*
 *      Definition of the class ClienteCEN
 *
 */
public partial class ClienteCEN
{
private IClienteCAD _IClienteCAD;

public ClienteCEN()
{
        this._IClienteCAD = new ClienteCAD ();
}

public ClienteCEN(IClienteCAD _IClienteCAD)
{
        this._IClienteCAD = _IClienteCAD;
}

public IClienteCAD get_IClienteCAD ()
{
        return this._IClienteCAD;
}

public string CrearCliente (string p_DNI, string p_nombre, string p_direccion, string p_telefono, String p_pass)
{
        ClienteEN clienteEN = null;
        string oid;

        //Initialized ClienteEN
        clienteEN = new ClienteEN ();
        clienteEN.DNI = p_DNI;

        clienteEN.Nombre = p_nombre;

        clienteEN.Direccion = p_direccion;

        clienteEN.Telefono = p_telefono;

        clienteEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);

        //Call to ClienteCAD

        oid = _IClienteCAD.CrearCliente (clienteEN);
        return oid;
}

public void BorrarCliente (string DNI
                           )
{
        _IClienteCAD.BorrarCliente (DNI);
}

public void Modificar (string p_Cliente_OID, string p_nombre, string p_direccion, string p_telefono)
{
        ClienteEN clienteEN = null;

        //Initialized ClienteEN
        clienteEN = new ClienteEN ();
        clienteEN.DNI = p_Cliente_OID;
        clienteEN.Nombre = p_nombre;
        clienteEN.Direccion = p_direccion;
        clienteEN.Telefono = p_telefono;
        //Call to ClienteCAD

        _IClienteCAD.Modificar (clienteEN);
}

public ClienteEN ReadOID (string DNI
                          )
{
        ClienteEN clienteEN = null;

        clienteEN = _IClienteCAD.ReadOID (DNI);
        return clienteEN;
}

public System.Collections.Generic.IList<ClienteEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ClienteEN> list = null;

        list = _IClienteCAD.ReadAll (first, size);
        return list;
}
public string Login (string p_Cliente_OID, string p_pass)
{
        string result = null;
        ClienteEN en = _IClienteCAD.ReadOIDDefault (p_Cliente_OID);

        if (en != null && en.Pass.Equals (Utils.Util.GetEncondeMD5 (p_pass)))
                result = this.GetToken (en.DNI);

        return result;
}




private string Encode (string DNI)
{
        var payload = new Dictionary<string, object>(){
                { "DNI", DNI }
        };
        string token = Jose.JWT.Encode (payload, Utils.Util.getKey (), Jose.JwsAlgorithm.HS256);

        return token;
}

public string GetToken (string DNI)
{
        ClienteEN en = _IClienteCAD.ReadOIDDefault (DNI);
        string token = Encode (en.DNI);

        return token;
}
public string CheckToken (string token)
{
        string result = null;

        try
        {
                string decodedToken = Utils.Util.Decode (token);



                string id = (string)ObtenerDNI (decodedToken);

                ClienteEN en = _IClienteCAD.ReadOIDDefault (id);

                if (en != null && ((string)en.DNI).Equals (ObtenerDNI (decodedToken))
                    ) {
                        result = id;
                }
                else throw new ModelException ("El token es incorrecto");
        } catch (Exception e)
        {
                throw new ModelException ("El token es incorrecto");
        }

        return result;
}


public string ObtenerDNI (string decodedToken)
{
        try
        {
                Dictionary<string, object> results = JsonConvert.DeserializeObject<Dictionary<string, object> >(decodedToken);
                string dni = (string)results ["DNI"];
                return dni;
        }
        catch
        {
                throw new Exception ("El token enviado no es correcto");
        }
}
}
}
