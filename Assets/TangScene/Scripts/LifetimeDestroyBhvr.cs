/**
 * lifetie destroy behaviour
 * Date: 2013/11/11
 * Author: zzc
 */
using UnityEngine;

namespace TangScene
{
  public class LifetimeDestroyBhvr : MonoBehaviour
  {
    public float lifetime = 0F;

    void Update()
    {
      lifetime -= Time.deltaTime;
      if( lifetime <= 0 )
	{
	  Destroy( gameObject );
	}
    }

  }
}