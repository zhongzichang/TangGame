using UnityEngine;
using TangNet;

namespace TangGame.Net
{
///邀请玩家加入队伍
public class TeamInviteRequest : Request
{
    private long id;
    /// <summary>
    /// 邀请玩家加入队伍
    /// </summary>
    /// <param name="id">被邀请人的ID</param>
    public TeamInviteRequest(long id)
    {
        this.id = id;
    }

    public NetData NetData
    {
        get
        {
            NetData data = new NetData(TeamProxy.S_INVITE_TEAM);
            data.PutLong(id);
            return data;
        }
    }
}
}
