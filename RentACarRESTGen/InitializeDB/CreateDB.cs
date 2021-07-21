
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using RentACarRESTGenNHibernate.EN.RentACarREST;
using RentACarRESTGenNHibernate.CEN.RentACarREST;
using RentACarRESTGenNHibernate.CAD.RentACarREST;
using RentACarRESTGenNHibernate.Enumerated.RentACarREST;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local); database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                // Insert the initilizations of entities using the CEN classes


                ClienteCAD cliCAD = new ClienteCAD ();
                ClienteCEN cliCEN = new ClienteCEN (cliCAD);
                ReservaCAD resCAD = new ReservaCAD ();
                ReservaCEN resCEN = new ReservaCEN (resCAD);
                CocheCAD coCAD = new CocheCAD ();
                CocheCEN coCEN = new CocheCEN (coCAD);
                FacturaCAD facCAD = new FacturaCAD ();
                FacturaCEN facCEN = new FacturaCEN (facCAD);


                // Creamos Clientes
                cliCEN.CrearCliente ("9292", "Juan Ortiz", "dir", "telf", "1234");
                cliCEN.CrearCliente ("9293", "Pedro Lopez", "dir", "telf", "1234");

                //Creamos Reservas
                int res1 = resCEN.CrearReserva ("9292", DateTime.Today, new DateTime (2020, 3, 22));
                int res2 = resCEN.CrearReserva ("9292", new DateTime (2018, 2, 9), new DateTime (2020, 4, 19));


                //Creamos Coches
                int idCoche1 = coCEN.CrearCoche (CategoriaCocheEnum.estandar, EstadoCocheEnum.libre);
                int idCoche2 = coCEN.CrearCoche (CategoriaCocheEnum.lujo, EstadoCocheEnum.libre);
                coCEN.CrearCoche (CategoriaCocheEnum.estandar, EstadoCocheEnum.libre);
                coCEN.CrearCoche (CategoriaCocheEnum.lujo, EstadoCocheEnum.libre);
                coCEN.CrearCoche (CategoriaCocheEnum.estandar, EstadoCocheEnum.libre);


                //Asignamos Coches a reservas (Reservamos)

                coCEN.AsignarReserva (idCoche1, res1);
                coCEN.AsignarReserva (idCoche2, res2);
                CocheEN co1 = new CocheCAD ().ReadOIDDefault (idCoche1);
                CocheEN co2 = new CocheCAD ().ReadOIDDefault (idCoche2);

                coCEN.Modificar (idCoche1, co1.Categoria, EstadoCocheEnum.alquilado);
                coCEN.Modificar (idCoche2, co2.Categoria, EstadoCocheEnum.alquilado);

                // Creamos facturas

                ReservaEN enRes1 = new ReservaCAD ().ReadOIDDefault (res1);
                LineaFacturaEN linea1 = new LineaFacturaEN (1, new FacturaEN (), enRes1, 345);
                LineaFacturaEN linea2 = new LineaFacturaEN (2, new FacturaEN (), enRes1, 500);
                IList<LineaFacturaEN> lineas = new List<LineaFacturaEN>();
                lineas.Add (linea1);
                lineas.Add (linea2);
                facCEN.CrearFactura (DateTime.Today, false, false, "9292", lineas);

                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
