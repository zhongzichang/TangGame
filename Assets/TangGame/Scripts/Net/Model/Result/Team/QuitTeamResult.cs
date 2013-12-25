/*
 * 由SharpDevelop创建。
 * 用户： Sysin
 * 日期: 2013/5/7
 * 时间: 17:05
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class QuitTeamResult:Response
{
    public const string NAME="quitTeam_RESULT";
    /// <summary>
    /// 退出队伍返回
    /// </summary>
    public QuitTeamResult():base(NAME)
    {

    }
    public static QuitTeamResult Parse(MsgData data)
    {
        QuitTeamResult result=new QuitTeamResult();
        return result;
    }
}
}
