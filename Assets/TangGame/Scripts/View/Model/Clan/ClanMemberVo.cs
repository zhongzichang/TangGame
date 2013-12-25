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
public class ClanMemberVo
{
    /// 玩家的ID
    public long id;

    /// 玩家的名称
    public string name;

    /// 玩家的等级
    public int level;

    /// 玩家阶级类型
    public int type;

    /// 玩家流派
    public int genre;

    /// 玩家职务
    public int officer;

    /// 是否在线1在线，0不在线
    public bool online;

    public void UpdateData(TGN.ArmsMember member)
    {
        this.id = member.id;
        this.name = member.name;
        this.level = member.level;
        this.genre = member.genre;
        this.officer = member.officer;
        this.online = member.isOnline;
    }

    public static ClanMemberVo FormData(TGN.ArmsMember member)
    {
        ClanMemberVo result = new ClanMemberVo();
        result.UpdateData(member);
        return result;
    }

}
}