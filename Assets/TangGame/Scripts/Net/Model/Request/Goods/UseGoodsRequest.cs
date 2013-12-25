/*
 * Created by SharpDevelop.
 * User: shimudennis
 * Date: 2013/11/8
 * Time: 17:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
	/// <summary>
	/// Description of UseGoodsRequest.
	/// create by huxiaobo
	/// </summary>
	public class UseGoodsRequest : Request
	{
		private int itemIndex;
		private int itemPos;
		private int itemNum;
		/// <summary>
		/// 使用道具请求
		/// </summary>
		/// <param name="id">道具全局ID</param>
		/// <param name="pos">道具在背包中的位置</param>
		/// <param name="num">使用数量</param>
		public UseGoodsRequest(int index, int pos, int num)
		{
			this.itemIndex = index;
			this.itemPos = pos;
			this.itemNum = num;
		}
		 public NetData NetData
	    {
	        get
	        {
	            NetData data = new NetData(GoodsProxy.S_USE_ITEM);
	
	            data.PutInt(itemIndex);
	            data.PutInt(itemPos);
	            data.PutInt(itemNum);
	            return data;
	        }
	    }
	}
}
