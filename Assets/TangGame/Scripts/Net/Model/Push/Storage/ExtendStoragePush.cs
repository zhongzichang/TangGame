using System;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
public class ExtendStoragePush : Response
{

    public const string NAME = "extendStorage_PUSH";

    public int length;

    public ExtendStoragePush() : base(NAME)
    {
    }

    public static ExtendStoragePush Parse(MsgData data)
    {

        ExtendStoragePush push = new ExtendStoragePush();
        push.length = data.GetShort(0);
        return push;


    }
}
}
