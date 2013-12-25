using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class DeleteTeamRequest : Request
{
    /// <summary>
    /// Ω‚…¢∂”ŒÈ«Î«Û
    /// </summary>
    public DeleteTeamRequest()
    {

    }
    public NetData NetData
    {
        get
        {
            return new NetData(TeamProxy.S_DELETE_TEAM);
        }
    }
}
}
