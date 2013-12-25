/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 11:36
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;


namespace TangGame.Net
{
/// <summary>
/// 竞技结果
/// </summary>
public class SportsResultPush : Response
{
    public const string NAME = "sportsResult_PUSH";

    public short result; // 1:获胜 2:失败 3:平局
    public SportsResultPush() : base(NAME)
    {
    }
    public static SportsResultPush Parse(MsgData data)
    {

        SportsResultPush push = new SportsResultPush();

        push.result = data.GetShort(0);

        return push;


    }
}
}
