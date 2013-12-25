/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/14
 * Time: 19:23
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 更新装备持久
/// </summary>
public class UpdateDurablePush : Response
{

    public const string NAME = "updateDurable_PUSH";
    public int heroCopper;
    public List<GoodsDurable> durableList;

    public UpdateDurablePush() : base(NAME)
    {
    }
    public static UpdateDurablePush Parse(MsgData data)
    {
        UpdateDurablePush push = new UpdateDurablePush();
        int index = 0;
        push.heroCopper = data.GetInt(index++);
        push.durableList = new List<GoodsDurable>();
        while(index < data.Size)
        {

            MsgData durableData = data.GetMsgData(index++);

            GoodsDurable durable = new GoodsDurable();
            int durableIndex = 0;
            durable.goodId = (long)durableData.GetDouble(durableIndex++);
            durable.val = durableData.GetShort(durableIndex++);

            push.durableList.Add(durable);

        }

        return push;


    }
}

public class GoodsDurable
{

    public long goodId;
    public short val;

}
}
