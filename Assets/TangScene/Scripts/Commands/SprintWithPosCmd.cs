/**
 * sprint with position
 *
 * Date: 2013/10/31
 * Author: zzc
 */

using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

namespace TangScene
{
  public class SprintWithPosCmd : SimpleCommand
  {
    public const string NAME = "TS_INNER_SPRINT_WITH_POS";
    
    public override void Execute( INotification notification )
    {

      SprintWithPosBean bean = notification.Body as SprintWithPosBean;
      long sourceId = bean.sourceId;
      Vector3 targetPosition = bean.targetPosition;

      if( Cache.actors.ContainsKey( sourceId ) )
      {
        
        GameObject sourceGobj = Cache.actors[ sourceId ];
        
        CharacterStatusBhvr statusBhvr = sourceGobj.GetComponent<CharacterStatusBhvr>();
        Directional directional = sourceGobj.GetComponent<Directional>();
        NavMeshAgent agent = sourceGobj.GetComponent<NavMeshAgent>();

        if( statusBhvr != null && agent.enabled )
        {

          // 调整好方向
          directional.Direction = VectorUtils.Direction(sourceGobj.transform.localPosition,
                                                        targetPosition);

          // 确保加上 sprint 组件
          SprintWithPosBhvr sprintWithPosBhvr = sourceGobj.GetComponent<SprintWithPosBhvr>();
          if( sprintWithPosBhvr == null )
            sprintWithPosBhvr = sourceGobj.AddComponent<SprintWithPosBhvr>();

          // 设置目标位置，如果需要
          sprintWithPosBhvr.targetPosition = targetPosition;
          sprintWithPosBhvr.speed = bean.speed;

          // 重置路径
          agent.ResetPath();

          // 改变状态为冲刺滑行
          statusBhvr.Status = CharacterStatus.sprintGlide;

        }
      }

    }
  }
}