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
public class SenderMailResult : Response
{
    public const string NAME = "senderMail_RESULT";

    public bool isSuccess;
    public int coin;
    public List<long> idList = new List<long>();//物品ID
    public List<int> indexList = new List<int>();//物品index

    public SenderMailResult() : base(NAME)
    {
    }

    public static SenderMailResult Parse(MsgData data)
    {

        SenderMailResult result = new SenderMailResult();
        int index = 0;
        result.isSuccess = data.GetShort(index++) == 1;
        result.coin = data.GetInt(index++);

        if(result.isSuccess)
        {
            data.Get(index++);
            //int num = (int)temp;//不同情况
            while(index < data.Size)
            {
                result.indexList.Add(data.GetShort(index++));
                result.idList.Add(data.GetLong(index++));
            }
        }
        return result;
    }
}
}
