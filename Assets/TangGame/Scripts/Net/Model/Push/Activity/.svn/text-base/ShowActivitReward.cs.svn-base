/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 0:48
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 展示奖励物品
/// </summary>
public class ShowActivitRewardPush : Response
{

    public const string NAME = "showActivitReward_PUSH";
    public int rewardNum;
    public List<ActivitReward> rewardList;

    public ShowActivitRewardPush() : base(NAME)
    {
    }

    public static ShowActivitRewardPush Parse(MsgData data)
    {

        ShowActivitRewardPush push = new ShowActivitRewardPush();

        int index = 0;
        push.rewardNum = data.GetInt(index++);

        push.rewardList = new List<ActivitReward>();
        while(index < data.Size)
        {

            MsgData rewardData = data.GetMsgData(index++);
            ActivitReward reward  = new ActivitReward();
            int rewardIndex = 0;
            reward.goodId = rewardData.GetInt(rewardIndex++);
            reward.num = rewardData.GetInt(rewardIndex++);

            push.rewardList.Add(reward);
        }


        return push;
    }

    public class ActivitReward
    {
        public int goodId;
        public int num;
    }

}
}
