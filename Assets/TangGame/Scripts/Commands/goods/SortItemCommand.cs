using System;
using UnityEngine;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TangGame.Net;
using System.Collections.Generic;
namespace TangGame
{
	/// <summary>
	/// 背包整理完成
	/// create by huxiaobo
	/// 2013.11.12
	/// </summary>
	public class SortItemCommand : SimpleCommand
	{
		public static string NAME = TangGame.Net.SortPackResult.NAME;		
		public override void Execute (INotification notification)
		{
			SortPackResult result = notification.Body as SortPackResult;
			switch(result.StatusCode)
			{
				case HandlerState.NORMAL:
					switch (result.itemInPack)
					{
					//如果是正式背包的道具,清空背包，再重新添加
					case GoodsInfo.ITEM_IN_PACK:
						//先清空缓存的数据
						GoodsCache.DeleteAllPackGoodsItem();
						foreach(GoodsInfo info in result.goodsInfo)
							GoodsCache.AddPackGoodsInfo(info);					
						SendNotification(NotificationIDs.ID_ReflushPackGoods, result.goodsInfo);
						break;
					case GoodsInfo.ITEM_IN_TEMP:
					//临时背包不可能有整理的 
						break;		
					}
					break;
			case HandlerState.GOODS_CLEANUPLOCK:
				GlobalFunction.ShowInfoAtCenter(GoodsLang.GOODS_CLEANUPLOCK);
				break;

			}

		}
	}
}

