/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 12:04
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 答题奖励
/// </summary>
public class AnswerRewardMsgPush : Response
{

    public const string NAME = "answerRewardMsg_PUSH";

    public int heroCopper;
    public long heroExp;
    public int coin;
    public int exp;

    public AnswerRewardMsgPush() : base(NAME)
    {
    }

    public static AnswerRewardMsgPush Parse(MsgData data)
    {

        AnswerRewardMsgPush push = new AnswerRewardMsgPush();

        int index = 0;
        push.heroCopper = data.GetInt(index++);
        push.heroExp = (long)data.GetDouble(index++);
        push.coin = data.GetInt(index++);
        push.exp = data.GetInt(index++);

        return push;
    }
}
}
