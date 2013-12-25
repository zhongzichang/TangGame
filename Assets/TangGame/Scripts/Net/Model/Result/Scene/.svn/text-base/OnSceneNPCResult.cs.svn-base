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
	/// Description of OnSceneNPCResult.
	/// </summary>
	[Response(NAME)]
	public class OnSceneNPCResult : Response
	{
		public const string NAME = "onSceneNPC_RESULT";

		public List<Npc> npcs = new List<Npc>();
		public OnSceneNPCResult() : base(NAME)
		{
		}
		public static OnSceneNPCResult Parse(MsgData data)
		{

			OnSceneNPCResult result  = new OnSceneNPCResult();
			for(int i=0; i<data.Size; i++)
			{

				MsgData npcData = data.GetMsgData(i);
				Npc npc = Npc.Parse(npcData);
				result.npcs.Add(npc);
			}

			return result;

		}
	}
}
