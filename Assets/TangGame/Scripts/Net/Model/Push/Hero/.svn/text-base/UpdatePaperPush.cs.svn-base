/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 3:00
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 发送玩家礼券
/// </summary>
public class UpdatePaperPush : Response
{

    public const string NAME = "updatePaper_PUSH";

    public int bindIngot;
    public UpdatePaperPush() : base(NAME)
    {
    }
    public static UpdatePaperPush Parse(MsgData data)
    {
        UpdatePaperPush push = new UpdatePaperPush();
        push.bindIngot = data.GetInt(0);
        return push;
    }
}
}
