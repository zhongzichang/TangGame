/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/11
 * Time: 16:13
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace TangGame.Net
{
/// <summary>
/// 战场信息
/// </summary>
public class Battlefield
{
    public short mapId;
    public short cityId;
    /** 战场总时间 */
    public int totalTime;
    /** 一回合时间(0:只有一个回合) */
    public int boutTime;
    /** 1:英雄碑 2:Boss 3:资源 */
    public short mapType;
    /** 目标 */
    public int[][] targetMsgArray;
    /** 雇佣兵放置坐标 */
    public Dictionary<string, int[][]> points;

    /** 目标 */
    public Role[] targetArray;
    /** 雇佣兵集合 */
    public Dictionary<string, List<Role>> mercenaryMap;
    /** 是否开启战场 */
    public bool isStart;
    /** 阵营所属 */
    public short belongsCamp;
    /** 防御阵营 */
    public short defenderCamp;
    /** 回合次数 */
    public int boutCount = 1;
    /** 拥唐、反唐计数器 */
    public int camp1, camp2;
    /** 下次开启时间 */
    public long startNextBoutTime;
    /** 拥唐、反唐单回合积分 */
    public int camp1Score, camp2Score;
    /** 是否开启新回合 */
    public bool isStartNewBout;
    /** 战场结束时间 */
    public long endTime;
    /** 特殊奖励 */
    public MonsterGoods[][] otherRewardArray;
    /** 活动中玩家积分 */
    public List<Integral> integralList;
}
}
