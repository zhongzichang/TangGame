/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 11:49
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 物资争夺战战况
/// </summary>
public class MaterialsRobMsgPush : Response
{
    public const string NAME = "materialsRobMsg_PUSH";

    public int killedXuanjia;
    public int killedTieyi;

    public MaterialsRobMsgPush() : base(NAME)
    {
    }

    public static MaterialsRobMsgPush Parse(MsgData data)
    {
        MaterialsRobMsgPush push = new MaterialsRobMsgPush();

        int index = 0;

        push.killedXuanjia = data.GetInt(index++);
        push.killedTieyi = data.GetInt(index++);

        return push;

    }
}
}
