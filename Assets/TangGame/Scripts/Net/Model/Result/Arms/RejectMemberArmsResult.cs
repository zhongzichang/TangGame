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
/// 家族踢人返回
public class RejectMemberArmsResult : Response
{
    public const string NAME = "rejectMemberArms_RESULT";

    public long id;
    public string name;


    public RejectMemberArmsResult() : base(NAME)
    {
    }

    public static RejectMemberArmsResult Parse(MsgData data)
    {
        RejectMemberArmsResult result = new RejectMemberArmsResult();

        if(data == null)
        {
            return result;
        }

        result.id = data.GetLong(0);
        result.name = data.GetString(1);

        return result;
    }
}
}
