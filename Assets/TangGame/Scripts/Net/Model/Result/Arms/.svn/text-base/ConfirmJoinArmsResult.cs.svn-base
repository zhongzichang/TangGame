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
public class ConfirmJoinArmsResult : Response
{
    public const string NAME = "confirmJoinArms_RESULT";

    public long id;

    public ConfirmJoinArmsResult() : base(NAME)
    {
    }

    public static ConfirmJoinArmsResult Parse(MsgData data)
    {
        ConfirmJoinArmsResult result = new ConfirmJoinArmsResult();

        if(data == null)
        {
            return result;
        }

        result.id = data.GetLong(0);

        return result;
    }
}
}
