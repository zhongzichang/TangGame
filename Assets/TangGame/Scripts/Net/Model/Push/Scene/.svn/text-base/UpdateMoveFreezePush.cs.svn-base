/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/14
 * Time: 22:15
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 更新玩家定身状态
/// </summary>
public class UpdateMoveFreezePush : Response
{
    public const string NAME = "updateMoveFreeze_PUSH";

    public long heroId;
    public bool isAdd;

    public UpdateMoveFreezePush() : base(NAME)
    {
    }
    public static UpdateMoveFreezePush Parse(MsgData data)
    {

        UpdateMoveFreezePush push = new UpdateMoveFreezePush();

        int index = 0;
        push.heroId = (long)data.GetDouble(index++);
        push.isAdd = data.GetShort(index++) == 1 ? true : false;

        return push;

    }
}
}
