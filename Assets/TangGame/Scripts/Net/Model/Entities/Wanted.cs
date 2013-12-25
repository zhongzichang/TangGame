/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/11
 * Time: 18:38
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of Wanted.
/// </summary>
public class Wanted
{
    /** 编号 */
    public long id;
    /** 名称 */
    public string name;
    /** 类型 */
    public short type;
    /** 信息 */
    public string msg;
    /** 状态 */
    public short state;
    /** 发布人编号 */
    public long heroId;
    /** 发布人姓名 */
    public string heroName;
    /** 发布时间 */
    public long time;
    /** 接受任务NPC */
    public int acceptNpc;
    /** 完成任务Npc */
    public int returnNpc;
    /** 任务描述 */
    public string node;
    /** 任务条件 */
    public string conditionStr;
    public List<Item> condition;
    /** 奖励 */
    public string rewardStr;
    public List<Item> reward;
    /** 被通缉者ID */
    public long wantedHeroId;
    /** 被通缉人名称 */
    public string wantedHeroName;
    /** 接取悬赏的人 */
    public string reciverIdStr;
    public HashSet<long> reciverIdSet;
}
}
