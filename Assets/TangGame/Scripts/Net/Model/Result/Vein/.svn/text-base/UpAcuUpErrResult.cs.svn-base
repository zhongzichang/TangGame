using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class UpAcuUpErrResult : Response
{
    public const string NAME = "upAcuUpErr_RESULT";

    public string name;//穴位名字
    public int level;//穴位等级
    public int goodsId;//物品ID

    public UpAcuUpErrResult() : base(NAME)
    {
    }

    public static UpAcuUpErrResult Parse(MsgData data)
    {

        UpAcuUpErrResult result = new UpAcuUpErrResult();
        result.name = data.GetString(0);
        result.level = data.GetShort(1);
        result.goodsId = data.GetShort(2);
        return result;
    }
}
}
