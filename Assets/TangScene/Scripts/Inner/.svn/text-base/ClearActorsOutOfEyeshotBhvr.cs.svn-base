/**
 * clear actors out of eyeshot
 *
 * Date: 2013/10/30
 * Author: zzc
 */

using UnityEngine;
using System.Collections.Generic;
using PureMVC.Patterns;
using PureMVC.Interfaces;

namespace TangScene
{
  public class ClearActorsOutOfEyeshotBhvr : MonoBehaviour
  {
    
    public const float PERIOD = 5F;
    public const float HALF_WIDTH = 1200F;
    public const float HALF_HEIGHT = 528F;

    private float time = 0;

    void Update()
    {
      
      time += Time.deltaTime;
      
      if( time > PERIOD )
      {
        
        if( Cache.actors.ContainsKey( Cache.controlledActorId ) )
        {
          
          Vector3 origin = Cache.actors[ Cache.controlledActorId ].transform.localPosition;
          List<long> removeActorIds = new List<long>();
          List<long> keys = new List<long>(Cache.actors.Keys);
          foreach(long key in keys )
          {
            if( !Cache.actors.ContainsKey(key) )
              continue;
            ActorBhvr actorBhvr = Cache.actors[key].GetComponent<ActorBhvr>();
            if( actorBhvr != null && actorBhvr.actorType != ActorType.npc )
            {
              Vector3 position = actorBhvr.transform.localPosition - origin;
              if( position.x > HALF_WIDTH || position.x < -HALF_WIDTH
                 || position.z > HALF_HEIGHT || position.z < -HALF_HEIGHT ){
                TS.ActorExit( actorBhvr.id );
                removeActorIds.Add(actorBhvr.id);
              }
            }
          }
          if( removeActorIds.Count > 0 )
          {
            // 发出角色被删除的消息
            Facade.Instance.SendNotification(NtftNames.ACTORS_REMOVED, removeActorIds);
            
          }
        }
        
        time = 0;
      }
      
    }
  }
}