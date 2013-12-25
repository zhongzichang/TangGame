/**
 * Trigger target destroy behaviour
 * Date: 2013/11/11
 * Author: zzc
 */

using UnityEngine;
using TangScene;

namespace TangEffect
{
  public class TriggerTargetDestroyBhvr : MonoBehaviour
  {

    public Collider target;

    
    void OnTriggerEnter(Collider trigger)
    {
      if( trigger == target )
	Destroy( gameObject );
    }
    
    
  }
}