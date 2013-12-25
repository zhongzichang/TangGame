/**
 * Portal behaviour
 *
 * Date: 2013/11/22
 * Author: zzc
 */

using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;

namespace TangScene
{
  
  [ExecuteInEditMode]
  public class PortalBhvr : MonoBehaviour
  {

    public const float height = 0;

    public int baseId;
    public SceneGrid destination;

    // Use this for initialization
    void Start ()
    {

      Vector3 pos = transform.localPosition;
      transform.localPosition = new Vector3( pos.x, height, pos.z );

    }


    void OnTriggerEnter( Collider other )
    {

      ActorBhvr actorBhvr = other.GetComponent<ActorBhvr>();

      if( actorBhvr != null && Cache.controlledActorId == actorBhvr.id )
	{
	  Facade.Instance.SendNotification( NtftNames.PORTAL_CONVEY, baseId );
	}
      /*
      ConveyHourglass hourglass = other.GetComponent<ConveyHourglass>();
      if( hourglass == null )
	hourglass = other.gameObject.AddComponent<ConveyHourglass>();

      if( !hourglass.enabled )
	hourglass.enabled = true;
	*/

    }
      
    void OnTriggerExit( Collider other )
    {
      ConveyHourglass hourglass = other.GetComponent<ConveyHourglass>();
      if( hourglass != null )
	hourglass.enabled = false;
    }

  }
}
