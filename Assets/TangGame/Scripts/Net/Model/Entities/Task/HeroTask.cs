using System;
using System.Collections.Generic;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
  public class HeroTask
  {
    public long id;
    public TaskState state;
    public bool isDel;
    /** 循环任务次数*/
    public int loopTaskNum;
    /// <summary>
    /// 单个任务条件
    /// </summary>
    public Item condition;
    /// <summary>
    ///任务条件集合
    /// </summary>
    public List<Item> conditions;
    /** 是否追踪 */
    public short track;
    /** 任务 */
    public int taskConfigId;
    /** 版本号 */
    public int version;
    /** 是否领取福利 */
    public bool isGetWelfareReward;

    public HeroTask ()
    {
//        this.task = new Task();
      this.conditions = new List<Item> ();
    }

    public static HeroTask Parse (MsgData data)
    {
      int index = 0;
      HeroTask heroTask = new HeroTask ();
      heroTask.id = data.GetLong(index++);
      heroTask.taskConfigId = data.GetInt(index++);
      heroTask.state = (TaskState)data.GetShort(index++);
      Item item = new Item();
      item.num = data.GetInt(index++);
      item.oldNum = data.GetInt(index++);
      heroTask.condition = item;
      return heroTask;
    }
  }
}
