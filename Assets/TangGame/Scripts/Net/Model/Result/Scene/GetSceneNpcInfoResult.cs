/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/8
 * Time: 18:30
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
	/// <summary>
	/// 获取一个场景中的NPC的详细信息
	/// </summary>
	[Response(NAME)]
	public class GetSceneNpcInfoResult : Response
	{
		public const string NAME = "getSceneNpcInfo_RESULT";
		public long npcId;
		/// <summary>
		/// NPC功能类型
		/// </summary>
		public short npcType;
		/// <summary>
		/// 买卖物品或者任务的配置Id列表
		/// </summary>
		public List<int> ids;
		public string note;
		public GetSceneNpcInfoResult() : base(NAME)
		{
		}
		public static GetSceneNpcInfoResult Parse(MsgData data)
		{
			GetSceneNpcInfoResult result = new GetSceneNpcInfoResult();
			int index = 0;
			result.npcId = data.GetLong(index++);
			result.npcType = data.GetShort(index++);
			MsgData idsData = data.GetMsgData(index++);
			result.ids = new List<int>();
			for(int i = 0;i < idsData.Size;i++){
				result.ids.Add(idsData.GetInt(i));
			}
			
			result.note = data.GetString(index++);
			return result;
		}
	}
}
