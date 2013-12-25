/**
 * stagnant bean
 * Date: 2013/11/2
 * Author: zzc
 */


namespace TangScene
{
  public class StagnantBean
  {
    public long[] actorIds;
    public float secondTime;

    public StagnantBean(long[] actorIds, float secondTime)
    {
      this.actorIds = actorIds;
      this.secondTime = secondTime;
    }
  }

}