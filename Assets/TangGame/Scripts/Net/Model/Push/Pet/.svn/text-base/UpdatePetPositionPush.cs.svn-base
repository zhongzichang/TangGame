/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 1:13
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 更新宠物坐标
/// </summary>
public class UpdatePetPositionPush : Response
{
    public const string NAME = "updatePetPosition_PUSH";

    public long petId;
    public short endx;
    public short endy;
    public UpdatePetPositionPush() : base(NAME)
    {
    }
    public static UpdatePetPositionPush Parse(MsgData data)
    {
        UpdatePetPositionPush push = new UpdatePetPositionPush();

        int index = 0;
        push.petId = (long) data.GetDouble(index++);
        push.endx = data.GetShort(index++);
        push.endy = data.GetShort(index++);

        return push;
    }
}
}
