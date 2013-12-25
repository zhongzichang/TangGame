/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/6
 * Time: 21:32
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TangGame.Net
{
/// <summary>
/// Description of RoleAI.
/// </summary>
public class RoleAI
{

    /** 移动AI */
    private int moveAI;
    /** 停留位置 */
    private int staySite;
    /** 是否在前进 */
    private bool isForward;

    /** 战斗AI */
    private int[] battleAI;
    /** 死亡AI */
    private int deadAI;

    /** 是否首次减血 */
    private bool isFirstReduceHP;
    /** 是否首次进入战斗 */
    private bool isFirstBattle;
    /** 是否首次被攻击 */
    private bool isFirstInjured;
    /** 是否使用了呼救 */
    private bool isCanHelp;
    /** 是否记录进入战斗时间 */
    private bool startBattleTime;
    /** AI间隔执行时间 */
    private long intervalTime;

    public RoleAI()
    {
    }
}
}
