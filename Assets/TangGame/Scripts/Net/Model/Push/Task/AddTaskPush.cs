/*
 * 由SharpDevelop创建。
 * 用户： lygg
 * 日期: 2013/4/16
 * 时间: 17:43
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 接受任务信息
/// </summary>

  public class AddTaskPush : Response
  {
    public HeroTask herotask;
    public const string NAME = "addTask_PUSH";

    public AddTaskPush () : base(NAME)
    {
    }

    public static AddTaskPush Parse (MsgData data)
    {
      AddTaskPush push = new AddTaskPush ();
      push.herotask = HeroTask.Parse (data);
      return push;
    }
  }
}