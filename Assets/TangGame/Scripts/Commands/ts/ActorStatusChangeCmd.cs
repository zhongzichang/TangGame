///xbhuang
///小伙伴们，来点乐子吧！
using UnityEngine;
using System.Collections;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TS = TangScene;
using TGN = TangGame.Net;
using TGV = TangGame.View;
using TGX = TangGame.Xml;

namespace TangGame
{

  /// <summary>
  /// 当前控制角色某状态动画播放结束
  /// </summary>
  public class ActorStatusChangeCmd : SimpleCommand
  {

    public static string NAME = TS.NtftNames.ACTOR_STATUS_CHANGED;

    /// <summary>
    /// 当前英雄的ID
    /// </summary>
    private long actorId;
    /// <summary>
    /// 当前英雄的自动追踪范围
    /// </summary>
    private Vector3 traceDis;
    /// <summary>
    /// 当前角色的对象
    /// </summary>
    private GameObject actorObj;

    public override void Execute (INotification notification)
    {

      TS.CharacterStatusChangedBean bean = notification.Body as TS.CharacterStatusChangedBean;
      traceDis = Config.defaultTraceDistance;
      TS.CharacterStatus statusBefore = bean.before;
      TS.CharacterStatus statusAfter = bean.after;
      actorId = bean.actorId;
      actorObj = TS.TS.GetActorGameObject(actorId);

      // 某状态结束则驱动，
      switch (statusBefore)
      {

          // 如果是攻击状态结束
        case TS.CharacterStatus.attack:
          // 主角的攻击状态结束
          if(actorId == ActorCache.leadingActorId)
            LeadingActorAttackStatusEnd();
          break;

          // 冲刺动作状态结束
        case TS.CharacterStatus.sprintGlide:
          EffectManager.Instance.EnableFastMove(actorObj,false);
          break;
          
          // 刹车结束
        case TS.CharacterStatus.sprintBrake:
          if( actorId == ActorCache.leadingActorId ){
            
            Vector2 distances = BattleHelper.GetTargetDistances();
            // 追踪
            TS.TS.ActorTrace (ActorCache.leadingActorId, ActorCache.targetActorId,
                              distances.x, distances.y);

          }
          break;

          // 如果是跑动
        case TS.CharacterStatus.run:
          // 如果目标是个位置
          if( AutoNavCache.isActive && actorId == ActorCache.leadingActorId && AutoNavCache.portalQueue.Count == 0 ){
            if( AutoNavCache.Mode.searchScene == AutoNavCache.mode && AutoNavCache.targetPosition != Vector3.zero ){
              GameObject leadingGobj = TS.TS.GetActorGameObject(actorId);
              if( leadingGobj != null ){
                if ( Vector3.Distance(leadingGobj.transform.localPosition, AutoNavCache.targetPosition ) < 10F ){
                  // 中止自动寻路
                  AutoNavHelper.Terminate();
                  // 开启自动挂机
                  SendNotification(NtftNames.TG_HOOK);
                }
              }
              
            }
          }
          break;
          
      }

      switch( statusAfter )
      {
        case TS.CharacterStatus.sprintGlide:
          // 开始冲刺，显示残影
          EffectManager.Instance.EnableFastMove(actorObj,true);
          break;
          
      }
    }

    /// <summary>
    ///  主角攻击状态结束调用的方法
    /// </summary>
    private void LeadingActorAttackStatusEnd()
    {

      if (InstructionCache.isInstructionCached)
      {
        InstructionCache.isInstructionCached = false;
        if (InstructionCache.instructionQueue.Count > 0)
        {
          SendNotification (RunLastInstructionTemporaryCmd.NAME);
        }
        else if( ActorCache.GetLeadingHero().hp > 0 )
        {
          
          if( TS.TS.GetActorGameObject( TS.TS.SelectedActorId ) != null)
          {
            // 获取目标角色的血
            TGN.ActorNo actor = ActorCache.actors[ ActorCache.targetActorId ];
            int hp = 0;
            if( actor is TGN.Monster )
            {
              hp = ((TGN.Monster) actor).hp;
            }
            else if( actor is TGN.HeroNew )
            {
              hp = ((TGN.HeroNew) actor).hp;
            }

            // 如果目标对象的角色死亡
            if( hp <= 0 )
            {
              TS.TS.CancelTrace (ActorCache.leadingActorId);
            }
            else
            {
              BattleHelper.Trace(ActorCache.leadingActorId, ActorCache.targetActorId);
            }
            
          }

        }
      }
    }
  }
}