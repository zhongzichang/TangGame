using System;
using UnityEngine;
using PureMVC.Patterns;
using TangNet;

namespace TangGame.Net
{
public class HeroProxy
{

    public const short TYPE = 0x0200;
    /** 处理心跳 */
    public const short PULSE_HANDLE = 0x0201;
    /** Hero加点 */
    public const short HERO_ALLOT_POINT = 0x0202;
    /** 切换Hero游戏模式 */
    public const short HERO_CHANGE_MODEL = 0x0203;
    /** Hero快捷键修改 */
    public const short UPDATE_SHORTCUT_KEY = 0x0204;
    /** 获取Hero技能 */
    public const short HERO_SKILL_DATA = 0x0205;
    /** 拾取物品 */
    public const short HERO_PICK_UP_GOODS = 0x0206;
    /** 技能升级 */
    public const short HERO_SKILL_UPGRADE = 0x0207;
    /** 调整自动补血 */
    public const short HERO_AUTOHP = 0x0208;
    /** 调整技能消耗内息 */
    public const short HERO_SKILL_CHANGE_BREATH = 0x0209;
    /** 获取其他玩家装备信息 */
    public const short OTHER_HERO_BODY = 0x0210;
    /** 销毁到期道具 */
    public const short DESTROY_GOODS = 0x0211;
    /** 领取持续在线奖励 */
    public const short HERO_ONLINE_REWARD = 0x0212;
    /** 领取累计在线奖励 */
    public const short HERO_ADD_ONLINE_REWARD = 0x0213;
    /** 调整自动补内 */
    public const short HERO_AUTOMP = 0x0214;
    /** 查看可赎回物品 */
    public const short HERO_QUERY_RANSOM_GOODS = 0x0215;
    /** 赎回物品 */
    public const short HERO_RANSOM_GOODS = 0x0216;
    /** 执行脚本 */
    public const short EXECUTE_SCRIPT = 0x0217;
    /** 退出游戏 */
    public const short EXIT_GAME = 0x0218;
    /** 打地鼠得立卷 */
    public const short SUSLIKS_PAPER = 0x0219;
    /** 查看拾取到别人的物品 */
    public const short HERO_OTHER_QUERY_RANSOM_GOODS = 0x0220;
    /** 领取别人掉落的物品 */
    public const short HERO_OTHER_RANSOM_GOODS = 0x0221;
    /** 验证人物位置 */
    public const short VALIDATE_HERO_POINTS = 0x0222;
    /** 修改玩家名称 */
    public const short CHANGE_HERO_NAME = 0x0223;
    /** 获取玩家被击杀信息 */
    public const short GET_HERO_KILL_MSG = 0x0224;
    /** 摇骰子 */
    public const short ROCKING_DICE = 0x0225;

//		public static void PulseHandler()
//		{
//			NetData data = new NetData(PULSE_HANDLE);
//			Common.gameClient.SendMessage(data);
//		}
//
//
//		/** 分配 Hero 属性点 */
//		public static void AllotPoint(short strength, short stamina, short agility, short savvy){
//
//			NetData data = new NetData(HERO_ALLOT_POINT);
//			data.PutShort(strength);
//			data.PutShort(stamina);
//			data.PutShort(agility);
//			data.PutShort(savvy);
//			Common.gameClient.SendMessage(data);
//		}
//
//		/** 切换Hero游戏模式 : 5:帮会 4:组队 3:交流模式 2:杀戮模式 1:普通模式 */
//		public static void ChangeHeroModel(short mode){
//
//			NetData data = new NetData(HERO_CHANGE_MODEL);
//			data.PutShort(mode);
//			Common.gameClient.SendMessage(data);
//
//		}
//
//		/** 更新用户快捷键设置 */
//		public static void UpdateShortcutKey(string shortcutKeys){
//
//			NetData data = new NetData(UPDATE_SHORTCUT_KEY);
//			data.PutString(shortcutKeys);
//			Common.gameClient.SendMessage(data);
//		}
//
//		/** 拾取场景中得物品 */
//		public static void PickUpGoods(long goodsId){
//
//			NetData data = new NetData(UPDATE_SHORTCUT_KEY);
//			data.PutLong(goodsId);
//			Common.gameClient.SendMessage(data);
//
//		}
//
//		/** 技能升级 */
//		public static void SkillUpgrade(int skillSort){
//
//			NetData data = new NetData(HERO_SKILL_UPGRADE);
//			Debug.Log("SkillUpgrade skillSort = " + skillSort);
//			data.PutShort(skillSort);
//			Common.gameClient.SendMessage(data);
//
//		}
//
//		/** 自动补血 */
//		public static void AutoHp(short autoHp){
//
//			NetData data = new NetData(HERO_AUTOHP);
//			data.PutShort(autoHp);
//			Common.gameClient.SendMessage(data);
//
//		}
//
//		/// <summary>
//		///  修改技能使用内息值
//		/// </summary>
//		/// <param name="skillId">技能ID</param>
//		/// <param name="num">用量</param>
//		public static void ChangeBreath(int skillId, short num){
//
//			NetData data = new NetData(HERO_SKILL_CHANGE_BREATH);
//			data.PutInt(skillId);
//			data.PutShort(num);
//			Common.gameClient.SendMessage(data);
//
//		}
//
//		/// <summary>
//		/// 查看其他玩家身上物品信息
//		/// </summary>
//		/// <param name="type">类型</param>
//		/// <param name="heroId">英雄ID</param>
//		public static void GetHeroBodyGoods(short type, long heroId){
//
//			NetData data = new NetData(OTHER_HERO_BODY);
//			data.PutShort(type);
//			data.PutLong(heroId);
//			Common.gameClient.SendMessage(data);
//
//		}
//
//		/// <summary>
//		/// 道具销毁
//		/// </summary>
//		/// <param name="type">类型:1.body, 2.knapsack</param>
//		/// <param name="heroGoodsId">物品ID</param>
//		/// <param name="index">索引</param>
//		public static void GoodsDestory(short type, long heroGoodsId, short index){
//
//			NetData data = new NetData(DESTROY_GOODS);
//			data.PutShort(type);
//			data.PutLong(heroGoodsId);
//			data.PutShort(index);
//			Common.gameClient.SendMessage(data);
//
//		}
//
//		/// <summary>
//		/// 领取玩家在线奖励
//		/// </summary>
//		public static void HeroOnlineReward(){
//
//			NetData data = new NetData(HERO_ONLINE_REWARD);
//			Common.gameClient.SendMessage(data);
//
//		}
//
//		/// <summary>
//		/// 调整自动补内
//		/// </summary>
//		/// <param name="autoMp">百分之多少开始补充</param>
//		public static void AutoMp(short autoMp){
//
//			NetData data = new NetData(HERO_AUTOMP);
//			data.PutShort(autoMp);
//			Common.gameClient.SendMessage(data);
//		}
//
//		/// <summary>
//		/// 查看可赎回物品
//		/// </summary>
//		/// <param name="page">当前页</param>
//		/// <param name="pageSize">页大小</param>
//		public static void QueryRansom(short page, short pageSize){
//
//			NetData data = new NetData(HERO_QUERY_RANSOM_GOODS);
//			data.PutShort(page);
//			data.PutShort(pageSize);
//			Common.gameClient.SendMessage(data);
//		}
//
//		/// <summary>
//		/// 赎回物品
//		/// </summary>
//		/// <param name="type">401,道具  107,礼券</param>
//		/// <param name="heroGoodsId">物品ID</param>
//		public static void RansomGoods(short type, long heroGoodsId){
//
//			NetData data = new NetData(HERO_RANSOM_GOODS);
//			data.PutShort(type);
//			data.PutLong(heroGoodsId);
//			Common.gameClient.SendMessage(data);
//
//		}
//
//		/// <summary>
//		/// 执行脚本
//		/// </summary>
//		/// <param name="funcName"></param>
//		public static void ExecuteScript(string funcName){
//
//			NetData data = new NetData(EXECUTE_SCRIPT);
//			data.PutString(funcName);
//			Common.gameClient.SendMessage(data);
//
//		}
//
//		/** 退出游戏 */
//		public static void ExitGame(){
//	       NetData data = new NetData(EXIT_GAME);
//	       Common.gameClient.SendMessage(data);
//		}
//
//		/// <summary>
//		/// 查看别人掉落的物品
//		/// </summary>
//		public static void QueryOther(short page, short pageSize){
//
//			NetData data = new NetData(HERO_OTHER_QUERY_RANSOM_GOODS);
//
//			data.PutShort(page);
//			data.PutShort(pageSize);
//
//			Common.gameClient.SendMessage(data);
//
//		}
//
//		/// <summary>
//		/// 领取别人掉落的物品
//		/// </summary>
//		/// <param name="heroGoodsId">物品ID</param>
//		public static void OtherRansom(long heroGoodsId) {
//
//			NetData data = new NetData(HERO_OTHER_RANSOM_GOODS);
//
//			data.PutLong(heroGoodsId);
//
//			Common.gameClient.SendMessage(data);
//
//		}
//
//		/// <summary>
//		/// 验证Hero位置
//		/// </summary>
//		/// <param name="heroId">hero ID</param>
//		/// <param name="x">x 坐标</param>
//		/// <param name="y">y 坐标</param>
//		/// <param name="hp">HP</param>
//		public static void ValidateHeroPoints(long heroId, short x, short y, int hp) {
//			NetData data = new NetData(VALIDATE_HERO_POINTS);
//			data.PutLong(heroId);
//			data.PutShort(x);
//			data.PutShort(y);
//			data.PutInt(hp);
//			Common.gameClient.SendMessage(data);
//		}
//
//		/// <summary>
//		/// 改变英雄名字
//		/// </summary>
//		/// <param name="name"></param>
//		public static void ChangeHeroName(string name) {
//
//			NetData data = new NetData(CHANGE_HERO_NAME);
//
//			data.PutString(name);
//
//			Common.gameClient.SendMessage(data);
//		}
//
//		/// <summary>
//		/// 获取玩家被击杀信息
//		/// </summary>
//		public static void GetHeroKillMsg() {
//
//			NetData data = new NetData(GET_HERO_KILL_MSG);
//
//			Common.gameClient.SendMessage(data);
//
//		}
//
//		/// <summary>
//		/// 摇骰子
//		/// </summary>
//		/// <param name="goodsId">物品ID</param>
//		/// <param name="isRocking">1:摇 2:放弃</param>
//		public static void RockingDice(long goodsId, short isRocking){
//
//			NetData data = new NetData(ROCKING_DICE);
//
//			data.PutLong(goodsId);
//			data.PutShort(isRocking);
//
//			Common.gameClient.SendMessage(data);
//
//		}

}
}

