/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/11
 * Time: 1:06
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace TangGame.Net
{
/// <summary>
/// Description of Camp.
/// </summary>
public class Camp
{
    /** 阵营编号 */
    private short id;
    /** 阵营领袖 */
    private long leaderId;
    /** 领袖名字 */
    private string leaderName;
    /** 领袖性别 */
    private short leaderSex;
    /** 领袖等级 */
    private short leaderLevel;
    /** 领袖流派 */
    private short leaderGenre;
    /** 阵营公告 */
    private string notice;
    /** 领袖座右铭 */
    private string motto;
    /** 阵营领袖福利 */
    private short welfare;
    /** 阵营仓库字符串 */
    private string storageStr;
    /** 城市开发点数 */
    private short devPoints;
    /** 领取领袖武器 */
    private bool isWeapon;

    /** 开启投票时间 */
    private long startOpenPollTime;
    /** 开始投票 */
    private bool isOpenPoll;
    /** 投票结束时间 */
    private long pollEndTime;
    /** 是否正在操作投票系统(供线程使用) */
    private bool operationPoll;
    /** 阵营BUFF */
    private List<Buff> buffList;
    private string buffStr;
    /** 是否开启阵营BUFF */
    private bool isBuff;
    /** 是否开启阵营战 */
    private bool isFight;


    /** 阵营领地 */
    private Dictionary<short, Manor> manorMap;
    /** 阵营领袖武器 */
    private Dictionary<short, Goods> leaderWeapon;
    /** 竞选者(key:玩家编号，value:竞选者信息) */
    private Dictionary<long, Voter> voterMap;
    /** 阵营仓库 */
    private Storage storage;
    /** 阵营人数 */
    private int peopleNum;
    /** 阵营在线玩家 */
    private List<HeroNew> campHeroList;

    /** 领袖禁言次数 */
    private int shutupNum;
    /** 领袖禁言刷新时间 */
    private long shutupTime;

    /** 阵营任务列表 */
    private string starTaskStr;
    private List<long> starTask;
    /** 下次刷新阵营任务的时间 */
    private long statTaskTime;
    /** 阵营任务状态 */
    private bool starTaskState;
}
}
