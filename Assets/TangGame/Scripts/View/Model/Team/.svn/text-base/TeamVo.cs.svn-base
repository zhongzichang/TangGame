/*
 * 由SharpDevelop创建。
 * 用户： Sysin
 * 日期: 2013/5/6
 * 时间: 17:43
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System.Collections.Generic;

namespace TangGame.View
{
public class TeamVo
{
    //队长ID
    public long leaderId = -1L;
    //团队ID
    public long id = -1L;
    /// 是否自动组队
    public bool isAutoTeam;
    /// 更新标示
    public int updated = 0;
    /// 团队成员
    public List<TeamMemberVo> list = new List<TeamMemberVo>();
    /// 成员更新标示
    public int memberUpdated = 0;

    /// 更新队长ID
    public void UpdateLeader(long id)
    {
        leaderId = id;
    }

    /// 获得成员
    public TeamMemberVo GetMember(long id)
    {
        foreach(TeamMemberVo memberVo in list)
        {
            if(memberVo.id == id)
            {
                return memberVo;
            }
        }
        return null;
    }

    /// 添加成员
    public void Add(TeamMemberVo member)
    {
        this.list.Add(member);
        this.memberUpdated++;
    }

    /// 删除成员
    public TeamMemberVo Remove(long id)
    {
        TeamMemberVo result = null;
        for(int i = 0; i < this.list.Count; i++)
        {
            if(this.list[i].id == id)
            {
                result = this.list[i];
                this.list.RemoveAt(i);
                this.updated++;
                this.memberUpdated++;
                break;
            }
        }
        return result;
    }

    /// 队伍是否存在
    public bool isExist()
    {
        return this.leaderId > -1L;
    }

    /// 队伍解散
    public void Dissolve()
    {
        this.leaderId = -1L;
        this.id = -1L;
        this.list.Clear();
        this.updated++;
        this.memberUpdated++;
    }

}
}