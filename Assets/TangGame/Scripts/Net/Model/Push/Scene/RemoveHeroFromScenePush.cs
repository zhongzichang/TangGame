/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/5/29
 * Time: 15:19
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of RemoveHeroFromScenePush.
/// </summary>
	[Response(NAME)]
	public class RemoveHeroFromScenePush : Response
	{
		public const string NAME = "removeHeroFromScene_PUSH";
		public long heroId;

		public RemoveHeroFromScenePush () : base(NAME)
		{
		}

		public static RemoveHeroFromScenePush Parse (MsgData data)
		{
			RemoveHeroFromScenePush push = new RemoveHeroFromScenePush ();

			push.heroId = data.GetLong (0);

			return push;
		}
	}
}
