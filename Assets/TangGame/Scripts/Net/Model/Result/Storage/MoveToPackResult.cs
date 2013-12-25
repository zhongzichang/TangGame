using System;
using System.Collections.Generic;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class MoveToPackResult : Response
{
    public const string NAME = "moveToPack_RESULT";

    public int index;
    public long id;

    public MoveToPackResult() : base(NAME)
    {
    }

    public static MoveToPackResult Parse(MsgData data)
    {
        MoveToPackResult result = new MoveToPackResult();
        result.index = data.GetShort(0);
        result.id = data.GetLong(1);
        return result;
    }
}
}
