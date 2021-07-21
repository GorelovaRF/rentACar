//
// ClienteAnonimoDTOA.swift
// 
// Code autogenerated. Do not modify this file.
//

import Foundation
import SwiftyJSON
		
class ClienteAnonimoDTOA : DTOA
{
	// MARK: - Properties

	var dNI: String?;
	
	
	
	
	
	
	// MARK: - Constructor
	
	init ()
	{
		// Empty constructor
	}
	
	
	
	// MARK: - JSON <-> DTOA
	
	required init (fromJSONObject json: JSON)
	{
		self.dNI = json["DNI"].object as? String
		
	
		
		
	}
	
	func toDictionary() -> [String : AnyObject]
	{
		var dictionary: [String : AnyObject] = [:];
		
		dictionary["DNI"] = self.dNI;
		
	
		
		
		
		return dictionary;
	}
}

	