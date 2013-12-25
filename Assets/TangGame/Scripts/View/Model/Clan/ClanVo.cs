/*
 * Created by SharpDevelop.
 * User: Cucumber
 * Date:
 * Time:
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TGN = TangGame.Net;
namespace TangGame.View
{
/// 家族数据
public class ClanVo
{
    /// 职位1
    public const int OFFICE_1 = 1;
    /// 职位2
    public const int OFFICE_2 = 2;
    /// 职位3
    public const int OFFICE_3 = 3;
    /// 职位4
    public const int OFFICE_4 = 4;
    /// 职位5
    public const int OFFICE_5 = 5;


    /// ID
    public long id = -1;
    /// 家族名称
    public string name;
    /// 家族领导ID
    public long leaderId;
    /// 家族领导名称
    public string leaderName;
    /// 家族领导流派
    public int leaderGenre;
    /// 家族领导等级
    public int leaderLevel;
    /// 家族领导称号
    public string leaderTitle;
    /// 家族领导所在地
    public string leaderSeat;

    /// 家族所属阵营
    public int camp;

    /// 旗帜
    public int flag;
    /// 服装图标
    public int cloths;
    /// 公告
    public string notice;
    /// 家族等级
    public int level;
    /// 家族阵营点数
    public long campCount;
//		/// 驻守领地名Id数组*/
//		public var territoryIdList:Array = [];
//		/// 驻守领地名称数组
//		public var territoryNameList:Array = [];
    /// 家族会长福利
    private int welfare;
    /// 人数
    public int num;
    /// 最大人数
    public int numMax;

    //====================仓库数据====================
    /// 家族仓库
//		public var depot:ResourcesDepot;

    /// 用于存储阶级所用的，对象是 ResourcesDepot*/
//		public var classArrMap:HashMap = new HashMap();

    /// 家族产出
//		public var out:ResourcesDepot;
    //====================成员数据====================
    /// 成员更新标示
    public int memberUpdated = 0;
    /// 成员
    public List<ClanMemberVo> members = new List<ClanMemberVo>();
    //====================主玩家在家族的数据====================
    /// 主玩家在家族职位
    public int officer;

    ///批准加入特效显示, 1:闪2：不闪, 默认无不闪**/
    public int isApplyMv = 2;


    public int cliqueManor;
    /// 行动值
    public int actionValue;
    public int ranking;
    /// 活跃度
    public int liveness;

    private int livenessDesc;

    /// 是否存在
    public bool IsExist()
    {
        return this.id > -1;
    }

    /// 清除家族信息
    public void Clear()
    {
        this.id = -1;
    }

    /// 移除家族成员
    public ClanMemberVo RemoveMember(long id)
    {
        ClanMemberVo result = null;
        foreach(ClanMemberVo member in members)
        {
            if(member.id == id)
            {
                result = member;
                members.Remove(member);
                memberUpdated++;
                num--;//人数减1
                break;
            }
        }
        return result;
    }


    /// 更新
    public void UpdateData(TGN.Arms arms)
    {
        this.id = arms.id;
        this.name = arms.name;
        this.leaderId = arms.leaderId;
        this.leaderName = arms.leaderName;
        this.num = arms.memberSize;
        this.numMax = arms.maxPeople;
    }

    /// 获得一个新的物品
    public static ClanVo FromData(TGN.Arms arms)
    {
        ClanVo clan = new ClanVo();
        clan.UpdateData(arms);
        return clan;
    }
}
}