/*
 * Created by SharpDevelop.
 * User: Cucumber
 * Date:
 * Time:
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using UnityEngine;
using System.Collections.Generic;
using TGN = TangGame.Net;
namespace TangGame.View
{
/// 家族申请数据
public class ClanApplyVo
{
    /// 玩家的ID
    public long id;
    /// 玩家的名称
    public string name;
    /// 玩家的等级
    public int level;
    /// 玩家流派
    public int genre;


    public void UpdateData(TGN.Apply apply)
    {
        this.id = apply.id;
        this.name = apply.name;
        this.level = apply.level;
        this.genre = apply.genre;
    }

    public static ClanApplyVo FormData(TGN.Apply apply)
    {
        ClanApplyVo result = new ClanApplyVo();
        result.UpdateData(apply);
        return result;
    }

}
}