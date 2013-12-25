/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 10:55
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 探索提示
/// </summary>
public class TipInExplorePush : Response
{
    public const string NAME = "tipInExplore_PUSH";

    public string text;

    public TipInExplorePush() : base(NAME)
    {
    }
    public static TipInExplorePush Parse(MsgData data)
    {
        TipInExplorePush push = new TipInExplorePush();

        push.text = data.GetString(0);

        return push;
    }
}
}
