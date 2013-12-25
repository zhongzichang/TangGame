/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/5/24
 * Time: 21:10
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of GetHeroInfoRequest.
/// </summary>
public class GetHeroInfoRequest : Request
{
    private long heroId;
    public GetHeroInfoRequest(long heroId)
    {
        this.heroId = heroId;
    }

    public NetData NetData
    {
        get
        {
            NetData data = new NetData(SceneProxy.S_GET_HERO_BY_ID);
            data.PutLong(heroId);
            return data;
        }
    }
}
}
