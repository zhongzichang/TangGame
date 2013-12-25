/*
 * yc 2013/11/20 
 */
using System;
using TangNet;
using UnityEngine;

namespace TangGame.Net
{
	public class EquipUpgradeRequest : Request
	{
		private int itemId;
		private int isBuy;

		public EquipUpgradeRequest(int itemId,int isBuy)
		{
			this.itemId = itemId;
			this.isBuy = isBuy;
		}
		 public NetData NetData
	    {
	        get
	        {
	            NetData data = new NetData(EquipProxy.EQUIP_UPGRADE_INFO);
	            data.PutInt(itemId);
	            data.PutInt(isBuy);
//	            Debug.Log("EquipUpgradeRequest ~~~" );
	            return data;
	        }
	    }
	}
}
