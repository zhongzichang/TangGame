/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/10
 * Time: 22:47
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using TangNet;
namespace TangGame.Net
{
/// <summary>
/// Description of Activity.
/// </summary>
public class Activity
{
    /** 序列号 */
    private int id;
    /** 活动名称 */
    private string name;
    /** 活动类型(-1:默认 1:群龙夺宝 2:西域征伐 3:怪攻城) */
    private int type;
    /** 活动开启方式(1:每日{时:分} 2:每周{周:时:分} 3:节日{月:日:时:分} 4:随时) */
    private int startWay;
    /** 开启时间 */
    private int[][] startTime;
    /** 活动持续时间 */
    private long timeLength;

    /** 地图ID */
    private short mapId;
    /** 1:在活动结束后关闭副本 2:固定时间关闭副本 3:按普通副本处理 */
    private int closeTypeByFb;
    /** 在副本中最大时间 */
    private long maxInFB;
    /** 在副本中死亡后是否强行退出 */
    private bool deadIsExitInFB;

    /** 活动奖励方式(true:在活动结束后奖励 false:在副本结束时奖励)，如果是目标怪将在怪死亡调用脚本中编写 */
    private bool isActivityEndReward;
    /** 奖励数量 */
    private int rewardNum;
    /** 选择次数 */
    private int selectNum;
    /** 奖励物品 */
    private MonsterGoods[] rewardArray;
    /** 特殊奖励 */
    private MonsterGoods[][] otherRewardArray;
    /** 公告ID */
    private short noticeId;

    /** 开启活动脚本 */
    private string startScript;
    /** 加入活动脚本 */
    private string joinScript;
    /** 活动结束脚本 */
    private string endScript;

    /** 活动是否开启 */
    private bool isStart;
    /** 结束时间 */
    private long endTime;
    /** 活动中玩家积分 */
    private List<Integral> integralList;
    /** 广播时间 */
    private long noticeTime;
}
}
