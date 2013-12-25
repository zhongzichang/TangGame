/*
 * Created by SharpDevelop.
 * User: Cucumber
 * Date:
 * Time:
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class TeamCreateRequest : Request
{
    ///创建队伍
    public TeamCreateRequest()
    {
    }

    public NetData NetData
    {
        get
        {
            NetData data = new NetData(TeamProxy.S_CREATE_TEAM);
            return data;
        }
    }
}
}
