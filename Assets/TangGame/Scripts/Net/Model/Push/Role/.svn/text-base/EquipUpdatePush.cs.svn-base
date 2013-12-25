/*
 * yc 2013/12/6
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
	public class EquipUpdatePush : Response
	{
		public const string NAME = "equipUpdate_PUSH";
		
		public long heroId;
		public List<int> equList;
		public int goodsSite;					//物品位置            
		public int equipSite;					//装备位置
		public int goodsId;						//装备id
		public int needLevel;					//等级限制
		public int intensifyLevel;				//装备强化等级
		public int intensifyResult;				//装备强化效果
		public List<int> gemIds;
	
	    public EquipUpdatePush() : base(NAME)
	    {
	    	equList = new List<int>();
	    	gemIds = new List<int>();
	    }
	
	    public static EquipUpdatePush Parse(MsgData data)
	    {
	    	EquipUpdatePush push = new EquipUpdatePush();
			push.heroId = data.GetLong(0);
			MsgData temp = new MsgData();
			temp = data.GetMsgData(1);
			for(int i = 0;i < temp.Size;i ++){
				int index = 0;
				MsgData equList = temp.GetMsgData(i);
				push.goodsSite = equList.GetInt(index++);
				push.equipSite = equList.GetInt(index++);
				push.goodsId = equList.GetInt(index++);
				push.needLevel = equList.GetInt(index++);
				push.intensifyLevel = equList.GetInt(index++);
				push.intensifyResult = equList.GetInt(index++);
				MsgData gemTemp = equList.GetMsgData(index++);
				if(gemTemp.Size > 0){
					for(int j = 0;j < gemTemp.Size;j ++){
						push.gemIds.Add(gemTemp.GetInt(j));
					}
				}
			}
			Debug.Log(push.heroId +":"+ push.goodsSite +":"+ push.equipSite +":"+ push.goodsId +":"+ push.needLevel +":"+
			              push.intensifyLevel +":"+ push.intensifyResult);
	        return push;
	
	    }
    
	}
}
