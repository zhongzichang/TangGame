/*
 * yc 2013/11/13
 */
using System;
using TangNet;
using UnityEngine;

namespace TangGame.Net
{
	public class AskForHeroEquRequest : Request
	{
		private long heroId;

//		public AskForHeroEquRequest(long heroId) 
//		{
//			this.heroId = heroId;
//		}
		public AskForHeroEquRequest()
		{
			
		}
		 public NetData NetData
	    {
	        get
	        {
	            NetData data = new NetData(RoleProxy.MY_ROLE_INFO);
//	            data.PutLong(heroId);
//	            Debug.Log("AskForHeroEquRequest hero id" );
	            return data;
	        }
	    }
	}
}
