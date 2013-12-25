
using System;
using System.Collections;
using PureMVC.Patterns;
using TangNet;

namespace TangGame.Net
{

public class SceneProxy
{

    public const short TYPE = 0x1000;

    /** Hero移动 */
    public const short S_HERO_MOVE = 0x1001;
    /** 获取场景中的怪（英雄周围） */
    public const short S_GET_MONSTER = 0x1002;
    /** 获取场景中的NPC */
    public const short S_GET_NPC = 0x1003;
    /** 获取场景中的Hero */
    public const short S_GET_HERO = 0x1004;
    /** 地图传送 */
    public const short S_MAP_DELIVER = 0x1005;
    /** Hero复活 */
    public const short S_HERO_RELIVE = 0x1006;
    /** 搜寻NPC */
    public const short S_SEARCH_NPC = 0x1007;
    /** 搜寻Map */
    public const short S_SEARCH_MAP = 0x1008;
    /** 传送门传送 */
  public const short PORTAL_CONVEY = 0x1009;
    /** 地图传送 */
    public const short S_CONVEY_MAP = 0x1010;
    /** 传送战场 */
    public const short S_CONVEY_FIELD = 0x1011;
    /** FB记录 */
    public const short S_SHOW_FB_RECORD = 0x1012;
    /** 退出FB */
    public const short S_EXIT_FB = 0x1013;
    /** 获取活动标记 */
    public const short S_GET_ACTIVITY_MARK = 0x1014;
    /** 飞地图 */
    public const short S_FLY_MAP = 0x1015;
    /** 获取单个怪信息 */
    public const short S_GET_MONSTER_BY_ID = 0x1016;
    /** 获取单个角色信息 */
    public const short S_GET_HERO_BY_ID = 0x1017;
    /** 获取场景中的物品 */
    public const short S_GET_FLOP_GOODS = 0x1018;
    /** 获取场景中的宠物 */
    public const short S_GET_PET = 0x1019;
    /** 获取单个宠物信息 */
    public const short S_GET_PET_BY_ID = 0x1020;
    /// <summary>
    /// 获取单个npc信息
    /// </summary>
    public const short S_GET_NPC_BY_ID = 0x1021;


