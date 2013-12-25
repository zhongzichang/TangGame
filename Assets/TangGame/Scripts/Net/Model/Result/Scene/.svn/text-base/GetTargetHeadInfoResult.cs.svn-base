using System;
using System.Collections.Generic;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
	/// <summary>
	/// 获取点击选中的对象头像信息
	/// create by huxiaobo
	/// 2013.11.27
	/// </summary>
	[Response(NAME)]
	public class GetTargetHeadInfoResult : Response
	{
		public const string NAME = "getObj_RESULT";
	
		public long objId;				//对象ID
		public string objName;		//对象名字
		public string headIcon;		//头像ID，为-1时是玩家
		public int 	level;				//等级
		public int curHp;					//当前血量为-1时表示NPC
		public int maxHp;					//最大血量为-1时表示NPC

		public GetTargetHeadInfoResult() : base(NAME)
		{
		}
		public static GetTargetHeadInfoResult Parse(MsgData data)
		{
			GetTargetHeadInfoResult result = new GetTargetHeadInfoResult();
			int index = 0;
			result.objId = data.GetLong(index++);
			result.objName = data.GetString(index++);
			result.headIcon = data.GetString(index++);
			result.level = data.GetInt(index++);
			result.curHp = data.GetInt(index++);
			result.maxHp = data.GetInt(index++);
			return result;
		}
	}
}
