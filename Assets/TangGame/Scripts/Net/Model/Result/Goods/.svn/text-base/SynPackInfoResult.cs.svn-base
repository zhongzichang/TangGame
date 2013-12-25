/*
 * Created by SharpDevelop.
 * User: shimudennis
 * Date: 2013/11/8
 * Time: 15:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using TangNet;
using PureMVC.Interfaces;
using PureMVC.Patterns;

namespace TangGame.Net
{
	/// <summary>
	/// Description of SynPackInfoPush.
	/// </summary>
	[Response(NAME)]
	public class SynPackInfoResult : Response
	{
		public const string NAME = "goodsinfo_PUSH";
		public List<GoodsInfo> goodsInfo;
	    public SynPackInfoResult() : base(NAME)
	    {
			goodsInfo = new List<GoodsInfo>();
	    }
	
	    public static SynPackInfoResult Parse(MsgData data)
	    {
	        SynPackInfoResult push = new SynPackInfoResult();
        	MsgData  items = data.GetMsgData(0);
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
	        return push;
	
	    }
	}
}
