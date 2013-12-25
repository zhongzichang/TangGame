/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/11
 * Time: 15:01
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using TangNet;
namespace TangGame.Net
{
/// <summary>
/// 阵营领地
/// </summary>
public class Manor
{
    /** 编号 */
    public short id;
    /** 所属阵营 */
    public short camp;
    /** 占领者类型 */
    public short guardType;
    /** 占领者ID */
    public long guardId;
    /** 占领者名称 */
    public string guardName;
    /** 税率 */
    public short taxrate;
    /** 占领结果信息 */
    public string fightStr;
    /** 奖励副本状态 */
    public bool rewardState;
    /** 下一次改变状态的时间 */
    public long fightTime;
    /** 开发经验 */
    public short devExp;
    /** 开发点数 */
    public short devPoints;
    /** 是否可以领取资源 */
    public bool isGain;
    // ----------非持久化--------/
    /** 领地详细信息 */
    public ManorBase baseDetails;
    /** 开发等级信息 */
    public Develop develop;
    /** 占领加成 */
    public short fightAdd;
    /** 当前经验 */
    public short nowExp;
    /** 领地攻防状态 */
    public bool isFight;
    /** 资源列表 */
    public Storage resource;
    /** 加成后的资源列表 */
    public Storage resourceAdd;
    /** 下属领地列表 */
    public Dictionary<short, Manor> circumManor;
    /** 争夺中的排名 */
    public List<Contender> allPoints;
    public List<Contender> bossPoints;
    public List<Contender> npcPoints;
    public List<Contender> resourcePoints;
    /** 争夺时已刷新的怪物数量 */
    public int fightRoleNum;

    /** 争夺时的怪物列表 */
    public Role boss;
    public List<Role> roleList;
}
}
