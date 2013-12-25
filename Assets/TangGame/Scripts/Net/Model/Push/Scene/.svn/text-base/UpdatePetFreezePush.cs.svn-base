/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/14
 * Time: 23:20
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 更新宠物定身状态
/// </summary>
public class UpdatePetFreezePush : Response
{

    public const string NAME = "updatePetFreeze_PUSH";

    public long petId;
    public bool isAdd;
    public UpdatePetFreezePush() : base(NAME)
    {
    }
    public static UpdatePetFreezePush Parse(MsgData data)
    {
        UpdatePetFreezePush push = new UpdatePetFreezePush();

        int index = 0;
        push.petId = (long) data.GetDouble(index++);
        push.isAdd = data.GetShort(index++) == 1 ? true : false;

        return push;

    }
}
}
