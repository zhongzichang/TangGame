using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using TangUtils;
using UnityEngine;

namespace TangGame.Xml
{
  public class Task
  {
    /// <summary>
    /// 任务ID
    /// </summary>
    public int Id;
    /// <summary>
    /// 任务名称
    /// </summary>
    public string Name;
    /// <summary>
    /// 任务类型
    /// </summary>
    public int Task_type;
    /// <summary>
    /// 是否能取消
    /// </summary>
    public int Abandon;
    /// <summary>
    /// 是否默认领取
    /// </summary>
    public int The_default_for;
    /// <summary>
    /// 接受任务NPCId
    /// </summary>
    public int Accept_npc;
    /// <summary>
    /// 交任务NPC的id
    /// </summary>
    public int Return_npc;
    /// <summary>
    /// 任务接受条件
    /// </summary>
    public string Obtaincond;
    /// <summary>
    /// 完成任务条件
    /// </summary>
    public string Condition;
    /// <summary>
    /// 主UI任务栏追踪效果
    /// </summary>
    public string Effect;
    /// <summary>
    /// 是否需要快速传送图标
    /// </summary>
    public int Quick;
    /// <summary>
    /// 任务可完成时的任务描述
    /// </summary>
    public string Tracker;
    /// <summary>
    /// 任务进行时的任务描述
    /// </summary>
    public string In_chinese_characters;
    /// <summary>
    /// 任务可完成时的任务描述
    /// </summary>
    public string Complete_the_word;
    /// <summary>
    /// 任务可接时的任务描述
    /// </summary>
    public string Can_answer_that;
    /// <summary>
    /// 接受任务时NPC的对话内容
    /// </summary>
    public string Note;
    /// <summary>
    /// 完成任务时NPC的对话内容
    /// </summary>
    public string Complete_note;
    /// <summary>
    /// 任务奖励
    /// </summary>
    public string Reward;
    public int Tutorial_begin;
    public int Tutorial_end;
    public int Map;
    /// <summary>
    /// 接受任务单项条件
    /// </summary>
    public ObtaincondItem obtaincondItem;
    /// <summary>
    /// 完成任务单项条件
    /// </summary>
    public ConditionItem conditionItem;
    /// <summary>
    /// 追踪任务条件
    /// </summary>
    public EffectItem effectItem;

  }
  /// <summary>
  /// 接受任务单项条件
  /// </summary>
  public class ObtaincondItem{
    /// <summary>
    /// 接受任务条件类型
    /// </summary>
    public AcceptType acceptType;
    public int heroLevel;
    public int taskId;
    public int mapId;
    /// <summary>
    /// 1组队、2加入帮会、3加入联盟
    /// </summary>
    public int heroMutualSate;
    public static ObtaincondItem Parse(string obtaincondItemStr){
      //如果接受条件为空,则返回空
      if(obtaincondItemStr == null)
        return null;
      //如果接受条件为空,则返回空
      if(obtaincondItemStr.Length <= 0)
        return null;

      ObtaincondItem obtaincondItem = new ObtaincondItem();
      string[] valItems = obtaincondItemStr.Split(TaskLang.ITEM_DELIMITER);
      int index = 0;
      //如果接受条件为-1,则返回空
      if(valItems[index] == "-1")
        return null;
      obtaincondItem.acceptType = (AcceptType)int.Parse(valItems[index++]);
      switch(obtaincondItem.acceptType){
      case AcceptType.HEROLV:
        obtaincondItem.heroLevel = int.Parse(valItems[index++]);
        break;
      case AcceptType.LASTTASK:
        obtaincondItem.taskId = int.Parse(valItems[index++]);
        break;
      case AcceptType.MUTUAL:
        obtaincondItem.heroMutualSate = int.Parse(valItems[index++]);
        break;
      case AcceptType.NONE:
        break;
      case AcceptType.SCENE:
        obtaincondItem.mapId = int.Parse(valItems[index++]);
        break;
      default:
        break;
      }
      return obtaincondItem;
    }
  }
  /// <summary>
  /// 完成任务单项条件
  /// </summary>
  public class ConditionItem{
    /// <summary>
    /// 完成任务条件类型
    /// </summary>
    public CompleteTaskConditionType completeTaskConditionType;
    public int monsterId;
    public int goodId;
    public int npcId;
    /// <summary>
    /// 播放动画ID
    /// </summary>
    public int animationId;
    public int skillId;
    /// <summary>
    /// 完成任务条件的数量
    /// </summary>
    public int num;

