/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/10
 * Time: 22:53
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TangGame.Net
{
/// <summary>
/// Description of HeroGameTarget.
/// </summary>
public class HeroGameTarget
{
    /** 目标ID */
    private short targetId;
    /** 目标类型 */
    private short targetType;
    /** 完成条件 */
    private int[][] completeConditionArray;
    /** 是否完成 */
    private bool isComplete;
    /** 是否已经领取奖励 */
    private bool isAcceptReward;
    private GameTarget gameTarget;
}
}
