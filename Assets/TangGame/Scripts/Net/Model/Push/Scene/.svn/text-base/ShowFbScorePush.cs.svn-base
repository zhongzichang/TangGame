/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/14
 * Time: 20:02
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 声望副本评分
/// </summary>
public class ShowFbScorePush : Response
{
    public const string NAME = "showFBScore_PUSH";

    public short mapId;
    public long useTime;
    public short score;
    public short starts;

    public ShowFbScorePush() : base(NAME)
    {
    }

    public static ShowFbScorePush Parse(MsgData data)
    {

        ShowFbScorePush push = new ShowFbScorePush();

        int index = 0;
        push.mapId = data.GetShort(index++);
        push.useTime = (long) data.GetDouble(index++);
        push.score = data.GetShort(index++);
        push.starts = data.GetShort(index++);

        return push;
    }
}
}
