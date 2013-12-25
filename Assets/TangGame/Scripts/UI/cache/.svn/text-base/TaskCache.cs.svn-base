using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TangGame.Net;

namespace TangGame
{
  public class TaskCache
  {
    //    public static Dictionary<long,HeroTask> heroTasks = new Dictionary<long, HeroTask> ();
    /// <summary>
    /// 已完成未交接任务ID列表，（非英雄任务ID）
    /// </summary>
    public static List<int> noTransferHasBeenCompletedTaskIds = new List<int> ();
    /// <summary>
    /// 已经领取但是未完成的任务ID列表
    /// </summary>
    public static List<int> receivingUnCompletedTaskIds = new List<int> ();
    /// <summary>
    /// 已完成任务ID列表
    /// </summary>
    public static List<int> completedTaskIds = new List<int> ();

    /// <summary>
    /// 未领取的任务ID列表
    /// </summary>
    public static List<int> uncollectedTaskIds = new List<int> ();

    /// <summary>
    /// 可接任务ID列表，（非英雄任务ID）
    /// </summary>
    public static List<int> mayReceiveTaskIds = new List<int> ();



    #region ============2013/12/2 Reconstruction
    /// <summary>
    /// 玩家任务列表信息
    /// </summary>
    private static Dictionary<long,HeroTask> heroTaskDictionary = new Dictionary<long,HeroTask>();
    public static Dictionary<long, HeroTask> HeroTaskDictionary {
      get { return heroTaskDictionary; }
      set { heroTaskDictionary = value; }
    }
    /// <summary>
    /// 根据任务配置ID获取到英雄对应的任务
    /// </summary>
    /// <param name="taskConfigId"></param>
    /// <returns></returns>
    public static HeroTask GetTaskById(int taskConfigId){
      List<HeroTask> taskNoList = new List<HeroTask>(HeroTaskDictionary.Values);
      TangGame.Net.HeroTask heroTask = taskNoList.Find (delegate (HeroTask htk) {
                                                          return htk.taskConfigId == taskConfigId;
                                                        });
      return heroTask;
    }
    /// <summary>
    /// 未完成任务列表
    /// </summary>
    private static Dictionary<int,long> receivingUnCompletedTaskDictonary = new Dictionary<int, long>();
    
    public static Dictionary<int, long> ReceivingUnCompletedTaskDictonary {
      get { return receivingUnCompletedTaskDictonary; }
      set { receivingUnCompletedTaskDictonary = value; }
    }
    /// <summary>
    /// 可完成任务列表
    /// </summary>
    private static Dictionary<int,long> noTransferHasBeenCompletedTaskDictonary = new Dictionary<int, long>();
    /// <summary>
    /// 已完成任务列表
    /// </summary>
    private static Dictionary<int,long> completedTaskDictonary = new Dictionary<int, long>();
    /// <summary>
    /// 未领取任务列表
    /// </summary>
    private static List<int> uncollectedTaskList = new List<int>();
    /// <summary>
    /// 可接任务列表
    /// </summary>
    private static List<int> mayReceiveTaskList = new List<int>();
    #endregion







    /// <summary>
    /// 当前NPC对话队列
    /// </summary>
    public static Queue currentNpcDialogueQueue = new Queue ();

    /// <summary>
    /// 当前追踪任务ID
    /// </summary>
    public static int currentTrackingTaskId = 0;


    
    /// <summary>
    /// 更新或者是添加一个任务
    /// </summary>
    /// <param name='id'>
    /// Identifier.
    /// </param>
    /// <param name='actor'>
    /// Actor.
    /// </param>
    public static void AddOrUpdateHeroTask (HeroTask heroTask)
    {
      if(!HeroTaskDictionary.ContainsKey(heroTask.id)){
        HeroTaskDictionary.Add(heroTask.id,heroTask);
      }else{
        HeroTaskDictionary[heroTask.id] = heroTask;
      }
    }
    /// <summary>
    /// 刷新任务ID列表
    /// </summary>
    public static void RefreshTaskIds ()
    {
      noTransferHasBeenCompletedTaskIds.Clear ();
      receivingUnCompletedTaskIds.Clear ();
      completedTaskIds.Clear ();

      uncollectedTaskIds = new List<int> (Config.taskTable.Keys);
      foreach (Net.HeroTask heroTask in HeroTaskDictionary.Values) {
        //删除已接任务列表
        uncollectedTaskIds.Remove (heroTask.taskConfigId);
        //如果任务完成未交
        if (heroTask.state == TaskState.UNTO) {
          noTransferHasBeenCompletedTaskIds.Add (heroTask.taskConfigId);
        }
        //如果任务接取未完成
        if (heroTask.state == TaskState.UNDO) {
          receivingUnCompletedTaskIds.Add (heroTask.taskConfigId);
        }
        //如果任务已完成已经交接
        if (heroTask.state == TaskState.COMPLETE) {
          completedTaskIds.Add (heroTask.taskConfigId);
        }
        List<Net.HeroTask> list = new List<Net.HeroTask> ();
      }
    }
    /// <summary>
    /// 刷新玩家当前的可接任务列表
    /// </summary>
    public static void RefreshMayReceiveTaskIds ()
    {
      RefreshTaskIds ();
      mayReceiveTaskIds.Clear ();
      foreach (int taskId in uncollectedTaskIds) {
        Xml.Task xmlTask = Config.taskTable [taskId];
        ContrastCanBeAccessedByTheTaskConditions (xmlTask);
      }
      PureMVC.Patterns.Facade.Instance.SendNotification(NpcTaskMarkCmd.NAME);
    }
    /// <summary>
    /// 可接任务条件对比
    /// </summary>
    private static void ContrastCanBeAccessedByTheTaskConditions (Xml.Task xmlTask)
    {
      Xml.ObtaincondItem obtaincondItem = xmlTask.obtaincondItem;
      //如果条件没有则添加任务跳出此方法~
      if (obtaincondItem == null) {
        mayReceiveTaskIds.Add (xmlTask.Id);
      }
      TangGame.Net.HeroNew leadingHero = ActorCache.GetLeadingHero ();
      switch (obtaincondItem.acceptType) {
        case AcceptType.NONE:
          break;
        case AcceptType.HEROLV:
          //如果玩家等级大于任务条件等级
          if (leadingHero.level < obtaincondItem.heroLevel) {
            return;
          }
          break;
        case AcceptType.LASTTASK:
          //如果当前任务前置任务未完成则跳出此方法
          if (!completedTaskIds.Contains (obtaincondItem.taskId)) {
            return;
          }
          break;
        case AcceptType.SCENE:
          //如果当前地图ID不符合条件则跳出此方法
          if (leadingHero.mapId != obtaincondItem.mapId) {
            return;
          }
          break;
      }
      //把满足条件的任务添加到可接任务列表中
      mayReceiveTaskIds.Add (xmlTask.Id);

    }


    //获取一个默认的追踪任务ID
    public static int GetDefaultTrackTaskId ()
    {
      if (currentTrackingTaskId != 0) {
        return currentTrackingTaskId;
      }
      if (noTransferHasBeenCompletedTaskIds.Count > 0) {
        return noTransferHasBeenCompletedTaskIds [0];
      }
      if (receivingUnCompletedTaskIds.Count > 0) {
        return receivingUnCompletedTaskIds [0];
      }
      if (mayReceiveTaskIds.Count > 0) {
        return mayReceiveTaskIds [0];
      }
      if (uncollectedTaskIds.Count > 0) {
        return uncollectedTaskIds [0];
      }
      return 0;

    }
  }
}