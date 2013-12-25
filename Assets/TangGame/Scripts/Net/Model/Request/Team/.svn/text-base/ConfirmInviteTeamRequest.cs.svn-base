using UnityEngine;
using TangNet;

namespace TangGame.Net
{
///同意或者拒绝队伍邀请
public class ConfirmInviteTeamRequest : Request
{
    private int type;
    private long id;
    /// <summary>
    /// 同意或者拒绝队伍邀请
    /// </summary>
    /// <param name="type">同意：1，拒绝：2</param>
    /// <param name="id">队伍ID</param>
    public ConfirmInviteTeamRequest(int type,long id)
    {
        this.type=type;
        this.id=id;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(TeamProxy.S_CONFIRMINVITE_TEAM);
            Debug.Log("ConfirmAskJoinTeam id=" + id);
            data.PutShort(type);
            data.PutLong(id);
            return data;
        }
    }
}
}
