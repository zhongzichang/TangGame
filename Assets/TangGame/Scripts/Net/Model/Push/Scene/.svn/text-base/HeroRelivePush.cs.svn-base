/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 0:37
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 其他玩家广播复活消息
/// </summary>
	[Response(NAME)]
	public class HeroRelivePush : Response
	{
		public const string NAME = "heroRelive_PUSH";
		public long heroId;
		public int hp;
		public short x;
		public short y;

		public HeroRelivePush () : base(NAME)
		{
		}

		public static HeroRelivePush Parse (MsgData data)
		{

			HeroRelivePush push = new HeroRelivePush ();

			int index = 0;
			push.heroId = data.GetLong (index++);
			push.hp = data.GetInt (index++);
			push.x = data.GetShort (index++);
			push.y = data.GetShort (index++);

			return push;


		}
	}
}
