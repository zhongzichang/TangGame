/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/12
 * Time: 2:28
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of AddPetHmPush.
/// </summary>
public class AddPetHmPush : Response
{
    public const string NAME = "addPetHM_PUSH";

    public long petId;
    public int hp;
    public int mp;
    public int hpVal;
    public int mpVal;
    public AddPetHmPush() : base(NAME)
    {
    }
    public static AddPetHmPush Parse(MsgData data)
    {
        AddPetHmPush push = new AddPetHmPush();

        int index = 0;
        push.petId = (long) data.GetDouble(index++);
        push.hp  = data.GetInt(index++);
        push.mp = data.GetInt(index++);
        push.hpVal = data.GetInt(index++);
        push.mpVal = data.GetInt(index++);

        return push;
    }
}
}
