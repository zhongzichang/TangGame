using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class UpAcuFaildResult : Response
{
    public const string NAME = "upAcuFaild_RESULT";

    public int id;

    public UpAcuFaildResult() : base(NAME)
    {
    }

    public static UpAcuFaildResult Parse(MsgData data)
    {

        UpAcuFaildResult result = new UpAcuFaildResult();
        result.id = data.GetShort(0);

        return result;
    }
}
}
