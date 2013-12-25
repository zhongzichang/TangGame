/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/22
 * Time: 16:07
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 将角色从场景中删除
/// </summary>
	[Response(NAME)]
	public class RemoveNpcFromScenePush : Response
	{
		public const string NAME = "removeNPCFromScene_PUSH";
		public long roleId;

		public RemoveNpcFromScenePush () : base(NAME)
		{
		}

		public static RemoveNpcFromScenePush Parse (MsgData data)
		{

			RemoveNpcFromScenePush push = new RemoveNpcFromScenePush ();

			push.roleId = data.GetLong (0);

			return push;

		}

	}
}
