/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/5/29
 * Time: 15:22
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of DeliverDoorPush.
/// </summary>
public class DeliverDoorPush : Response
{
    public const string NAME = "deliverDoor_PUSH";

    public long heroId;
    public short mapId;
    public short x;
    public short y;

    public DeliverDoorPush() : base(NAME)
    {
    }

    public static DeliverDoorPush Parse(MsgData data)
    {
        DeliverDoorPush push = new DeliverDoorPush();

        int index = 0;
        push.heroId = (long)data.GetDouble(index++);
        push.mapId = data.GetShort(index++);
        push.x = data.GetShort(index++);
        push.y = data.GetShort(index++);

        return push;
    }
}
}
