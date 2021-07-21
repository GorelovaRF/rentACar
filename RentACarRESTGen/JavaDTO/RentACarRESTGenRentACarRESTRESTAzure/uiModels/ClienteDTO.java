	
		package RentACarRESTGenRentACarRESTRESTAzure.uiModels.DTO;
		
		import java.util.ArrayList;
		
		import org.json.JSONArray;
		import org.json.JSONException;
		import org.json.JSONObject;
		import  RentACarRESTGenRentACarRESTRESTAzure.uiModels.DTO.utils.*;
		import  RentACarRESTGenRentACarRESTRESTAzure.uiModels.DTO.enumerations.*;
		
		
		/**
		 * Code autogenerated. Do not modify this file.
		 */
		
		
		public class ClienteDTO 	    implements IDTO
	    {
				private String dNI;
				public String getDNI () { return dNI; } 
				public void setDNI  (String value) { dNI = value;  } 
				    	 
				private String nombre;
				public String getNombre () { return nombre; } 
				public void setNombre  (String value) { nombre = value;  } 
				    	 
				private String direccion;
				public String getDireccion () { return direccion; } 
				public void setDireccion  (String value) { direccion = value;  } 
				    	 
				private String telefono;
				public String getTelefono () { return telefono; } 
				public void setTelefono  (String value) { telefono = value;  } 
				    	 
				private ArrayList<Integer> factura_oid;
				public ArrayList<Integer>  getFactura_oid () { return factura_oid; } 
				public void setFactura_oid (ArrayList<Integer> value) { factura_oid = value;  } 
				    	 
				private ArrayList<Integer> reserva_oid;
				public ArrayList<Integer>  getReserva_oid () { return reserva_oid; } 
				public void setReserva_oid (ArrayList<Integer> value) { reserva_oid = value;  } 
				    	 
				private String pass;
				public String getPass () { return pass; } 
				public void setPass  (String value) { pass = value;  } 
				    	 
	   
			    public JSONObject toJSON ()
				{
					JSONObject json = new JSONObject();
					
					try
					{
				
						  json.put("DNI", this.dNI);
				
				
						  json.put("Nombre", this.nombre);
				
				
						  json.put("Direccion", this.direccion);
				
				
						  json.put("Telefono", this.telefono);
				

						if (this.factura_oid != null)
						{
							JSONArray jsonArray = new JSONArray();
							for (int i = 0; i < this.factura_oid.size(); ++i)
							{
								jsonArray.put(this.factura_oid.get(i));
							}
							json.put("Factura_oid", jsonArray);
						}
		

						if (this.reserva_oid != null)
						{
							JSONArray jsonArray = new JSONArray();
							for (int i = 0; i < this.reserva_oid.size(); ++i)
							{
								jsonArray.put(this.reserva_oid.get(i));
							}
							json.put("Reserva_oid", jsonArray);
						}
		
				
						  json.put("Pass", this.pass);
				
						
					}
					catch (JSONException e)
					{
						e.printStackTrace();
					}
				
				return json;
			}
		
			// endregion
		}
	   
	   
	   
		
	