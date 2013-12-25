/**
 * Created by emacss
 * Date: 2013/10/10
 * Author: zzc
 */

using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

namespace TangScene
{
  
  public class SelectedBhvr : MonoBehaviour
  {
    
    private long actorId = 0;
    
    void Awake(){
      ActorBhvr actorBhvr = GetComponent<ActorBhvr>();
      if( actorBhvr != null ){
        actorId = actorBhvr.id;
      }
    }
    
    

    void OnEnable()
    {
      Facade.Instance.SendNotification(NtftNames.ACTOR_SELECTED, actorId);
    }

    void OnDisable()
    {
      Facade.Instance.SendNotification(NtftNames.ACTOR_UNSELECTED, actorId);
    }
  }
}