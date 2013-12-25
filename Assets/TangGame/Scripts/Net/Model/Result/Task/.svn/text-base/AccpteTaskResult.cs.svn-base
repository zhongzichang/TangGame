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
/// 接受任务信息返回
/// </summary>
  [Response(NAME)]
  public class AccpteTaskResult : Response
  {
    public HeroTask herotask;
    public const string NAME = "accpteTask_RESULT";

    public AccpteTaskResult () : base(NAME)
    {
    }

    public static AccpteTaskResult Parse (MsgData data)
    {
      AccpteTaskResult result = new AccpteTaskResult ();
      result.herotask = HeroTask.Parse (data);
      return result;
    }
  }
}