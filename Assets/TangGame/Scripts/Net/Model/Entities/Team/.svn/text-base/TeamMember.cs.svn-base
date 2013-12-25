/*
 * 由SharpDevelop创建。
 * 用户： Sysin
 * 日期: 2013/5/6
 * 时间: 18:09
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using UnityEngine;
using TangNet;
namespace TangGame.Net
{
public class TeamMember
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
    //玩家当前状态//1:在线 2:不在线
    public int online;

    public static TeamMember Parse(MsgData data)
    {
        TeamMember teamMember=new TeamMember();
        int index=0;
        teamMember.id=(long)data.GetDouble(index++);
        teamMember.name=data.GetString(index++);
        teamMember.hpMax=data.GetInt(index++);
        teamMember.hp=data.GetInt(index++);
        teamMember.mpMax=data.GetInt(index++);
        teamMember.mp=data.GetInt(index++);
        teamMember.level=data.GetShort(index++);
        teamMember.online=data.GetShort(index++);
        return teamMember;
    }


}
}