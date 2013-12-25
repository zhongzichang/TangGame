/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 0:43
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 更新活动标记(场景中的所有其他英雄都收到)
/// </summary>
public class UpdateActivityMarkPush : Response
{

    public const string NAME = "updateActivityMark_PUSH";

    public long heroId;

    public UpdateActivityMarkPush() : base(NAME)
    {
    }

    public static UpdateActivityMarkPush Parse(MsgData data)
    {
        UpdateActivityMarkPush push = new UpdateActivityMarkPush();

        push.heroId = (long) data.GetDouble(0);

        return push;
    }
}
}
