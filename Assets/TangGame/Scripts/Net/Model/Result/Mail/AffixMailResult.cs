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
public class AffixMailResult : Response
{
    public const string NAME = "affixMail_RESULT";

    public int pageIndex;
    public int pageNum;
    public List<Mail> list = new List<Mail>();

    public AffixMailResult() : base(NAME)
    {
    }

    public static AffixMailResult Parse(MsgData data)
    {

        AffixMailResult result = new AffixMailResult();
        int index = 0;
        result.pageIndex = data.GetShort(index++);
        result.pageNum = data.GetShort(index++);
        while(index < data.Size)
        {
            result.list.Add(Mail.Parse(data.GetMsgData(index++)));
        }

        return result;
    }
}
}
