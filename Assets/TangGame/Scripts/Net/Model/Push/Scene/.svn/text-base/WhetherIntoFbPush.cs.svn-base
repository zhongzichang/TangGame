/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/14
 * Time: 18:27
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 发送邀请进入FB信息
/// </summary>
public class WhetherIntoFbPush : Response
{
    public const string NAME = "whetherIntoFB_PUSH";

    public short mapId; // 副本地图ID
    public string heroName; // 邀请人的名字
    public string mapName; // 副本地图炮名字

    public WhetherIntoFbPush() : base(NAME)
    {
    }
    public static WhetherIntoFbPush Parse(MsgData data)
    {
        WhetherIntoFbPush push = new WhetherIntoFbPush();
        int index = 0;
        push.mapId = data.GetShort(index++);
        push.heroName = data.GetString(index++);
        push.mapName = data.GetString(index++);
        return push;
    }
}
}
