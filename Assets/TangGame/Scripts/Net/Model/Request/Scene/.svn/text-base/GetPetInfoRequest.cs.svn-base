/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/5/24
 * Time: 21:29
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of GetPetInfoRequest.
/// </summary>
public class GetPetInfoRequest : Request
{
    private long petId = 0L;
    public GetPetInfoRequest(long petId)
    {
        this.petId = petId;
    }

    public NetData NetData
    {
        get
        {
            NetData data = new NetData(SceneProxy.S_GET_PET_BY_ID);
            data.PutLong(petId);
            return data;
        }
    }
}
}
