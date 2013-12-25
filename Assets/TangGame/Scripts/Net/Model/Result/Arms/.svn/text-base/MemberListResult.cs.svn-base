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
/// 家族成员列表信息
public class MemberListResult : Response
{
    public const string NAME = "memberList_RESULT";

    public int page = 1;
    public int pageTotal = 1;
    public List<ArmsMember> list = new List<ArmsMember>();


    public MemberListResult() : base(NAME)
    {
    }

    public static MemberListResult Parse(MsgData data)
    {
        MemberListResult result = new MemberListResult();

        if(data == null)
        {
            return result;
        }

        int index = 0;
        result.page = data.GetShort(index++);
        result.pageTotal = data.GetShort(index++);

        MsgData memberData = data.GetMsgData(index++);
        for(int i = 0; i < memberData.Size; i++)
        {
            result.list.Add(ArmsMember.Parse(memberData.GetMsgData(i)));
        }

        return result;
    }
}
}
