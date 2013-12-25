using UnityEngine;
using System.Collections;
using System.Xml;

/// 全局文字
public class GlobalLang {
	/// 时间
	public const string TIME = "时间";
	/// 内容
	public const string CONTENT = "内容";
	
	///背包
	public const string BAG = "背包";
	///整理
	public const string ARRANGE = "整理";
	///摆摊
	public const string STALL = "摆摊";
	///仓库
	public const string DEPOT = "仓库";
	/// <summary>
	/// 空间
	/// </summary>
	public const string SPACE="空间:";
	/// <summary>
	/// 神秘商店
	/// </summary>
	public const string MYSTERYSHOP="神秘";
	/// <summary>
	/// 出售
	/// </summary>
	public const string SALE="出售";
	/// <summary>
	/// 寄售物品
	/// </summary>
	public const string AUCTION="寄售";
	///商店
	public const string SHOP = "商店";
	///销毁
	public const string DESTROY = "销毁";
	///展示
	public const string SHOW = "展示";
	///学习
	public const string STUDY = "学习";
	///升级
	public const string UPGRADE = "升级";
	///信息
	public const string MESSAGE = "信息";
	///出售
	public const string SELL = "出售";
	///购买
	public const string BUY = "购买";
	///删除
	public const string DELETE = "删除";
	
	///经验
	public const string EXP = "经验";
	///铜币
	public const string COPPER = "铜币";
	/// <summary>
	/// 银锭
	/// </summary>
	public const string SILVERINGOT = "银锭";
	///金锭
	public const string GOLDINGOT = "金锭";
	///荣誉
	public const string HONOR = "荣誉";
	///阵营
	public const string CAMP = "阵营";
	///领取奖励
	public const string RECEIVE_AWARD = "领取奖励";
	
	
	///铜币：
	public const string MONEY_COLON = "铜币：";
	///价格：
	public const string PRICE_ = "价格：";
	/// 是否购买[{0}]？
	public const string MALL_BUY = "是否购买[{0}]？";
	
	///经脉
	public const string MERIDIAN = "经脉";
	///玄晶
	public const string CRYSTAL = "玄晶";
	
	///中文数字
	public const string ZH_0 = "零";
	///中文数字
	public const string ZH_1 = "一";
	///中文数字
	public const string ZH_2 = "二";
	///中文数字
	public const string ZH_3 = "三";
	///中文数字
	public const string ZH_4 = "四";
	///中文数字
	public const string ZH_5 = "五";
	///中文数字
	public const string ZH_6 = "六";
	///中文数字
	public const string ZH_7 = "七";
	///中文数字
	public const string ZH_8 = "八";
	///中文数字
	public const string ZH_9 = "九";
	///中文数字
	public const string ZH_10 = "十";
	//============================================================================
	/// 确定，OK
	public const string OK = "确定";
	/// 取消，Canel
	public const string CANCEL = "取消";
	/// 重置
	public const string RESET = "重置";
	
	//============================================================================
	/// 攻击力
	public const string ATK = "攻击力";
	
	
	//======================================符号======================================
	///左中括号【
	public const string ZH_BRACKETS_L = "【";
	///右中括号】
	public const string ZH_BRACKETS_R = "】";
	///冒号：
	public const string ZH_RISK = "：";
	
	///显示
	public const string DISPLAY = "显示";
	///音乐
	public const string MUSIC = "音乐";
	///GM，由于可能被改成其他的故设置了常量
	public const string GM = "GM";
	///屏蔽玩家
	public const string SHIELD_PLAYER = "屏蔽玩家";
	///屏蔽聊天
	public const string SHIELD_CHAT = "屏蔽聊天";
	///屏蔽NPC
	public const string SHIELD_NPC = "屏蔽NPC";
	///屏蔽技能特效
	public const string SHIELD_EFFECT = "屏蔽技能特效";
	
	
	///背景音乐
	public const string BACKGROUND_MUSIC = "背景音乐";
	///游戏音效
	public const string GAME_SOUND = "游戏音效";
	
	///亲爱的玩家你好！
	public const string GM_WORDS1 = "亲爱的玩家你好！";
	///欢迎使用大唐魂客服系统
	public const string GM_WORDS2 = "欢迎使用大唐魂客服系统。";
	///客服电话
	public const string GM_WORDS3 = "客服电话：028-88888888";
	///点击提交问题
	public const string GM_CLICK_SUBMIT = "点击提交问题";
	///提交问题
	public const string GM_SUBMIT = "提交问题";
	///提交问题
	public const string GM_INPUT_WORDS = "点击此处输入您想要提交的问题";
	
	///离线
	public const string OFFLINE = "离线";
	///在线
	public const string ONLINE = "在线";
	
	//===========================================================================
	///商城
	public const string MALL = "商城";
	///热卖
	public const string HOT_SALL = "热卖";
	///药品
	public const string REMEDY = "药品";
	///常用
	public const string OFTEN = "常用";
	///折扣
	public const string DISCOUNT = "折扣";
	
	//===========================================================================
	///连接已断开！
	public const string SYS_CONNECT_COLSE = "连接已断开！";
	///服务器维护中！
	public const string SYS_MAINTAIN = "服务器维护中！";
	///游戏角色被封停！
	public const string SYS_ROLE_SEAL = "游戏角色被封停！";
	//===========================================================================
	///铜币不足！
	public const string MONEY_NOT_ENOUGH = "铜币不足！";
	///金锭不足！
	public const string COIN_NOT_ENOUGH = "金锭不足！";
	///礼券不足！
	public const string PAPER_NOT_ENOUGH = "礼券不足！";
	
	//===========================================================================
	/// 查看信息
	public const string VIEW_INFO = "查看信息";
	/// 发送私聊
	public const string SEND_WHISPER = "发送私聊";
	/// 邀请组队
	public const string TEAM_INVITE = "邀请组队";
	/// 发送邮件
	public const string SEND_MAIL = "发送邮件";
	/// 加为好友
	public const string ADD_FRIEND = "加为好友";
	/// 申请组队
	public const string TEAM_APPLY = "申请组队";
	
	//====================
	/// 玩家模式修改为【普通模式】
	public const string MODE_GENERAL = "玩家模式修改为【普通模式】";
	/// 玩家模式修改为【杀戮模式】
	public const string MODE_FIGHT = "玩家模式修改为【杀戮模式】";
	
	//====================================其它=====================================
	public const string REMNUM = "剩余{0}次";
	
	
	
	/// <summary>
	/// 男性
	/// </summary>
	public const string MALE="m";
	/// <summary>
	/// 女性
	/// </summary>
	public const string FEMALE="f";
}
