	
		package RentACarRESTGenAdminRentACarRESTAzure.uiModels.DTO;
		
		import java.util.ArrayList;
		
		import org.json.JSONArray;
		import org.json.JSONException;
		import org.json.JSONObject;
		import  RentACarRESTGenAdminRentACarRESTAzure.uiModels.DTO.utils.*;
		import  RentACarRESTGenAdminRentACarRESTAzure.uiModels.DTO.enumerations.*;
		
		
		/**
		 * Code autogenerated. Do not modify this file.
		 */
		
		
		public class ReservaDTO 	    implements IDTO
	    {
				private String cliente_oid;
				public String  getCliente_oid () { return cliente_oid; } 
				public void setCliente_oid (String value) { cliente_oid = value;  } 
				    	 
				private Integer id;
				public Integer getId () { return id; } 
				public void setId  (Integer value) { id = value;  } 
				    	 
				private Integer coche_oid;
				public Integer  getCoche_oid () { return coche_oid; } 
				public void setCoche_oid (Integer value) { coche_oid = value;  } 
				    	 
				private Integer lineaFactura_oid;
				public Integer  getLineaFactura_oid () { return lineaFactura_oid; } 
				public void setLineaFactura_oid (Integer value) { lineaFactura_oid = value;  } 
				    	 
				private java.util.Date inicio;
				public java.util.Date getInicio () { return inicio; } 
				public void setInicio  (java.util.Date value) { inicio = value;  } 
				    	 
				private java.util.Date final;
				public java.util.Date getFinal () { return final; } 
				public void setFinal  (java.util.Date value) { final = value;  } 
				    	 
	   
			    public JSONObject toJSON ()
				{
					JSONObject json = new JSONObject();
					
					try
					{

						if (this.cliente_oid != null)
						{
							json.put("Cliente_oid", this.cliente_oid);
						}
				
						  json.put("Id", this.id.intValue());
				

						if (this.coche_oid != null)
						{
							json.put("Coche_oid", this.coche_oid.intValue());
						}

						if (this.lineaFactura_oid != null)
						{
							json.put("LineaFactura_oid", this.lineaFactura_oid.intValue());
						}
				
						  json.put("Inicio", DateUtils.dateToFormatString(this.inicio));
				
				
						  json.put("Final", DateUtils.dateToFormatString(this.final));
				
						
					}
					catch (JSONException e)
					{
						e.printStackTrace();
					}
				
				return json;
			}
		
			// endregion
		}
	   
	   
	   
		
	