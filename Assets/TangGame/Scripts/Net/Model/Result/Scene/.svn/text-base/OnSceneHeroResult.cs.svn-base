/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 1:24
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
/// Description of OnSceneHeroResult.
/// </summary>
	[Response(NAME)]
	public class OnSceneHeroResult : Response
	{

		public const string NAME = "onSceneHero_RESULT";
		public List<HeroNew> heros;

		public OnSceneHeroResult () : base(NAME)
		{
		}

		public static OnSceneHeroResult Parse (MsgData data)
		{
			OnSceneHeroResult result = new OnSceneHeroResult ();
			result.heros = new List<HeroNew> ();
			for (int i=0; i<data.Size; i++) {
				MsgData heroData = data.GetMsgData (i);
				HeroNew hero = HeroNew.ParseSceneData (heroData);
				result.heros.Add (hero);
			}
			return result;
		}
	}
}
