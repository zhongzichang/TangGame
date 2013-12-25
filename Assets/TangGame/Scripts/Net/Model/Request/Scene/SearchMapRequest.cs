/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/5/24
 * Time: 19:56
 * Update ---- xbhuang - 2013/11/22
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of SearchNpcRequest.
/// </summary>
  public class SearchMapRequest : Request
  {
    private short mapId = 0;

    public SearchMapRequest (short mapId)
    {
      this.mapId = mapId;
    }

    public NetData NetData {
      get {
        NetData data = new NetData (SceneProxy.S_SEARCH_MAP);
        data.PutShort (mapId);
        return data;
      }
    }
  }
}
