/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/8
 * Time: 15:01
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of RegisterAccountResult.
/// </summary>
[Response("regeditAccount_RESULT")]
public class RegisterAccountResult : Response
{
    public const string NAME = "regeditAccount_RESULT";

    public bool success = false;

    public RegisterAccountResult() : base(NAME)
    {
    }

    public static RegisterAccountResult Parse(MsgData data)
    {
        RegisterAccountResult result = new RegisterAccountResult();
        result.success = data.GetShort(0) == 1 ? true : false;
        return result;
    }
}
}
