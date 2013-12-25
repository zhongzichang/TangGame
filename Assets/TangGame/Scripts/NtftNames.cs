/**
 * Created by emacs
 * Date: 2013/10/17
 * Author: zzc
 */

namespace TangGame
{
  public class NtftNames
  {
    public const string TG_LOADING_ASSETBUNDLE = "TG_LOADING_ASSETBUNDLE";
    public const string TG_LOADING_XML = "TG_LOADING_XML";
    public const string TG_PRELOAD_COMPLETED = "TG_PRELOAD_COMPLETED";
    public const string TG_ERROR_MSG_ALERT = "TG_ERROR_MSG_ALERT";
    public const string TG_RUN_LAST_INSTRUCTION_TEMPORARY = "TG_RUN_LAST_INSTRUCTION_TEMPORARY";  
	
    /// <summary>
    /// 注册场景手势输入消息
    /// </summary>
    public const string ON_REGISTER_GESTURE_INPUT = "TG_ON_REGISTER_GESTURE_INPUT";
    /// <summary>
    /// 注销场景手势输入消息
    /// </summary>
    public const string UN_REGISTER_GESTURE_INPUT = "TG_UN_REGISTER_GESTURE_INPUT";

    /// <summary>
    /// 追踪某个任务
    /// </summary>
    public const string TG_TRACK_CHANGE_TASK = "TG_TRACK_CHANGE_TASK";
    
    /// <summary>
    /// 自动寻路
    /// </summary>
    public const string AUTO_NAV = "TG_AUTO_NAV";

    /// <summary>
    ///   自动寻路已开启
    /// </summary>
    public const string AUTO_NAV_STARTED = "TG_AUTO_NAV_STARTED";

    /// <summary>
    ///   自动寻路已中止
    /// </summary>
    public const string AUTO_NAV_TERMINATED = "TG_AUTO_NAV_TERMINATED";
    
    /// 更新技能栏,需要传入SkillBarBean
    /// </summary>
    public const string TG_UPDATE_SKILL_BAR = "TG_UPDATE_SKILL_BAR";
    /// <summary>
    /// 更新多个技能栏,需要传入SkillBarBean[]
    /// </summary>
    public const string TG_UPDATE_SKILL_BARS = "TG_UPDATE_SKILL_BARS";

		/// <summary>
		/// 一个技能被使用成功的消息,传一个int值
		/// </summary>
		public const string TG_SKILL_USEED = "TG_SKILL_USEED";

    /// <summary>
    /// 自动追踪指定任务，需要传入任务ID，否则就自动追踪当前追踪的任务
    /// </summary>
    public const string TG_AUTO_TRACK_TASK = "TG_AUTO_TRACK_TASK";
    
    /// <summary>
    /// 挂机
    /// </summary>
    public const string TG_HOOK = "TG_HOOK";
    
    /// <summary>
    /// 取消挂机
    /// </summary>
    public const string TG_UNHOOK = "TG_UNHOOK";

    /// <summary>
    ///   记载开始
    /// </summary>
    public const string TG_LOADING_START = "TG_LOADING_START";

    /// <summary>
    ///   加载进度更新
    /// </summary>
    public const string TG_LOADING_PROGRESS = "TG_LOADING_PROGRESS";

    /// <summary>
    ///   加载消息更新
    /// </summary>
    public const string TG_LOADING_MESSAGE = "TG_LOADING_MESSAGE";

    /// <summary>
    ///   加载结束
    /// </summary>
    public const string TG_LOADING_END = "TG_LOADING_END";

    /// <summary>
    /// 显示错误消息
    /// </summary>
    public const string TG_SHOW_ERROR_MESSAGE = "TG_SHOW_ERROR_MESSAGE";

    /// <summary>
    ///   主角死亡
    /// </summary>
    public const string TG_LEADING_ACTOR_DIE = "TG_LEADING_ACTOR_DIE";

    /// <summary>
    ///   主角重生
    /// </summary>
    public const string TG_LEADING_ACTOR_RELIVE = "TG_LEADING_ACTOR_RELIVE";


    /// <summary>
    ///   主角已进入场景中
    /// </summary>
    public const string TG_LEADING_ACTOR_READY = "TG_LEADING_ACTOR_READY";
    
  }

}