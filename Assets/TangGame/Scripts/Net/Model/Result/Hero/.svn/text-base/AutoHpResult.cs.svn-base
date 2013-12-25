/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/21
 * Time: 17:58
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of AutoHpResult.
/// </summary>
public class AutoHpResult : Response
{
    public const string NAME = "autoHp_RESULT";

    public short autoHp;

    public AutoHpResult() : base(NAME)
    {
    }

    public static AutoHpResult Parse(MsgData data)
    {

        AutoHpResult result = new AutoHpResult();

        result.autoHp = data.GetShort(0);

        return result;

    }
}
}
