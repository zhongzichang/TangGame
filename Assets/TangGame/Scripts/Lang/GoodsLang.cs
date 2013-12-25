using UnityEngine;
using System.Collections;
using System.Xml;

/// 文字
public class GoodsLang
{
    /// 装备后绑定
    public const string BINDING_EUQIP = "装备后绑定";
    /// 拾取后绑定
    public const string BINDING_PICK = "拾取后绑定";
    /// 未绑定
    public const string BINDING_NO = "未绑定";
    /// 已绑定
    public const string BINDING_ALREADY = "已绑定";
//
//    //===============================物品类型=====
//    /** 物品类型，武器*/
//    public const string WEAPON = "武器";
//    /** 物品类型，防具*/
//    public const string ARMOR = "防具";
//    /** 物品类型，饰品*/
//    public const string ACCESS = "饰品";
//    /** 物品类型，材料*/
//    public const string MATERIAL = "材料";
//    /** 物品类型，杂物*/
//    public const string DEBRIS = "杂物";
//    /** 物品类型，任务*/
//    public const string TASK = "任务";
//    /** 物品类型，符石，铭石*/
//    public const string STONE = "符石";
//    /** 物品类型，坐骑*/
//    public const string MOUNTS = "坐骑";
//    /** 物品类型，恢复道具*/
//    public const string REPLY = "恢复道具";
//
//
//
//
    public const string GOOD_NUM="数量:";
//    public const string GOOD_TYPE="道具类型:";
//
//    /// 使用等级：
//    public const string USE_LEVEL = "使用等级：";
//
//    /// (已装备)
//    public const string EQUIP_ALREADY = "(已装备)";
//
//    /// 缺少{0}物品
//    public const string LACK_GOODS = "缺少{0}物品";
//    /// 是否销毁物品[{0}]
//    public const string DESTROY_GOODS = "是否销毁物品[{0}]";
//
//    /// 强化属性
//    public const string ENHANCED_PROPERTIES = "强化属性";
//    /// 激活
//    public const string ACTIVATION = "激活";
//    /// 已激活
//    public const string ACTIVATED = "已激活";
//    /// 最大堆叠数
//    public const string MAX_STACK = "最大堆叠数";
//    /// 不可堆叠
//    public const string NON_STACKABLE = "不可堆叠";
//    /// 购买所需{0}铜币
//    public const string GOODS_BUY_PRICE = "购买所需{0}铜币";
//    /// 出售价格{0}铜币
//    public const string GOODS_SELL_PRICE = "出售价格{0}铜币";
//
//
//    //====================
//    /// 暂时无法开启，请联系客服。
//    public const string APPEND_PACK_MSG_1 = "暂时无法开启，请联系客服。";
//    /// 开启新的格子需要转职！
//    public const string APPEND_PACK_MSG_2 = "开启新的格子需要转职！";
//    /// 是否使用[{0}]，扩充背包六格？
//    public const string APPEND_PACK_MSG_3 = "花费60元宝，扩展一行（5格）背包空格\n（首次成为VIP，免费扩展42格）";
//    /// 背包中有物品正在使用，暂时无法整理！
//    public const string APPEND_PACK_MSG_4 = "背包中有物品正在使用，暂时无法整理！";
//    /// 是否花费20000铜币，扩充仓库一行空格？
//    public const string APPEND_PACK_MSG_5 = "是否花费20000铜币,扩充仓库一行空格？";
//    /// <summary>
//    /// 是否前往仓库，成为仙尊可以免费打开远程仓库
//    /// </summary>
//	public const string APPEND_PACK_MSG_6 = "是否前往仓库{0}\n成为仙尊可以免费打开远程仓库{}";
//    /// <summary>
//    /// 物品已存在购物篮
//    /// </summary>
//    public const string SALE_BAG_MSG_1="物品已锁定";
//    /// <summary>
//    /// 物品不可出售
//    /// </summary>
//    public const string SALE_BAG_MSG_2="物品不可出售";
//    /// <summary>
//    /// 出售栏已满
//    /// </summary>
//    public const string SALE_BAG_MSG_3="出售栏已满";

	public const string ITEM_GIVEUP_FAIL = "物品不可丢弃";

		public const string EQUIP_STR 		= "装备";
		public const string MEDICINE_STR 	= "药品";
		public const string MATERIAL_STR	= "材料";
		public const string TASK_STR 		= "任务道具";
		public const string GIFT_STR 		= "礼包";
		public const string STONE_STR 		= "宝石";
		public const string BOX_STR		= "宝箱";
		public const string ITEM_TYPE = "道具类型:";


		public const string ITEM_NUM_STR = "数量:";
		public const string CONFIRM_DIS_STR = "确认要丢弃";
		
		public const string GOODS_CLEANUPLOCK = "请稍候再整理背包";
}
