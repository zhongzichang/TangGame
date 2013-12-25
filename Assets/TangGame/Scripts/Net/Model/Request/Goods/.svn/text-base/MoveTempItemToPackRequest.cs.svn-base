/*
 * Created by SharpDevelop.
 * User: shimudennis
 * Date: 2013/11/8
 * Time: 18:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
	/// <summary>
	/// 移动临时背包中的道具到背包中
	/// create by huxiaobo
	/// </summary>
	public class MoveTempItemToPackRequest : Request
	{
		private int[] itemPos;
		/// <summary>
		/// 移动临时背包中的道具到背包中
		/// </summary>
		/// <param name="pos">道具在背包中的位置数据，支持同时移动多个道具</param>
		public MoveTempItemToPackRequest(int[] pos)
		{
			this.itemPos = pos;
		}
		 public NetData NetData
	    {
	        get
	        {
	            NetData data = new NetData(GoodsProxy.S_TEMP_TO_PACK);
	            for (int i = 0; i < itemPos.Length; i++)
	            {
	            	data.PutInt(itemPos[i]);
	            }
	            return data;
	        }
	    }
	}
}
