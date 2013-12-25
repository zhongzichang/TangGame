/*
 * 由SharpDevelop创建。
 * 用户： lygg
 * 日期: 2013/4/17
 * 时间: 11:43
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */

using System;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 完成任务信息
/// </summary>
public class DelTaskResult : Response
{

    public long delTaskId;
    public const string NAME = "delTask_RESULT";
    public DelTaskResult() : base(NAME)
    {
    }

    public static DelTaskResult Parse(MsgData data)
    {

        DelTaskResult result = new DelTaskResult();
        result.delTaskId = (long)data.GetDouble(0);
        return result;
    }
}
}