using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class TeamKickRequest : Request
{
    private long id;

    public TeamKickRequest(long id)
    {
        this.id=id;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(TeamProxy.S_REJECT_TEAM);
            data.PutLong(id);
            return data;
        }
    }
}
}
