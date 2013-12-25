using UnityEngine;
using TangNet;
namespace TangGame.Net
{
public class TeamLeaderReplaceRequest : Request
{
    private long id;

    public TeamLeaderReplaceRequest(long id)
    {
        this.id=id;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(TeamProxy.S_REPLACELEADER_TEAM);
            data.PutLong(id);
            return data;
        }
    }
}
}
