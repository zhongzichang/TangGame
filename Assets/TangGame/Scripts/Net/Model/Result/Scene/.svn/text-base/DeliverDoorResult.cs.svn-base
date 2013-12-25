/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/7
 * Time: 22:27
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of DeliverDoorResult.
/// </summary>
public class DeliverDoorResult : Response
{

    public const string NAME = "deliverDoor_RESULT";

    public short gameMapId;
    public short x;
    public short y;
    public short isRelive;

    public DeliverDoorResult() : base(NAME)
    {
    }

    public static DeliverDoorResult Parse(MsgData data)
    {


        int index = 0;
        DeliverDoorResult result = new DeliverDoorResult();
        result.gameMapId = data.GetShort(index++);
        result.x = data.GetShort(index++);
        result.y = data.GetShort(index++);
        result.isRelive = data.GetShort(index++);

        return result;


    }
}
}
