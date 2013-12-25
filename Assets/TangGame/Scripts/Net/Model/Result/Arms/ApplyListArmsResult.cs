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
using TangNet;

namespace TangGame.Net
{
/// 家族申请列表信息
public class ApplyListArmsResult : Response
{
    public const string NAME = "applyListArms_RESULT";

    public int page = 1;
    public int pageTotal = 1;
    public List<Apply> list = new List<Apply>();


    public ApplyListArmsResult() : base(NAME)
    {
    }

    public static ApplyListArmsResult Parse(MsgData data)
    {
        ApplyListArmsResult result = new ApplyListArmsResult();

        if(data == null)
        {
            return result;
        }

        int index = 0;
        result.page = data.GetShort(index++);
        result.pageTotal = data.GetInt(index++);

        MsgData applyData = data.GetMsgData(index++);
        for(int i = 0; i < applyData.Size; i++)
        {
            result.list.Add(Apply.Parse(applyData.GetMsgData(i)));
        }

        return result;
    }
}
}
