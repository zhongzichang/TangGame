/*
 * Created by SharpDevelop.
 * User: huxiaobo
 * Date: 2013/11/8
 * Time: 17:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;
using UnityEngine;

namespace TangGame.Net
{
	/// <summary>
	/// 丢弃道具回复消息
	/// </summary>
	[Response(NAME)]
	public class DiscardItemResult : Response
	{
		public const string NAME = "goodsgiveup_RESULT";
		public DiscardItemResult() : base(NAME)
		{
		}
		public static DiscardItemResult Parse(short statusCode, MsgData data)
	    {
			DiscardItemResult push = new DiscardItemResult();
			if (statusCode == HandlerState.GOODS_GIVEUPFAIL)
			{
				GlobalFunction.ShowInfoAtCenter(GoodsLang.ITEM_GIVEUP_FAIL);
			}
			return push;
		}
	}
}
