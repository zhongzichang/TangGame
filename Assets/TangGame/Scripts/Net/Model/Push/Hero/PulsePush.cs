/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/19
 * Time: 21:04
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
	/// <summary>
	/// Description of PulsePush.
	/// </summary>
	[Response(NAME)]
	public class PulsePush : Response
	{
		public const string NAME = "pulse_PUSH";

		public PulsePush() : base(NAME)
		{
		}

		public static PulsePush Parse(MsgData data)
		{
			return new PulsePush();
		}
	}
}
