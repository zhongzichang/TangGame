/*
 * 由SharpDevelop创建。
 * 用户： Sysin
 * 日期: 2013/4/26
 * 时间: 11:26
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{

public class TrackTaskPush :Response
{
    public int returnNpc;
    public string taskName;
    public long taskId;
    public const string NAME="trackTask_PUSH";
    public TrackTaskPush():base(NAME)
    {


    }

    public static TrackTaskPush Parse(MsgData data)
    {
        TrackTaskPush push=new TrackTaskPush();
        int index=0;

        push.returnNpc=data.GetInt(index++);
        push.taskName=data.GetString(index++);
        push.taskId=(long)data.GetDouble(index++);

        return push;
    }


}
}
