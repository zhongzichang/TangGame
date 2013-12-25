/// <summary>
/// xbhuang
/// 2013/11/11
/// </summary>
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
	public class Npc : ActorNo
	{
		/// <summary>
		/// 头像
		/// </summary>
		public string picture;	
		/// <summary>
		/// Npc的废话
		/// </summary>
		public string talk;
		public short direction;
    public int configId;
    public List<int> taskIds;
		public static Npc Parse (MsgData data)
		{
			Npc npc = new Npc ();
			int index = 0;
			npc.id = data.GetLong(index++);
			npc.name = data.GetString(index++);
			npc.picture = data.GetString(index++);
			npc.helfLengthPhoto = data.GetString(index++);
			npc.resourcesId = data.GetString(index++);
			npc.x = data.GetShort(index++);
			npc.y = data.GetShort(index++);
			npc.level = data.GetInt(index++);
			npc.direction = data.GetShort(index++);
      npc.configId = data.GetInt(index++);
      MsgData idsData = data.GetMsgData(index++);
      npc.taskIds = new List<int>();
      for(int i = 0;i < idsData.Size;i++){
        npc.taskIds.Add(idsData.GetInt(i));
      }
      //TODO del this 临时代码
      npc.helfLengthPhoto = "001";
			return npc;
		}
	}
}