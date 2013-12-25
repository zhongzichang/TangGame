using UnityEngine;
using System.Collections;

public enum RewardTypeEnum
{
  NONE=0,
  /// <summary>
  /// 经验
  /// </summary>
  EXP,
  /// <summary>
  /// 道具
  /// </summary>
  ITEM,
  /// <summary>
  /// 铜钱
  /// </summary>
  MONEY,
  /// <summary>
  /// 银锭
  /// </summary>
  SILVERINGOT,
  /// <summary>
  /// 金锭
  /// </summary>
  GOLDINGOT,

 
}
/// <summary>
/// 任务交接状态
/// </summary>
public enum TaskState
{
  NONE,
  /// <summary>
  /// 接取未完成
  /// </summary>
  UNDO,
  /// <summary>
  /// 完成未交付
  /// </summary>
  UNTO,
  /// <summary>
  /// 完成已交付
  /// </summary>
  COMPLETE,

}

/// <summary>
/// 任务类型
/// </summary>
public enum TaskType
{
  NONE,
  /// <summary>
  /// 主线任务
  /// </summary>
  MAIN,
  /// <summary>
  /// 日常
  /// </summary>
  DAILY,
  /// <summary>
  /// 循环
  /// </summary>
  LOOP,
}
/// <summary>
/// 接取任务的条件类型
/// </summary>
public enum AcceptType
{
  NONE,
  /// <summary>
  /// 英雄等级
  /// </summary>
  HEROLV,
  /// <summary>
  /// 需要完成上一个任务
  /// </summary>
  LASTTASK,
  /// <summary>
  /// 需要达到某个场景
  /// </summary>
  SCENE,
  /// <summary>
  /// 改变交换状态 TODO:现在还不需要做
  /// </summary>
  MUTUAL,
}
/// <summary>
/// 完成任务条件
/// </summary>
public enum CompleteTaskConditionType{
  NONE,
  /**
     * 杀怪
     */
  KILLMONSTER,
  /**
     * 收集物品
     */
  CITEMS,
  /**
     * 对话NPC
     */
  NPC,
  /**
     * 护送 TODO:现在还不需要做
     */
  ESCORT,
  /**
     * 播放动画 TODO:现在还不需要做
     */
  ANIMATION,
  /**
     * 使用道具
     */
  UITEMS,

}
/// <summary>
/// 任务追踪类型
/// </summary>
public enum TrackType{
  NONE,
  /// <summary>
  /// 自动寻路
  /// </summary>
  AUTOFINDITSWAY,
  /// <summary>
  /// 打开某个面板
  /// </summary>
  OPENPANEL,

}


