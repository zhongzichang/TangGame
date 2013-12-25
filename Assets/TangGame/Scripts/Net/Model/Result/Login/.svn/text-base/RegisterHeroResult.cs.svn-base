/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/19
 * Time: 14:00
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of RegisterHeroResult.
/// </summary>
[Response("registerHero_RESULT")]
public class RegisterHeroResult : Response
{

    public const string NAME = "registerHero_RESULT";

    public int type;

    public RegisterHeroResult() : base(NAME)
    {
    }

    public static RegisterHeroResult Parse(MsgData data)
    {
        RegisterHeroResult result = new RegisterHeroResult();
        result.type = data.GetInt(0);
        return result;
    }
}
}
