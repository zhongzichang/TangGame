using UnityEngine;
using TangNet;

namespace TangGame.Net
{

public class TeamQuitRequest : Request
{

    public TeamQuitRequest()
    {

    }
    public NetData NetData
    {
        get
        {
            return new NetData(TeamProxy.S_QUIT_TEAM);
        }
    }
}
}
