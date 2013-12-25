/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/6
 * Time: 20:13
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
/// Description of OnSceneMonsterResult.
/// </summary>
	[Response(NAME)]
	public class OnSceneMonsterResult : Response
	{

		public const string NAME = "onSceneMonster_RESULT";
		public List<Monster> monsters = new List<Monster> ();

		public OnSceneMonsterResult () : base(NAME)
		{
		}

		public static OnSceneMonsterResult Parse (MsgData data)
		{

			OnSceneMonsterResult result = new OnSceneMonsterResult ();
			for (int i=0; i<data.Size; i++) {

				MsgData monsterData = data.GetMsgData (i);
				Monster monster=Monster.Parse(monsterData);
				result.monsters.Add (monster);
			}

			return result;
		}

	}
}
