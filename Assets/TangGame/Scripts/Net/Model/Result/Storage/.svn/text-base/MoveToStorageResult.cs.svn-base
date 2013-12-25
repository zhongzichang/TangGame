using System;
using System.Collections.Generic;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class MoveToStorageResult : Response
{
    public const string NAME = "moveToStorage_RESULT";

    public long id;

    public MoveToStorageResult() : base(NAME)
    {
    }

    public static MoveToStorageResult Parse(MsgData data)
    {
        MoveToStorageResult result = new MoveToStorageResult();
        result.id = data.GetLong(0);
        return result;
    }
}
}
