/*
 * 由SharpDevelop创建。
 * 用户： Sysin
 * 日期: 2013/4/27
 * 时间: 10:16
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class MiaCompleteResult:Response
{
    public const string NAME="miaComplete_RESULT";
    public short success;

    public MiaCompleteResult():base(NAME)
    {

    }

    public static MiaCompleteResult Parse(MsgData data)
    {
        MiaCompleteResult miaComplete=new MiaCompleteResult();
        miaComplete.success=data.GetShort(0);
        return miaComplete;
    }
}
}
