/**
 * Actor touch hit
 *
 * Date: 2013/10/28
 * Author: zzc
 */

using UnityEngine;
using Tang;

namespace TangScene
{
  public class ActorTouchHit : TouchHit
  {
    public long actorId;
    
    public ActorTouchHit(long actorId, TouchHit touchHit) : base(touchHit.fingerId, touchHit.point, touchHit.extraObject)
    {
      this.actorId =  actorId;
    }

    public ActorTouchHit(long actorId, int fingerId, Vector3 point, object extraObject) : base(fingerId, point, extraObject)
    {
      this.actorId = actorId;
    }

  }
}