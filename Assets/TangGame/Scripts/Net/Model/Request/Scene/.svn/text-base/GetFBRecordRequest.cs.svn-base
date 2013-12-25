/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/5/24
 * Time: 21:02
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of GetFBRecordRequest.
/// </summary>
public class GetFBRecordRequest : Request
{
    private short mapId = 0;

    public GetFBRecordRequest(short mapId)
    {
        this.mapId = mapId;
    }

    public NetData NetData
    {
        get
        {
            NetData data = new NetData(SceneProxy.S_SHOW_FB_RECORD);
            data.PutShort(mapId);
            return data;
        }
    }
}
}
