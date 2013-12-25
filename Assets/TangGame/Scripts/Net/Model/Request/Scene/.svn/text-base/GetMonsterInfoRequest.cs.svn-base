/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/5/24
 * Time: 21:24
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of GetMonsterInfo.
/// </summary>
public class GetMonsterInfoRequest : Request
{
    private long id;

    public GetMonsterInfoRequest(long id)
    {
        this.id = id;
    }

    public NetData NetData
    {
        get
        {
            NetData data = new NetData(SceneProxy.S_GET_MONSTER_BY_ID);
            data.PutLong(id);
            return data;
        }
    }
}
}
