	
		//
		// ReservaDTO.swift
		// 
		// Code autogenerated. Do not modify this file.
		//
		
		import Foundation
		import SwiftyJSON
	
		 class ReservaDTO 	    {
		 
				var cliente_oid: String?;
				    	 
		 
				var id: Int?;
				    	 
		 
				var coche_oid: Int?;
				    	 
		 
				var lineaFactura_oid: Int?;
				    	 
		 
				var inicio: NSDate?;
				    	 
		 
				var final: NSDate?;
				    	 
	   	   
			// MARK: - Constructor
			
			
		
			init ()
			{
				// Empty constructor
			}
			 func toDictionary() -> [String : AnyObject]
		
		   
			{
				var dictionary: [String : AnyObject] = [:];
				
			


					dictionary["cliente_oid"] = self.cliente_oid;
			

				
					dictionary["id"] = self.id;
				

					dictionary["coche_oid"] = self.coche_oid;
			

					dictionary["lineaFactura_oid"] = self.lineaFactura_oid;
			

				
					dictionary["inicio"] = self.inicio?.toString();
				

				
					dictionary["final"] = self.final?.toString();
				
						
				return dictionary;
			}
		}
		
	