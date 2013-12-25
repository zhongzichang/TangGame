/**
 * battle helper
 * 战斗辅助类
 * 这里面放置的都是战斗辅助方法
 *
 * Date: 2013/11/21
 * Author: zzc
 */
using UnityEngine;
using TangUtils;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using TS = TangScene;
using TGN = TangGame.Net;
using TGX = TangGame.Xml;

namespace TangGame
{
  public class BattleHelper
  {

    /// <summary>
    ///   主角向目标人物冲刺，冲刺完成后将自动启动追踪
    /// </summary>
    public static void SprintTrace (long targetActorId)
    {
      
      long sourceActorId = TS.TS.ControlledActorId;

      // rang, start
      Vector2 distances = GetTargetDistances();

      GameObject sourceGobj = TS.TS.GetActorGameObject (sourceActorId);
      GameObject targetGobj = TS.TS.GetActorGameObject (targetActorId);

      if (targetGobj != null) {

        // 冲刺
        Vector3 sourcePosition = sourceGobj.transform.localPosition;
        Vector3 targetPosition = targetGobj.transform.localPosition;

        // 计算距离
        float distance = Vector3.Distance (sourcePosition, targetPosition);

        // 如果距离大于可攻击距离
        if (distance > distances.x) {
          Vector3 sprintPosition = Vector3.Lerp (targetPosition, sourcePosition, distances.x / distance);

          /*
          // 执行冲刺
          TS.TS.Sprint(sourceActorId, sprintPosition );
          // 发送冲刺指令
          Point point = GridUtil.Vector3ToPoint (sprintPosition);
          TangNet.TN.Send (new TGN.SprintRequest ((short)point.x, (short)point.y));
           */
          
          // NavMesh 取样
          NavMeshHit closestHit;
          if (NavMesh.SamplePosition (sprintPosition, out closestHit, 100, 1)) {
            
            // 执行冲刺
            TS.TS.Sprint(sourceActorId, closestHit.position, Config.SPRINT_SPEED );
            // 发送冲刺指令
            Point point = GridUtil.Vector3ToPoint (closestHit.position);
            TangNet.TN.Send (new TGN.SprintRequest ((short)point.x, (short)point.y));

          }
        }
      }
    }

    /// <summary>
    /// 主角追踪指定的目标
    /// </summary>
    /// <param name="targetActorId">要追踪的目标</param>
    public static void Trace (long targetActorId)
    {
      Trace( TS.TS.ControlledActorId, targetActorId );

    }
    
    
    /// <summary>
    /// 追踪指定的目标
    /// </summary>
    /// <param name="sourcetActorId">source actor ID.</param>
    /// <param name="targetActorId">Target actor ID.</param>
    public static void Trace (long sourceActorId, long targetActorId)
    {
      
      if ( TS.TS.Exist(sourceActorId ) && TS.TS.Exist(targetActorId ) ) {
        
        // 如果进行追踪的是主角
        if( ActorCache.leadingActorId == sourceActorId && ActorCache.targetActorId != targetActorId )
          ActorCache.targetActorId = targetActorId;
        
        Vector2 distances = GetTargetDistances();
        TS.TS.ActorTrace (sourceActorId, targetActorId, distances.x, distances.y);
        
      }
    }
    
    /// <summary>
    /// 主角进行自动追踪
    /// </summary>
    public static void AutoTrace(){
      
      // 获取正在追踪的角色ID
      long targetId = TS.TS.GetTraceActorId(ActorCache.leadingActorId);
      
      // 如果目标角色不存在
      if( !TS.TS.Exist(targetId) ) {
        // 获取新的目标
        targetId = TS.TS.GetClosestActorId( ActorCache.leadingActorId, TS.ActorType.monster, true);
        if( TS.TS.Exist(targetId) ){
          ActorCache.targetActorId = targetId;
          Trace(targetId);
        }
      }
      
    }
    
    /// <summary>
    /// 进行自动追踪
    /// </summary>
    /// <param name="sourceId">要进行追踪的角色ID.</param>
    public static void AutoTrace(long sourceId){
      
      // 获取正在追踪的角色ID
      long targetId = TS.TS.GetTraceActorId(sourceId);
      
      // 如果目标角色不存在
      if( !TS.TS.Exist(targetId) ) {
        // 获取新的目标
        targetId = TS.TS.GetClosestActorId( sourceId, TS.ActorType.monster, true);
        if( TS.TS.Exist(targetId) ){
          Trace(sourceId, targetId);
        }
      }
      
    }

    
    /// <summary>
    /// 追踪时需要保持的距离
    /// </summary>
    /// <returns></returns>
    public static Vector2 GetTargetDistances(){
      
      
      float realRange = Config.defaultTraceDistance.x;
      float realStart = Config.defaultTraceDistance.y;

      // 根据技能确定与目标角色保持的距离
      TGX.SkillData skill = SkillsCache.GetLeadingActorCurrentSkill ();
      if (skill != null) {
        realRange = skill.Range * GridUtil.WIDTH;
        realStart = realRange * 2;

      }
      
      return new Vector2(realRange, realStart);
    }
    
    /// <summary>
    /// 主角自动挂机
    /// </summary>
    public static void Hook(){
      
      BattleCache.onHook = true;
      
      GameObject actorGobj = TS.TS.GetActorGameObject(ActorCache.leadingActorId);
      if( actorGobj != null ){
        
        HookBhvr hookBhvr = actorGobj.GetComponent<HookBhvr>();
        
        if( hookBhvr == null )
          hookBhvr = actorGobj.AddComponent<HookBhvr>();
        else if( !hookBhvr.enabled )
          hookBhvr.enabled = true;
        
      }
      
    }
    
    /// <summary>
    /// 主角取消自动挂机
    /// </summary>
    public static void Unhook(){
      BattleCache.onHook = false;
      
      GameObject actorGobj = TS.TS.GetActorGameObject(ActorCache.leadingActorId);
      if( actorGobj != null ){
        
        HookBhvr hookBhvr = actorGobj.GetComponent<HookBhvr>();
        
        if( hookBhvr != null && hookBhvr.enabled )
          hookBhvr.enabled = false;
        
      }
    }
  }
}