/*
 * Created by SharpDevelop.
 * User: shimudennis
 * Date: 2013/11/8
 * Time: 15:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangGame.Net;
using System.Collections.Generic;

namespace TangGame
{
	/// <summary>
	/// 所有道具的管理器，包括背包和临时背包
	/// </summary>
	public class GoodsCache
	{
		//背包字典		
		public static Dictionary<int, GoodsInfo> packDic = new Dictionary<int, GoodsInfo>();
		//临时背包字典
		public static Dictionary<int, GoodsInfo> tempPackDic = new Dictionary<int, GoodsInfo>();
		/// <summary>
		/// 
		/// 添加道具到背包中
		/// </summary>
		/// <param name="info"></param>
		public static bool AddPackGoodsInfo(GoodsInfo info)
		{
			bool isAdd = true;
			if (packDic.ContainsKey(info.itemPos))//如果当前背包字典中有这个位置的道具，说明只是替换而以
				isAdd = false;
			
			packDic[info.itemPos] = info;
			
			return isAdd;
		}
		/// <summary>
		/// 添加道具到临时背包中
		/// </summary>
		/// <param name="info"></param>
		public static bool AddTempGoodsInfo(GoodsInfo info)
		{
			bool isAdd = true;
			if (tempPackDic.ContainsKey(info.itemPos))//如果当前临时背包字典中有这个位置的道具，说明只是替换而以
				isAdd = false;
			
			tempPackDic[info.itemPos] = info;
			
			return isAdd;
		}
		/// <summary>
		/// 清除所有背包道具
		/// </summary>
		/// <returns></returns>
		public static void DeleteAllPackGoodsItem()
		{
			packDic.Clear();		
		}
		/// <summary>
		/// 根据位置删除背包中的道具
		/// </summary>
		/// <param name="pos"></param>
		/// <returns></returns>
		public static bool DeletePackGoodsItem(int pos)
		{
			bool isDeleted = false;
			if (packDic.ContainsKey(pos))
			{
				packDic.Remove(pos);
				isDeleted = true;
			}
			
			return isDeleted;
		}
		/// <summary>
		/// 根据位置删除临时背包中的道具
		/// </summary>
		/// <param name="pos"></param>
		/// <returns></returns>
		public static bool DeleteTempPackGoodsItem(int pos)
		{
			bool isDeleted = false;
			if (tempPackDic.ContainsKey(pos))
			{
				tempPackDic.Remove(pos);
				isDeleted = true;
			}
			return isDeleted;
		}
		/// <summary>
		/// 根据道具在背包中的位置获取道具信息
		/// </summary>
		/// <param name="pos"></param>
		/// <returns></returns>
		public static GoodsInfo GetPackGoodsInfoByPos(int pos)
		{
			return packDic[pos];
		}
		/// <summary>
		/// 根据道具在临时背包中的位置获取道具信息
		/// </summary>
		/// <param name="pos"></param>
		/// <returns></returns>
		public static GoodsInfo GetTempGoodsInfoByPos(int pos)
		{
			return tempPackDic[pos];
		}

		/// <summary>
		/// 获取背包中的道具数量
		/// </summary>
		/// <returns>The item count.</returns>
		/// <param name="itemIndex">Item index.</param>
		public static int GetItemCountFromPack(int itemIndex)
		{
			int count = 0;
			foreach(GoodsInfo info in packDic.Values)
			{
				if (info.itemIndex == itemIndex)
					count += info.itemNum;
			}
			return count;
		}
	}
}
