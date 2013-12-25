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
	/// 丢弃道具请求
	/// create by huxiaobo
	/// </summary>
	public class DiscardItemRequest : Request
	{
		private int itemPos;
		/// <summary>
		/// 丢弃道具请求
		/// </summary>
		/// <param name="pos">道具在背包中的位置</param>
		public DiscardItemRequest(int pos)
		{
			this.itemPos = pos;
		}
		 public NetData NetData
	    {
	        get
	        {
	            NetData data = new NetData(GoodsProxy.S_DISCARD_ITEM);
	            data.PutInt(itemPos);
	            return data;
	        }
	    }
	}
}
