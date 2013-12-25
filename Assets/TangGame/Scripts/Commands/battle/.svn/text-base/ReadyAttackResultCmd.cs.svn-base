/*
 * 接收到服务器传回来的 ReadyAttackResult 后进行处理
 *
 * Date: ?
 * Author: hxb
 * 
 * Date: 2013/11/14
 * Edit: zzc
 */

using UnityEngine;
using System.Collections;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TGN = TangGame.Net;
using TS = TangScene;

namespace TangGame
{
  public class ReadyAttackResultCmd : SimpleCommand
  {
    public static string NAME = TGN.ReadyAttackResult.NAME;

    public override void Execute (INotification notification)
    {
      TGN.ReadyAttackResult result = notification.Body as TGN.ReadyAttackResult;
      if( result != null && result.actorId == ActorCache.leadingActorId )
      {
        HandleByStatusCode( result );
      }
    }

    /// <summary>
    ///   根据状态码来处理
    /// </summary>
    private void HandleByStatusCode(TGN.ReadyAttackResult result)
    {

      switch( result.StatusCode )
      {
        case HandlerState.NORMAL:
          HandleNormalStatus( result );
          break;

        case HandlerState.TARGET_INVALID:
          // 20006: 目标无效
          HandleTargetInvalid( result );
          break;
          
        case HandlerState.SKILL_CD:
        case HandlerState.HP_LACK:
        case HandlerState.MP_LACK:
        case HandlerState.AN_LACK:
        case HandlerState.SKILL_INVALID:
          // 20002: 技能冷却
          // 20003: 血不足
          // 20004: 蓝不足
          // 20005: 怒气不足
          // 20007: 技能无效
          SkillsCache.currentActorSkillId = SkillsCache.leadingActorDefaultSkillId;
          BattleHelper.AutoTrace();
          break;
      }
    }

    /// <summary>
    ///   处理目标无效
    /// </summary>
    private void HandleTargetInvalid( TGN.ReadyAttackResult result )
    {
      // 去掉场景中的人物
      TS.TS.ActorExit( result.targetId );

    }


    private void HandleNormalStatus( TGN.ReadyAttackResult result )
    {
      AttackToken attackToken = BattleCache.GetAttackToken( result.actorId, result.tokenCode  );
      if( attackToken != null )
      {
        attackToken.status = AttackToken.Status.ready;

        TangNet.TN.Send( new TGN.AttackRequest (result.skillId, result.targetId, result.tokenCode ) );

        // 进入指令暂存状态
        InstructionCache.isInstructionCached = true;
      }
      
    }

  }
}