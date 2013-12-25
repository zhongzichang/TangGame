///xbhuang
///小伙伴们，来点乐子吧！
/// <summary>
/// 2013/11/8
/// </summary>
using System;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of NewMailNoticePush.
/// </summary>
	[Response(NAME)]
	public class HeroPointPush : Response
	{
		public const string NAME = "heropoint_PUSH";
		public long id;
		public int x;
		public int y;

		public HeroPointPush () : base(NAME)
		{

		}

		public static HeroPointPush Parse (MsgData data)
		{
			HeroPointPush push = new HeroPointPush ();
			int index = 0;
			push.id = data.GetLong (index++);
			push.x = data.GetShort (index++);
			push.y = data.GetShort (index++);
			return push;
		}
	}
}