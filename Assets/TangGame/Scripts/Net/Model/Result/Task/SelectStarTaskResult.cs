/*
 * 由SharpDevelop创建。
 * 用户： lygg
 * 日期: 2013/4/17
 * 时间: 15:05
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
/// 获取星级任务
/// </summary>
public class SelectStarTaskResult : Response
{
    public const string NAME = "SelectStarTask_RESULT";


    public SelectStarTaskResult() : base(NAME)
    {
    }
    public static SelectStarTaskResult Parse(MsgData data)
    {

        SelectStarTaskResult result  = new SelectStarTaskResult();

	/*
        for(int i=0; i<data.Size; i++)
        {

            //MsgData selectStarTaskData = data.GetMsgData(i);

            //int sstindex = 0;
            //short sst1 = selectStarTaskData.GetShort(sstindex++);
            //short sst2 = selectStarTaskData.GetShort(sstindex++);
            //double sst3 = selectStarTaskData.GetDouble(sstindex++);
            //short sst4 = selectStarTaskData.GetShort(sstindex++);
        }*/
        return result;
    }
}
}