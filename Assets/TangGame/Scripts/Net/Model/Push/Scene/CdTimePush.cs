/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/14
 * Time: 19:14
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of CdTimePush.
/// </summary>
public class CdTimePush : Response
{

    public const string NAME = "CDTime_PUSH";

    public int val;

    public CdTimePush() : base(NAME)
    {
    }

    public static CdTimePush Parse(MsgData data)
    {
        CdTimePush push = new CdTimePush();
        push.val = data.GetInt(0);
        return push;
    }
}
}
