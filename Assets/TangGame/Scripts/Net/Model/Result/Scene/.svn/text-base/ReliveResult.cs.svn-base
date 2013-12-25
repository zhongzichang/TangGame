using System;
using System.Collections.Generic;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of ReliveResult.
/// </summary>
	[Response(NAME)]
	public class ReliveResult : Response
	{

		public const string NAME = "relive_RESULT";
		public int gameMapId;
		public short x;
		public short y;
		public int heroHp;
		public int heroMp;

		public ReliveResult () : base(NAME)
		{
		}

		public static ReliveResult Parse (MsgData data)
		{


			int index = 0;
			ReliveResult result = new ReliveResult ();

			result.heroHp = data.GetInt (index++);
			result.heroMp = data.GetInt (index++);
			result.gameMapId = data.GetInt (index++);
			result.x = data.GetShort (index++);
			result.y = data.GetShort (index++);


			return result;


		}
	}
}