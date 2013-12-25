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
public class GeneralMailResult : Response
{
    public const string NAME = "generalMail_RESULT";

    public int pageIndex;
    public int pageNum;
    public List<Mail> list = new List<Mail>();

    public GeneralMailResult() : base(NAME)
    {
    }

    public static GeneralMailResult Parse(MsgData data)
    {

        GeneralMailResult result = new GeneralMailResult();
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
