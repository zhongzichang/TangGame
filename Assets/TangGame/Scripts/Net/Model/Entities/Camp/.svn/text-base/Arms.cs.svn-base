/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/11
 * Time: 1:01
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using TangNet;
namespace TangGame.Net
{
/// <summary>
/// Description of Arms.
/// </summary>
public class Arms
{
    /** 帮会编号 */
    public long id;
    /** 帮会名字 */
    public string name;
    /** 帮主编号 */
    public long leaderId;
    /** 帮主名字 */
    public string leaderName;
    /** 帮主流派 */
    public short leaderGenre;
    /** 所属阵营 */
    public short campId;
    /** 创建时间 */
    public long createTime;
    /** 驻守领地 */
    public HashSet<short> manorSet;
    /** 帮会长福利 */
    public short welfare;
    /** 旗帜 */
    public short flag;
    /** 服装 */
    public short cloths;
    /** 公告 */
    public string describe;
    /** 帮会人数最大值 */
    public short maxPeople;
    /** 资源分配记录字符串 */
    public string allotStr;
    /** 帮会仓库字符串 */
    public string storageStr;

    /** 资源分配记录 */
    public Dictionary<short, Storage> allot;
    /** 资源仓库 */
    public Storage storage;
    /** 申请加入列表 */
    public Dictionary<long, Apply> applyMap;
    /** 成员集合 */
    public Dictionary<long, ArmsMember> memberMap;
    /** 救援名单 */
    public Dictionary<long, long> rescueList;

    /** 帮会任务列表 */
    public string starTaskStr;
    public List<long> starTask;
    /** 下次刷新帮会任务的时间 */
    public long statTaskTime;
    /** 帮会任务状态 */
    public bool starTaskState;
    /** 喂猪 */
    public FeedPig feedPig;

    public ArmsAshram armsAshram;
    /** 喂养 */
    public int pigNum;
    /** 最后开启时间 */
    public long ashramtime;


    //=============其他=============
    /// 成员人数
    public int memberSize
    {
        get;
        set;
    }

    public static Arms Parse(MsgData data)
    {
        Arms result = new Arms();
        int index = 0;
        result.id = data.GetLong(index++);
        result.name = data.GetString(index++);
        result.leaderName = data.GetString(index++);
        result.memberSize = data.GetInt(index++);
        result.maxPeople = data.GetShort(index++);

        // body.getString(position++).split(";");//领地名称

        return result;
    }
}
}
