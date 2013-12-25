/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/12
 * Time: 11:00
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of UpdatePetExp_PUSH.
/// </summary>
public class UpdatePetExpPush : Response
{

    public const string NAME = "updatePetExp_PUSH";

    public long petId;
    public long exp;
    public UpdatePetExpPush() : base(NAME)
    {
    }
    public static UpdatePetExpPush Parse(MsgData data )
    {
        UpdatePetExpPush push = new UpdatePetExpPush();
        int index = 0;
        push.petId = (long)data.GetDouble(index++);
        push.exp = (long)data.GetDouble(index++);
        return push;
    }
}
}
