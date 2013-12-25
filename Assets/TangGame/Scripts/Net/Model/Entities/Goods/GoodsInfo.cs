/*
 * Created by SharpDevelop.
 * User: shimudennis
 * Date: 2013/11/8
 * Time: 15:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TangGame.Net
{
	/// <summary>
	/// 服务器同步过来的道具信息
	/// </summary>
	public class GoodsInfo
	{
		public const int ITEM_IN_PACK = 1;
		public const int ITEM_IN_TEMP = 2;
		public long itemId;				//道具唯一Id（Long）
		public int 	itemIndex;			//道具配置Id（Int）
		public int  itemNum;			//道具个数（int）
		public long itemCdTime;			//道具使用CD时间（Long）
		public short itemInPack;		//道具当前所在位置（short 1表示在背包中，2表示在临时背包中）
		public int 	itemPos;			//道具在背包中的格子位置（int）
		public long itemValidTime;		//道具的有效时间（Long），
	}
}
