/*
 * yc 2013/11/20
 */
using System;
using TangNet;
using UnityEngine;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections.Generic;
namespace TangGame.Net
{

	[Response(NAME)]
	public class EquipUpgradeResult : Response
	{
		public const string NAME = "equipUpgrade_RESULT";
	
	    public EquipUpgradeResult() : base(NAME)
	    {
	    	
	    }
    
	     public static EquipUpgradeResult Parse(short statusCode, MsgData data)
	    {
	     	EquipUpgradeResult result = new EquipUpgradeResult();
	     	result.StatusCode = statusCode;
	        return result;
	
	    }
	}
}
