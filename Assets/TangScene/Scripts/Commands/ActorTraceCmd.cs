/**
 * Actor trace
 *
 * Date: 2013/10/24
 * Author: zzc
 */

using PureMVC.Patterns;
using PureMVC.Interfaces;
using UnityEngine;

namespace TangScene
{
  public class ActorTraceCmd : SimpleCommand
  {
    
    public const string NAME = "TS_INNER_ACTOR_TRACE";

    public override void Execute(INotification notification)
    {

      TraceBean bean = notification.Body as TraceBean;

      if( bean != null )
      {

        if( Cache.actors.ContainsKey( bean.tracerId ) && Cache.actors.ContainsKey( bean.targetId ) )
        {
          
          // 如果目标角色没有被选中
          if( TS.SelectedActorId != bean.targetId ){
           // 切换被选中对象
            TS.SwitchSelectedActor(bean.targetId);
          }
          

          GameObject tracer = Cache.actors[ bean.tracerId ];
          TracerBhvr tracerBhvr = tracer.GetComponent<TracerBhvr>();
          if( tracerBhvr == null )
            tracerBhvr = tracer.AddComponent<TracerBhvr>();
          
          tracerBhvr.tracerId = bean.tracerId;
          tracerBhvr.targetId = bean.targetId;
          tracerBhvr.cacheDistance = bean.cacheDistance;
          tracerBhvr.startDistance = bean.startDistance;

          if( !tracerBhvr.enabled )
            tracerBhvr.enabled = true;

          tracerBhvr.TraceStart();

        }
      }
    }
  }
}