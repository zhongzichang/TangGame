/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 11:38
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 开启副本宝箱面板
/// </summary>
public class OpenFbBoxPush : Response
{
    public const string NAME = "openFBBox_PUSH";

    public short fbId;

    public OpenFbBoxPush() : base(NAME)
    {
    }
    public static OpenFbBoxPush Parse(MsgData data)
    {
        OpenFbBoxPush push = new OpenFbBoxPush();

        push.fbId = data.GetShort(0);

        return push;

    }
}
}
