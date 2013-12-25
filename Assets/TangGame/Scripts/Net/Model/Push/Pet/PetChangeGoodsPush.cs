/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 11:54
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 宠物换装
/// </summary>
public class PetChangeGoodsPush : Response
{
    public const string NAME = "petChangeGoods_PUSH";

    public long petId;
    public long newGoodsId;
    public long oldGoodsId;
    public PetChangeGoodsPush() : base(NAME)
    {
    }
    public static PetChangeGoodsPush Parse(MsgData data)
    {
        PetChangeGoodsPush push = new PetChangeGoodsPush();
        int index = 0;
        push.petId = (long)data.GetDouble(index++);
        push.newGoodsId = (long)data.GetDouble(index++);
        push.oldGoodsId = (long)data.GetDouble(index++);
        return push;
    }
}
}
