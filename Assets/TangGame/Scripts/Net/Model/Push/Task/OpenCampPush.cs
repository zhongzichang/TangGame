/*
 * 由SharpDevelop创建。
 * 用户： Sysin
 * 日期: 2013/4/27
 * 时间: 11:36
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */

using System;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
public class OpenCampPush :Response
{
    public const string NAME="openCamp_PUSH";

    public OpenCampPush():base(NAME)
    {

    }

    public static OpenCampPush Parse(MsgData data)
    {
        return null;
    }
}
}