		/**新协议，上面有的协议已经没有使用了，但以前直接移植过来的*/
		public const short S_GET_TARGET_HEAD_INFO_BY_ID = 0x1010;

//		/// <summary>
//		///  Hero移动
//		/// </summary>
//		/// <param name="p">英雄所在位置</param>
//		public static void HeroMove(Point p)
//		{
//			NetData data = new NetData(S_HERO_MOVE);
//			data.PutShort(p.x);
//			data.PutShort(p.y);
//			Common.gameClient.SendMessage(data);
//		}
//
//		/// <summary>
//		/// 获取场景中的怪
//		/// </summary>
//		public static void OnSceneMonster()
//		{
//			NetData data = new NetData(S_GET_MONSTER);
//			Common.gameClient.SendMessage(data);
//		}
//
//
//		/// <summary>
//		/// 获取场景中的NPC
//		/// </summary>
//		public static void OnSceneNPC()
//		{
//			NetData data = new NetData(S_GET_NPC);
//			Common.gameClient.SendMessage(data);
//		}
//
//		/// <summary>
//		/// 获取场景中的Hero
//		/// </summary>
//		public static void OnSceneHero()
//		{
//			NetData data = new NetData(S_GET_HERO);
//			Common.gameClient.SendMessage(data);
//		}
//
//		/// <summary>
//		/// 地图传送
//		/// </summary>
//		/// <param name="id">传送门ID</param>
//		public static void DeliverDoor(short id){
//			NetData data = new NetData(S_MAP_DELIVER);
//			data.PutShort(id);
//			Common.gameClient.SendMessage(data);
//		}
//
//		/// <summary>
//		/// Hero复活
//		/// </summary>
//		/// <param name="type">1.原地复活 2,复活点复活 3.道具复活</param>
//		public static void Relive(short type){
//			NetData data = new NetData(S_HERO_RELIVE);
//			data.PutShort(type);
//			Common.gameClient.SendMessage(data);
//		}
//
//		/// <summary>
//		/// 搜寻NPC
//		/// </summary>
//		/// <param name="npcId"></param>
//		public static void SearchNPC(long npcId){
//			NetData data = new NetData(S_SEARCH_NPC);
//			data.PutLong(npcId);
//			Common.gameClient.SendMessage(data);
//		}
//
//		/// <summary>
//		/// 搜寻Map
//		/// </summary>
//		/// <param name="mapId"></param>
//		public static void SearchMap(string mapId){
//			NetData data = new NetData(S_SEARCH_MAP);
//			data.PutString(mapId);
//			Common.gameClient.SendMessage(data);
//		}
//
//		/// <summary>
//		/// 进入副本
//		/// </summary>
//		/// <param name="id"></param>
//		public static void IntoFB(int id){
//			NetData data = new NetData(S_INTO_FB);
//			data.PutShort(id);
//			Common.gameClient.SendMessage(data);
//		}
//
//		/// <summary>
//		/// 地图传送
//		/// </summary>
//		/// <param name="arr"></param>
//		public static void ConveyInMap(ArrayList arr){
//			NetData data = new NetData(S_CONVEY_MAP);
//			data.PutShort((int)arr[0]);
//			data.PutShort((int)arr[1]);
//			Common.gameClient.SendMessage(data);
//		}
//
//		/// <summary>
//		/// 传送到战场
//		/// </summary>
//		public static void ConveyField(){
//			NetData data = new NetData(S_CONVEY_FIELD);
//			Common.gameClient.SendMessage(data);
//		}
//
//		/// <summary>
//		/// FB记录
//		/// </summary>
//		/// <param name="mapId"></param>
//		public static void GetFBRecord(short mapId){
//
//			NetData data = new NetData(S_SHOW_FB_RECORD);
//			data.PutShort(mapId);
//			Common.gameClient.SendMessage(data);
//
//
//		}
//
//		/// <summary>
//		/// 退出FB
//		/// </summary>
//		public static void ExitFB(){
//			NetData data = new NetData(S_EXIT_FB);
//			Common.gameClient.SendMessage(data);
//		}
//
//		/// <summary>
//		/// 获取活动标记
//		/// </summary>
//		public static void GetActivityMark(){
//			NetData data = new NetData(S_GET_ACTIVITY_MARK);
//			Common.gameClient.SendMessage(data);
//		}
//
//		/// <summary>
//		/// 飞地图
//		/// </summary>
//		/// <param name="arr"></param>
//		public static void FlyGameMap(short mapId)
//		{
//			NetData data = new NetData(S_FLY_MAP);
//			data.PutShort(mapId);
//			Common.gameClient.SendMessage(data);
//		}
//
//		/// <summary>
//		/// 获取单个角色信息
//		/// </summary>
//		/// <param name="id"></param>
//		public static void GetHeroMsg(long id){
//			NetData data = new NetData(S_GET_HERO_BY_ID);
//			data.PutLong(id);
//			Common.gameClient.SendMessage(data);
//		}
//
//		/// <summary>
//		/// 获取单个怪信息
//		/// </summary>
//		/// <param name="id"></param>
//		public static void GetMonsterMsg(long id){
//			NetData data = new NetData(S_GET_MONSTER_BY_ID);
//			data.PutLong(id);
//			Common.gameClient.SendMessage(data);
//		}
//
//		/// <summary>
//		/// 获取场景中的物品
//		/// </summary>
//		public static void OnSceneGoods(){
//			NetData data = new NetData(S_GET_FLOP_GOODS);
//			Common.gameClient.SendMessage(data);
//		}
//
//		/// <summary>
//		/// 获取场景中的宠物
//		/// </summary>
//		public static void OnScenePet(){
//
//			NetData data = new NetData(S_GET_PET);
//			Common.gameClient.SendMessage(data);
//
//		}
//
//		/// <summary>
//		/// 获取单个宠物信息
//		/// </summary>
//		/// <param name="petId"></param>
//		public static void GetPetMsg(long petId){
//
//			NetData data = new NetData(S_GET_PET_BY_ID);
//			data.PutLong(petId);
//			Common.gameClient.SendMessage(data);
//		}

}
}
