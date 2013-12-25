/*
 * Created by SharpDevelop.
 * User: Cucumber
 * Date:
 * Time:
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
/// 领取附件
public class ReceiveAffixResult : Response
{
    public const string NAME = "receiveAffix_RESULT";

    public long id;//邮件ID
    public int bindCoin;//绑定铜币
    public int coin;//铜币
    public int bindIngot;//绑定金锭
    public int ingot;//金锭
    //物品id
    public List<long> idlist = new List<long>();

    public ReceiveAffixResult() : base(NAME)
    {
    }

    public static ReceiveAffixResult Parse(MsgData data)
    {

        ReceiveAffixResult result = new ReceiveAffixResult();
        int index = 0;

        result.id = data.GetLong(index++);
        result.coin = data.GetInt(index++);
        result.bindIngot = data.GetInt(index++);
        result.ingot = data.GetInt(index++);

        while(index < data.Size)
        {
            result.idlist.Add(data.GetLong(index++));
        }

        return result;
    }
}
}
