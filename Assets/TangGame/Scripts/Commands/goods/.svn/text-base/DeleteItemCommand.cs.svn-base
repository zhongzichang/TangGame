using System;
using UnityEngine;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TangGame.Net;
using System.Collections.Generic;
namespace TangGame
{
	/// <summary>
	/// 删除背包和临时背包道具
	/// create by huxiaobo
	/// 2013.11.12
	/// </summary>
	public class DeleteItemCommand : SimpleCommand
	{
		public static string NAME = TangGame.Net.DeleteItemResult.NAME;		
		public override void Execute (INotification notification)
		{
			DeleteItemResult result = notification.Body as DeleteItemResult;
			short itemInPack = result.itemInPack;	
			List<DeleteItemInfo> list = result.goodsInfo;
			foreach(DeleteItemInfo info in list)
			{
	        	bool isDeleted = false;
	        	switch (itemInPack)
	        	{
	        		case GoodsInfo.ITEM_IN_PACK://如果是正式背包的道具,直接通知面板删除显示
        			isDeleted = GoodsCache.DeletePackGoodsItem(info.itemPos);
        			if (isDeleted)
        			{
	        			SendNotification(NotificationIDs.ID_DeletePackGoods, info.itemPos);	
//						Debug.Log("删除了背包中" + info.itemPos + "位置上道具");
	        			}
        			break;
        		case GoodsInfo.ITEM_IN_TEMP://如果是临时背包的道具，先把面板清空，再重新根据临时背包中的数据进行排行和显示        			
        			isDeleted = GoodsCache.DeleteTempPackGoodsItem(info.itemPos);
//        			if (isDeleted)
//	        			Debug.Log("删除了临时背包中" + info.itemPos + "位置上道具");
        			break;
	        	}
	        	
			}
			if (itemInPack == GoodsInfo.ITEM_IN_TEMP)//如果当前是通知删除临时背包中的道具，需要通知面板全体刷新
			{
			
			}
		}
	}
}

