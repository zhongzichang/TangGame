/*
 * Created by SharpDevelop.
 * User: Cucumber
 * Date:
 * Time:
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
/// 帮会创建返回
public class CreateArmsResult : Response
{
    public const string NAME = "createArms_RESULT";

    public long id;
    public string name;

    public CreateArmsResult() : base(NAME)
    {
    }

    public static CreateArmsResult Parse(MsgData data)
    {
        CreateArmsResult result = new CreateArmsResult();
        int index = 0;
        result.id = data.GetLong(index++);
        result.name = data.GetString(index++);
        return result;
    }
}
}
