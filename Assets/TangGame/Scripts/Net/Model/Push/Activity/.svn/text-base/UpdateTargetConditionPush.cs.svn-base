/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 11:27
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 更新目标状态
/// </summary>
public class UpdateTargetConditionPush : Response
{
    public const string NAME = "updateTargetCondition_PUSH";

    public short targetId;

    public short[] conditions;

    public UpdateTargetConditionPush() : base(NAME)
    {
    }

    public static UpdateTargetConditionPush Parse(MsgData data)
    {
        UpdateTargetConditionPush push = new UpdateTargetConditionPush();

        int index = 0;

        push.targetId = data.GetShort(index++);

        int conditionsLength = data.Size -1 ;
        push.conditions = new short[conditionsLength];
        for(int i=0; i<conditionsLength; i++)
        {
            push.conditions[i] = data.GetShort(index++);
        }

        return push;
    }
}
}
