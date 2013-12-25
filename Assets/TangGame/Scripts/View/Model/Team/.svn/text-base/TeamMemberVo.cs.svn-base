/*
 * 由SharpDevelop创建。
 * 用户： Sysin
 * 日期: 2013/5/6
 * 时间: 18:09
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using TGN = TangGame.Net;

namespace TangGame.View
{
public class TeamMemberVo
{
    //玩家ID
    public long id;
    //玩家名字
    public string name;
    //玩家最大生命值
    public int hpMax;
    //玩家当前生命值
    public int hp;
    //玩家最大能量值
    public int mpMax;
    //玩家当前能量值
    public int mp;
    //玩家等级
    public int level;
    //玩家当前状态1:在线 2:不在线
    public int online;

    /// 是否在线
    public bool IsOnline()
    {
        return this.online == 1;
    }

    public void Update(TGN.TeamMember teamMember)
    {
        this.id=teamMember.id;
        this.name=teamMember.name;
        this.hpMax=teamMember.hpMax;
        this.hp=teamMember.hp;
        this.mpMax=teamMember.mpMax;
        this.mp=teamMember.mp;
        this.level=teamMember.level;
        this.online=teamMember.online;
    }

    public static TeamMemberVo From(TGN.TeamMember teamMember)
    {
        TeamMemberVo result=new TeamMemberVo();
        result.Update(teamMember);
        return result;
    }




}
}