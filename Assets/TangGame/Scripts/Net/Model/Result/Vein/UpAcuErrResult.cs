using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class UpAcuErrResult : Response
{
    public const string NAME = "upAcuErr_RESULT";

    public string name;
    public int level;

    public UpAcuErrResult() : base(NAME)
    {
    }

    public static UpAcuErrResult Parse(MsgData data)
    {

        UpAcuErrResult result = new UpAcuErrResult();
        result.name = data.GetString(0);//穴位名字
        result.level = data.GetShort(1);//穴位等级
        return result;
    }
}
}
