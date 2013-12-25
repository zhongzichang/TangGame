using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class UpGradeAcupointResult : Response
{
    public const string NAME = "upGradeAcupoint_RESULT";

    public int id;
    public int type;
    public int index;
    public int breath;

    public bool isMeridian;//是否有经脉变动
    public int meridianId;
    public int meridianType;

    public UpGradeAcupointResult() : base(NAME)
    {
    }

    public static UpGradeAcupointResult Parse(MsgData data)
    {

        UpGradeAcupointResult result = new UpGradeAcupointResult();
        result.id = data.GetShort(0);
        result.type = data.GetShort(1);
        result.index = data.GetShort(2);
        result.breath = data.GetInt(3);

        MsgData tempData = data.GetMsgData(4);
        if(tempData.Size > 0)
        {
            result.isMeridian = true;
            result.meridianId = tempData.GetShort(0);
            result.meridianType = tempData.GetShort(1);
        }
        return result;
    }
}
}
