/*
 * Created by SharpDevelop.
 * User: shimudennis
 * Date: 2013/11/8
 * Time: 17:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;
using UnityEngine;
using System.Collections.Generic;

namespace TangGame.Net
{
	/// <summary>
	/// Description of SynPackInfoPush.
	/// </summary>
	[Response(NAME)]
	public class SortPackResult : Response
	{
		public const string NAME = "goodscleanup_RESULT";
		public short itemInPack = 0;
		public List<GoodsInfo> goodsInfo = null;
		public SortPackResult() : base(NAME)
		{
			goodsInfo = new List<GoodsInfo>();
		}
		public static SortPackResult Parse(short statusCode, MsgData data)
	    {
			SortPackResult push = new SortPackResult();
			push.StatusCode = statusCode;

			if (statusCode == HandlerState.NORMAL)
			{
				push.itemInPack = data.GetShort(0);
				MsgData items = data.GetMsgData(1);
				for (int j = 0; j < items.Size; j++)
				{
					int index = 0;
					MsgData md = items.GetMsgData(j); 	
					GoodsInfo info = new GoodsInfo();
					info.itemId = md.GetLong(index++);
					info.itemIndex = md.GetInt(index++);
					info.itemNum = md.GetInt(index++);
					info.itemCdTime = md.GetLong(index++);
					info.itemInPack = md.GetShort(index++);
					info.itemPos = md.GetInt(index++);
					info.itemValidTime = md.GetLong(index++);					
					push.goodsInfo.Add(info);
				}
			}
			return push;
		}
	}
}
