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
using TangGame.View;

namespace TangGame
{
/// 家族数据
public class ClanCache
{

    /// 家族
    public static ClanVo clan = new ClanVo();
    /// 更新标示
    public static int updated;
    /// 主玩家在家族中的职位
    public static int officer;

    /// 家族列表
    public static List<ClanVo> list = new List<ClanVo>();
    /// 列表更新标示
    public static int listUpdated;

    /// 家族申请列表
    public static List<ClanApplyVo> applyList = new List<ClanApplyVo>();
    /// 列表更新标示
    public static int applyListUpdated;

    /// 是否存在家族
    public static bool IsExistClan()
    {
        return clan.id > -1;
    }

    /// 清除家族信息
    public static void ClearClan()
    {
        clan.Clear();
        officer = 0;
        updated++;
    }

    /// 是否是家族领导人
    public static bool IsLeader()
    {
        return officer == ClanVo.OFFICE_1;
    }

    /// 是否拥有收人踢人的管理权限
    public static bool IsManager()
    {
        return officer == ClanVo.OFFICE_1 || officer == ClanVo.OFFICE_2;
    }

    /// 是否为家族成员
    public static bool IsClanMember(long id)
    {
        foreach(ClanMemberVo member in clan.members)
        {
            if(id == member.id)
            {
                return true;
            }
        }
        return false;
    }

}
}