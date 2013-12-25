/**
 * Handler state
 * 服务器返回的错误码
 * ### 注意：要和服务器的版本同步
 * Date: 2013/11/10
 * Author:zzc
 */


namespace TangGame
{
  
  public class HandlerState
  {
    /** 系统处理错误 */
    public const short ERROR_SYSTEM = -1;
    /** 该账号从别处登陆 */
    public const short OTHER_LOGIN = -2;
    /** 服务器断开连接 */
    public const short KICK_OUT = -3;
    /** 无效客户端连接 */
    public const short INVALID_CONNECTION = -7;
    /** 配置表错误 */
    public const short CONFIG_ERROR = -8;
    /** 客户端发送消息错误（可能有外挂） */
    public const short CLIENTMSG_ERROR = -1;
    /** 正常消息 **/
    public const short NORMAL = 0;

    /** 账号密码错误 **/
    public const short LOGIN_ERROR = 10011;
		/** 道具整理还在CD期间*/
		public const short GOODS_CLEANUPLOCK=30023;

    // **********************战斗提示*************************//
    /** 安全场景不能Pk */
    public const short CANNOT_PK = 20001;
    /** 技能冷却中 */
    public const short SKILL_CD = 20002;
    /** 血不足 */
    public const short HP_LACK = 20003;
    /** 蓝不足 */
    public const short MP_LACK = 20004;
    /** 怒气不足 */
    public const short AN_LACK = 20005;
    /** 目标无效 */
    public const short TARGET_INVALID = 20006;
    /** 技能无效 */
    public const short SKILL_INVALID = 20007;
    /** 瞬移失败 **/
    public const short FAST_MOVE_FAIL = 20008;
    /**攻击距离不够**/
    public const short TARGET_ISNOTRANG=20009;

    // **********************聊天信息提示*************************//
    /** 发送太频繁，稍后再试 */
    public const short CHAT_LITTLE_TIME = 30001;
    /** 聊天等级限制 */
    public const short CHAT_LEVEL_NOT_LACK = 30002;

    // **********************任务提示*************************//
    /** 接受任务等级条件不足 **/
    public const short TASK_HERO_LV = 30011;
    /** 前置任务没有完成 */
    public const short TASK_LAST_TASK = 30012;
    /** 没有在指定的场景中 **/
    public const short TASK_NOTIN_SCENE = 30013;
    /** 没有在指定的状态 **/
    public const short TASK_MUTUAL = 30014;
    /** 该任务不能提交 **/
    public const short TASK_NOTUP = 30015;
    /** 该任务不能放弃 **/
    public const short TASK_NOGIVEUP = 30016;

    // **********************道具提示*************************//
    ///物品使用被CD锁定
    public const short GOODS_LOCK = 30020;
    ///物品个数不足
    public const short GOODS_COUNTISNOT = 30021;
    /// 道具不能批量使用
    public const short GOODS_ISNOTBATCHUSE = 30022;
    ///该物品不能丢弃
    public const short GOODS_GIVEUPFAIL=30024;
    /**当前的背包格子不足不能拾取*/
    public const short GOODS_BAGCOUNTISFULL=30025;
	
    /**********************技能提示*************************/
    /** 已为最高级，无法继续升级 **/
    public const short SKILL_ALREADY_TOP = 30030;
    /** 学习或者升级技能的条件不满足 */
    public const short SKILL_CONDITION_NOT_SATISFIED = 30031;
	
    // **********************装备升级提示*************************//
    /** 装备升级的条件不满足 */
    public const short EQUIP_UPGRADE_CONDITION_NOT_SATISFIED = 30040;
    /** 已为最高级，无法继续升级/强化 **/
    public const short EQUIP_ALREADY_TOP = 30041;
    /** 装备的使用等级超过了玩家的等级 **/
    public const short EQUIP_LV_OVER_HERO_LV = 30042;
    /** 装备强化失败 **/
    public const short EQUIP_STRONG_FAILED = 30043;
  }

}