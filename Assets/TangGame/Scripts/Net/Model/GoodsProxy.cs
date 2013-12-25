/*
 * Created by SharpDevelop.
 * User: huxiaobo
 * Date: 2013/11/8
 * Time: 14:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TangGame.Net
{
	public class GoodsProxy
	{
		public const short TYPE = 0x0400;
		//请求背包数据
		public const short S_PACK_DATA = TYPE + 0x0001;
		//使用道具
		public const short S_USE_ITEM  = TYPE + 0x0002;
		//整理背包
		public const short S_SORT_PACK = TYPE + 0x0003;
		//丢弃道具
		public const short S_DISCARD_ITEM = TYPE + 0x0004;
		//从临时背包中取出
		public const short S_TEMP_TO_PACK = TYPE + 0x0005;
	}
}
