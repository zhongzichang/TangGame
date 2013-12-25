/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/11
 * Time: 14:28
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace TangGame.Net
{
/// <summary>
/// Description of FeedPig.
/// </summary>
public class FeedPig
{
    /** 饱食度 */
    public int repletion;
    /** 成员最后喂食时间 */
    public Dictionary<long, long> feedMemberMap;
    /** 开起状态 */
    public bool state;
    /** BOSS等级 */
    public short bossId;
    /** 进入副本玩家ID */
    public HashSet<long> joinHeroIdSet;
    public int rewardId;

    public HashSet<long> rewardSet;

}
}
