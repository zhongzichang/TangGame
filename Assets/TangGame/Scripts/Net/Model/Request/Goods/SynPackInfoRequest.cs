/*
 * Created by SharpDevelop.
 * User: shimudennis
 * Date: 2013/11/11
 * Time: 11.07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
	/// <summary>
	/// 请求同步背包信息
	/// create by huxiaobo
	/// </summary>
	public class SynPackInfoRequest : Request
	{
		private int itemPos;
		/// <summary>
		/// 请求同步背包信息
		/// </summary>
		public SynPackInfoRequest()
		{
		}
		 public NetData NetData
	    {
	        get
	        {
	            NetData data = new NetData(GoodsProxy.S_PACK_DATA);
	            return data;
	        }
	    }
	}
}
