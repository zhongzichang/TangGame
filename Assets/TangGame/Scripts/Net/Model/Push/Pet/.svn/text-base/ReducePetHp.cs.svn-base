/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/12
 * Time: 10:39
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of ReducePetHp.
/// </summary>
public class ReducePetHp : Response
{
    public const string NAME = "reducePetHP_PUSH";

    public long petId;
    public int hp;
    public int val;
    public ReducePetHp() : base(NAME)
    {
    }
    public static ReducePetHp Parse(MsgData data)
    {
        ReducePetHp push = new ReducePetHp();

        int index = 0;
        push.petId = (long)data.GetDouble(index++);
        push.hp  = data.GetInt(index++);
        push.val = data.GetInt(index++);

        return push;
    }
}
}
