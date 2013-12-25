/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/8
 * Time: 14:48
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of LoginResult.
/// </summary>
[Response("login_RESULT")]
public class LoginResult : Response
{
    public const string NAME = "login_RESULT";

    public bool success = false;
    public long heroId= 0;
    public LoginResult() : base(NAME)
    {
    }
    public static LoginResult Parse(MsgData data)
    {
        LoginResult result = new LoginResult();
        if(data.Size>0)
        {
            result.success=data.GetBool(0);
            result.heroId=data.GetLong(1);
        }
        return result;
    }
}
}
