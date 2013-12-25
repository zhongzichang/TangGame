/*
 * 由SharpDevelop创建。
 * 用户： Sysin
 * 日期: 2013/4/26
 * 时间: 12:35
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */

using System;
using System.Collections.Generic;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class UnKnowTaskPush : Response
{
    public const string NAME="unKnowTask_PUSH";
    public long id;
    public UnKnowTaskPush():base(NAME)
    {

    }

    public static UnKnowTaskPush Parse(MsgData data)
    {
        UnKnowTaskPush push=new UnKnowTaskPush();
        int index=0;
        push.id=(long)data.GetDouble(index++);
        return push;
    }
}
}