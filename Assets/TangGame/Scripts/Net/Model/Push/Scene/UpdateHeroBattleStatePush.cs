/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/14
 * Time: 17:24
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of UpdateHeroBattleStatePush.
/// </summary>

	[Response(NAME)]
	public class UpdateHeroBattleStatePush : Response
	{

		public const string NAME = "updateHeroBattleState_PUSH";
		public long heroId;
		public bool isBattleState;

		public UpdateHeroBattleStatePush () : base(NAME)
		{
		}

		public static UpdateHeroBattleStatePush Parse (MsgData data)
		{

			UpdateHeroBattleStatePush push = new UpdateHeroBattleStatePush ();
			int index = 0;
			push.heroId = data.GetLong (index++);
			push.isBattleState = data.GetBool (index++);

			return push;
		}
	}
}
