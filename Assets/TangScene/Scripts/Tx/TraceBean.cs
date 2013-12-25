/**
 * Trace bean
 *
 * Date: 2013/10/24
 * Author: zzc
 */

namespace TangScene
{
  public class TraceBean
  {

    public const float DEFAULT_CACHE_DISTANCE = 50F;
    public const float DEFAULT_START_DISTANCE = 200F;

    public long tracerId;
    public long targetId;
    public float cacheDistance;
    public float startDistance;

    public TraceBean(long tracerId, long targetId)
    {
      this.tracerId = tracerId;
      this.targetId = targetId;
      this.cacheDistance = DEFAULT_CACHE_DISTANCE;
      this.startDistance = DEFAULT_START_DISTANCE;
    }

    public TraceBean(long tracerId, long targetId, float cacheDistance, float startDistance)
    {
      this.tracerId = tracerId;
      this.targetId = targetId;
      this.cacheDistance = cacheDistance;
      this.startDistance = startDistance;
      
    }

  }
}