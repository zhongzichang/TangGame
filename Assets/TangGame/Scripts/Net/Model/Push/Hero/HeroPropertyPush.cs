/*
 * Created by SharpDevelop.
 * User: xbhuang
 * Date: 2013/10/21
 * Time: 17:08
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TangNet;

namespace TangGame.Net
{
	[Response(NAME)]
	public class HeroPropertyPush : Response
	{

		public const string NAME = "heroproperty_PUSH";
		public List<KeyValuePair<short,object>> heroPropertyList;

		public HeroPropertyPush () : base(NAME)
		{
			
		}

		public static HeroPropertyPush Parse (MsgData data)
		{

			HeroPropertyPush push = new HeroPropertyPush ();

			push.heroPropertyList = new List<KeyValuePair<short,object>> ();

			if (data.Size > 0) {
				KeyValuePair<short,object> item;

				for (int i = 0; i < data.Size; i++) {
					MsgData itemMsg = data.GetMsgData (i);
					item = new KeyValuePair<short, object> (itemMsg.GetShort (0), itemMsg.Get (1));
					push.heroPropertyList.Add (item);
				}
			} 
			return push;
		}
	}
}
