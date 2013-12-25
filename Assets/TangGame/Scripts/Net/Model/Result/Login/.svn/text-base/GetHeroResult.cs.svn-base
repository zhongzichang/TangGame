/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/19
 * Time: 14:21
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
	/// <summary>
	/// Description of GetHeroResult.
	/// </summary>
	[Response("getHero_RESULT")]
	public class GetHeroResult : Response
	{
		public const string NAME = "getHero_RESULT";

		public HeroNew hero;

		public GetHeroResult() : base(NAME)
		{

		}

		public static GetHeroResult Parse(MsgData data)
		{
			GetHeroResult result = new GetHeroResult();

			result.hero = HeroNew.Parse(data);

			return result;
		}
	}
}
