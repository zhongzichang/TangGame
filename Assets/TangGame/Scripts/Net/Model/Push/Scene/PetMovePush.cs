/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 1:11
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Pet移动
/// </summary>
public class PetMovePush : Response
{
    public const string NAME = "petMove_PUSH";

    public long petId;
    public short endx;
    public short endy;

    public PetMovePush() : base(NAME)
    {
    }

    public static PetMovePush Parse(MsgData data)
    {
        PetMovePush push = new PetMovePush();

        int index = 0;
        push.petId = (long) data.GetDouble(index++);
        push.endx = data.GetShort(index++);
        push.endy = data.GetShort(index++);

        return push;
    }
}
}
