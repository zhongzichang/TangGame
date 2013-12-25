/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/22
 * Time: 2:19
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 调整自动补内
/// </summary>
public class AutoMpResult : Response
{

    public const string NAME = "autoMp";

    public short autoMp;

    public AutoMpResult() : base(NAME)
    {
    }

    public static AutoMpResult Parse(MsgData data)
    {

        AutoMpResult result = new AutoMpResult();

        result.autoMp = data.GetShort(0);

        return result;

    }
}
}
