/*
 * Created by SharpDevelop.
 * User: shimudennis
 * Date: 2013/11/8
 * Time: 15:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;
using UnityEngine;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections.Generic;
namespace TangGame.Net
{
	/// <summary>
	/// 删除清空一个道具
	/// </summary>
	[Response(NAME)]
	public class DeleteItemResult : Response
	{
		public const string NAME = "goodsisnull_PUSH";
		
		public short itemInPack;
		public List<DeleteItemInfo> goodsInfo;
	
	    public DeleteItemResult() : base(NAME)
	    {
	    	goodsInfo = new List<DeleteItemInfo>();
	    }
	
	    public static DeleteItemResult Parse(MsgData data)
	    {
	        DeleteItemResult push = new DeleteItemResult();	
	        push.itemInPack = data.GetShort(0);
			MsgData items = data.GetMsgData(1);
			for (int j = 0; j < items.Size; j++)
			{
				int index = 0;
				MsgData md = items.GetMsgData(j); 	
	        	DeleteItemInfo info = new DeleteItemInfo();
	        	info.itemPos = md.GetInt(index++);
	        	info.itemId = md.GetLong(index++);
				push.goodsInfo.Add(info);
			}	        
//	        for (int i = 0; i < data.Size; i++)
//	        {
//	        	int index = 0;		
//	        	MsgData  md = data.GetMsgData(i);
//	        	push.isInPack = md.GetShort(index++);
//	        	push.itemPos	   = md.GetInt(index++);
//	        	push.itemId   = md.GetLong(index++);
//	        }	
	        return push;
	
	    }
	}
}
