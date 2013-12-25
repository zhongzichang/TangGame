using System;
using UnityEngine;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TangGame.Net;
using System.Collections.Generic;
namespace TangGame
{
	public class SynPackInfoCommand : SimpleCommand
	{
		public static string NAME = TangGame.Net.SynPackInfoResult.NAME;
		
		public override void Execute (INotification notification)
		{
			SynPackInfoResult result = notification.Body as SynPackInfoResult;
			List<GoodsInfo> list = result.goodsInfo;
			foreach(GoodsInfo info in list)
			{				
	        	bool isAdd = false;
	        	switch (info.itemInPack)
	        	{
	        		case GoodsInfo.ITEM_IN_PACK://如果是正式背包的道具，添加到正式背包中，添加返回false代表只是道具替换
	        			isAdd = GoodsCache.AddPackGoodsInfo(info);
	        			SendNotification(NotificationIDs.ID_SynBagGoodsInfo, info);	        			
	        			break;
	        		case GoodsInfo.ITEM_IN_TEMP://如果是临时背包的道具，添加到临时背包中，添加返回false代表只是道具替换	        			
	        			isAdd = GoodsCache.AddTempGoodsInfo(info);
	        			SendNotification(NotificationIDs.ID_SynTempBagGoodsInfo, info);
	        			break;
	        	}
//	        	if (isAdd)
//	        		Debug.Log("在" + info.itemPos + "位置上添加了" + info.itemIndex + "道具");
//	        	else
//	        		Debug.Log("在" + info.itemPos + "位置上替换成了" + info.itemIndex + "道具");
	        	
			}
		}
	}
}

