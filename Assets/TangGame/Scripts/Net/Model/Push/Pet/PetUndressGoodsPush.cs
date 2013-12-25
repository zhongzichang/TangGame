/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 11:57
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 宠物脱下装备
/// </summary>
public class PetUndressGoodsPush : Response
{
    public const string NAME = "petUndressGoods_PUSH";

    public long petId;
    public long goodsId;
    public PetUndressGoodsPush() : base(NAME)
    {
    }
    public static PetUndressGoodsPush Parse(MsgData data)
    {
        PetUndressGoodsPush push = new PetUndressGoodsPush();
        int index = 0;
        push.petId = (long) data.GetDouble(index++);
        push.goodsId = (long) data.GetDouble(index++);
        return push;

    }
}
}
