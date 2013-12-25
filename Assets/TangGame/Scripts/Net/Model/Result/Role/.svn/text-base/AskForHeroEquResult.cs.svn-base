/*
 * yc 2013/11/13 
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
	public class AskForHeroEquResult : Response
	{
		public const string NAME = "heroinfo_PUSH";
		
		public int fightingCapacity;
		public int hp;
		public int hpMax;
		public int physicalAttack;
		public int physicalDefense;
		public int hitRate;
		public int dodge;
		public int criticalStrike;
		public int tenacity;
		public Dictionary<short,int> heroEqus;
	
	    public AskForHeroEquResult() : base(NAME)
	    {
	    	heroEqus = new Dictionary<short, int>();
	    }
	
	    public static AskForHeroEquResult Parse(MsgData data)
	    {
	        AskForHeroEquResult push = new AskForHeroEquResult();	
			int index = 0;
			push.fightingCapacity = data.GetInt(index++);
			push.hp = data.GetInt(index++);
			push.hpMax = data.GetInt(index++);
			push.physicalAttack = data.GetInt(index++);
			push.physicalDefense = data.GetInt(index++);
			push.hitRate = data.GetInt(index++);
			push.dodge = data.GetInt(index++);
			push.criticalStrike = data.GetInt(index++);
			push.tenacity = data.GetInt(index++);
			
			MsgData equ = data.GetMsgData(index++);
			MsgData temp;
	        for (int i = 0; i < equ.Size; i++)
	        {
	        	temp = equ.GetMsgData(i);     
	        	int j = 0;
	        	short type = temp.GetShort(j++);
	        	int  goodsId = temp.GetInt(j++);
	        	push.heroEqus.Add(type,goodsId);
	        	
	        }
//	        Debug.Log(push.fightingCapacity + ":" + push.hp + ":" +push.hpMax + ":" +push.physicalAttack + ":" +push.physicalDefense + ":" +push.hitRate 
//	                  + ":" +push.dodge + ":" + push.criticalStrike + ":" +push.tenacity);
	        return push;
	
	    }
	}
}
