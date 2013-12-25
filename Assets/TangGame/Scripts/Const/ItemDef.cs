/*
 * 道具相关定义枚举
 * User: huxiaobo
 * Date: 2013/11/11
 * Time: 19:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TangGame
{
	/// <summary>
	/// 道具发光
	/// </summary>
	public class ItemShine
	{
		public const int NONE 		= 0;//无色
		public const int WHITE 		= 1;//白色
		public const int GREEN 		= 2;//绿色
		public const int BLUE		= 3;//蓝色
		public const int PURPLE		= 4;//紫色
		public const int RED	 	= 5;//红色
		public const int ORANGE		= 6;//橙色
	}
	/// <summary>
	/// 道具大类
	/// </summary>
	public class ItemBigType
	{
		public const int EQUIP 		= 1;//装备
		public const int MEDICINE 	= 2;//药品
		public const int MATERIAL	= 3;//材料
		public const int TASK 		= 4;//任务道具
		public const int GIFT 		= 5;//礼包
		public const int STONE 		= 6;//宝石
		public const int BOX 		= 7;//宝箱
	}
	public class ItemMiniType
	{
		
	}
	/// <summary>
	/// 道具品质
	/// </summary>
	public class ItemQulity
	{
		public const int WHITE 		= 1;//白色
		public const int GREEN 		= 2;//绿色
		public const int BLUE		= 3;//蓝色
		public const int PURPLE		= 4;//紫色
		public const int RED	 	= 5;//红色
		public const int ORANGE		= 6;//橙色
	}
	/// <summary>
	/// 绑定状态
	/// </summary>
	public class BindState
	{
		public const int NONE		= 1;//不绑定
		public const int PICK_BIND	= 2;//拾取绑定
		public const int EQUIP_BIND	= 3;//装备绑定
	}
}
