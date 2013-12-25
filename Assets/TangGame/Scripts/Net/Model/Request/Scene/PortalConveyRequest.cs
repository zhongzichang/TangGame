/**
 *
 * Portal convey request
 *
 * Date: 2013/11/23
 * Author: zzc
 */

using System;
using TangNet;

namespace TangGame.Net
{
  public class PortalConveyRequest : Request
  {
    private int portalId = 0;
    public PortalConveyRequest(int portalId)
    {
        this.portalId = portalId;
    }

    public NetData NetData
    {
        get
        {
            NetData data = new NetData(SceneProxy.PORTAL_CONVEY);
            data.PutInt( portalId );
            return data;
        }
    }

  }
}