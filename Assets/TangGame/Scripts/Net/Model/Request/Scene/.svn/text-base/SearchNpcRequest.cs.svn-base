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
/// </summary>0
  public class SearchNpcRequest : Request
  {
    private int npcId = 0;

    public SearchNpcRequest (int npcId)
    {
      this.npcId = npcId;
    }

    public NetData NetData {
      get {
        NetData data = new NetData (SceneProxy.S_SEARCH_NPC);
        data.PutInt (npcId);
        return data;
      }
    }
  }
}
