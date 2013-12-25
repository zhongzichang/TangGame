/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 10:40
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of FbEndTimePush.
/// </summary>
public class FbEndTimePush : Response
{
    public const string NAME = "fbEndTime_PUSH";

    public long endTime;

    public FbEndTimePush() : base(NAME)
    {
    }

    public static FbEndTimePush Parse(MsgData data)
    {
        FbEndTimePush push = new FbEndTimePush();

        push.endTime = (long)data.GetDouble(0);

        return push;
    }
}
}
