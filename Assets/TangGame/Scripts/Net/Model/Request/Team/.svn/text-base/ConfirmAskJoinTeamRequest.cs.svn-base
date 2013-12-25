using UnityEngine;
using TangNet;

namespace TangGame.Net
{
///同意或者拒绝队伍的申请,申请队伍确认
public class ConfirmAskJoinTeamRequest : Request
{
    private int type;
    private long id;
    /// <summary>
    /// 同意或者拒绝队伍的申请,申请队伍确认
    /// </summary>
    /// <param name="type">同意：1，拒绝：2</param>
    /// <param name="id">玩家ID</param>
    public ConfirmAskJoinTeamRequest(int type,long id)
    {
        this.type=type;
        this.id=id;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(TeamProxy.S_CONFIRMASKJOIN_TEAM);
            Debug.Log("ConfirmInviteTeam id=" + id);
            data.PutShort(type);
            data.PutLong(id);
            return data;
        }
    }
}
}