    public static ConditionItem Parse(string conditionItemStr){
      //如果接受条件为空,则返回空
      if(conditionItemStr == null)
        return null;
      //如果接受条件为空,则返回空
      if(conditionItemStr.Length <= 0)
        return null;
      
      ConditionItem conditionItem = new ConditionItem();
      string[] valItems = conditionItemStr.Split(TaskLang.ITEM_DELIMITER);
      int index = 0;
      //如果接受条件为-1,则返回空
      if(valItems[index] == "-1")
        return null;
      conditionItem.completeTaskConditionType = (CompleteTaskConditionType)int.Parse(valItems[index++]);
      switch(conditionItem.completeTaskConditionType){
      case CompleteTaskConditionType.KILLMONSTER:
        conditionItem.monsterId = int.Parse(valItems[index++]);
        conditionItem.num = int.Parse(valItems[index++]);
        break;
      case CompleteTaskConditionType.NPC:
        conditionItem.npcId = int.Parse(valItems[index++]);
        conditionItem.num = int.Parse(valItems[index++]);
        break;
      case CompleteTaskConditionType.UITEMS:
        conditionItem.goodId = int.Parse(valItems[index++]);
        conditionItem.num = int.Parse(valItems[index++]);
        break;
      case CompleteTaskConditionType.ESCORT:
        conditionItem.npcId = int.Parse(valItems[index++]);
        conditionItem.num = int.Parse(valItems[index++]);
        break;
      case CompleteTaskConditionType.CITEMS:
        conditionItem.goodId = int.Parse(valItems[index++]);
        conditionItem.num = int.Parse(valItems[index++]);
        break;
      case CompleteTaskConditionType.ANIMATION:
        conditionItem.animationId = int.Parse(valItems[index++]);
        conditionItem.num = int.Parse(valItems[index++]);
        break;
      }
      return conditionItem;
    }

  }
  /// <summary>
  /// 追踪任务条件
  /// </summary>
  public class EffectItem{
    /// <summary>
    /// 追踪类型
    /// </summary>
    public TrackType trackType;
    public int monsterId;
    public int mapId;
    public int coordinateX;
    public int coordinateY;
    public int panelId;
    public static EffectItem Parse(string effectItemStr){
      if(effectItemStr == null)
        return null;
      if(effectItemStr.Length <= 0)
        return null;

      EffectItem effectItem = new EffectItem();
      string effectItemHead = effectItemStr.Split(TaskLang.SEMICOLON_DELIMITER)[0];
      //如果接受条件为-1,则返回空
      if(effectItemHead == "-1")
        return null;
      int index = 0;
      string effectItemVal = effectItemStr.Split(TaskLang.SEMICOLON_DELIMITER)[1];
      string[] valItems = effectItemVal.Split(TaskLang.ITEM_DELIMITER);
      effectItem.trackType = (TrackType)int.Parse(effectItemHead);
      switch(effectItem.trackType){
      case TrackType.AUTOFINDITSWAY:
        effectItem.monsterId = int.Parse(valItems[index++]);
        effectItem.mapId = int.Parse(valItems[index++]);
        effectItem.coordinateX = int.Parse(valItems[index++]);
        effectItem.coordinateY = int.Parse(valItems[index++]);
        break;
      case TrackType.OPENPANEL:
        effectItem.panelId = int.Parse(valItems[index++]);
        break;
      }
      return effectItem;
    }

  }

  [XmlRoot("ROOT")]
  [XmlLate("task")]
  public class TaskRoot
  {
    [XmlElement("T")]
    public List<Task>
      items = new List<Task> ();

    public static void LateProcess (object obj)
    {

      TaskRoot root = obj as TaskRoot;
      foreach (Task item in root.items) {
        item.obtaincondItem = ObtaincondItem.Parse(item.Obtaincond);
        item.conditionItem = ConditionItem.Parse(item.Condition);
        item.effectItem = EffectItem.Parse(item.Effect);
        Config.taskTable.Add (item.Id, item);
      }

    }
  }
}