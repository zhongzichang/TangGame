/**
 * actor sprint
 *
 * Date: 2013/10/31
 * Author: zzc
 */

using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

namespace TangScene
{
  public class SprintCmd : SimpleCommand
  {
    public const string NAME = "TS_INNER_SPRINT";
    
    public override void Execute( INotification notification )
    {

      SprintBean bean = notification.Body as SprintBean;
      long sourceId = bean.sourceId;
      long targetId = bean.targetId;

      if( Cache.actors.ContainsKey( sourceId ) && Cache.actors.ContainsKey( targetId )  )
      {
        
        GameObject sourceGobj = Cache.actors[ sourceId ];
        GameObject targetGobj = Cache.actors[ targetId ];
        
        CharacterStatusBhvr statusBhvr = sourceGobj.GetComponent<CharacterStatusBhvr>();
        Directional directional = sourceGobj.GetComponent<Directional>();
        NavMeshAgent agent = sourceGobj.GetComponent<NavMeshAgent>();
        if( statusBhvr != null && agent.enabled )
        {

          // 调整好方向
          directional.Direction = VectorUtils.Direction(sourceGobj.transform.localPosition,
                                                        targetGobj.transform.localPosition);

          // 确保加上 sprint 组件
          SprintBhvr sprintBhvr = sourceGobj.GetComponent<SprintBhvr>();
          if( sprintBhvr == null )
            sprintBhvr = sourceGobj.AddComponent<SprintBhvr>();
          // 设置目标
          sprintBhvr.targetId = targetId;
          // 设置目标位置，如果需要
          if( bean.destination != Vector3.zero )
            sprintBhvr.targetPosition = bean.destination;

          // 重置路径
          agent.ResetPath();

          // 改变状态为冲刺滑行
          statusBhvr.Status = CharacterStatus.sprintGlide;

        }
      }
    }
  }
}