/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 0:46
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 消除活动标记(场景中的所有其他英雄都收到)
/// </summary>
public class DelActivityMarkPush : Response
{
    public const string NAME = "delActivityMark_PUSH";

    public long heroId;

    public DelActivityMarkPush() : base(NAME)
    {
    }

    public static DelActivityMarkPush Parse(MsgData data)
    {

        DelActivityMarkPush push = new DelActivityMarkPush();

        push.heroId = (long) data.GetDouble(0);

        return push;

    }
}
}
