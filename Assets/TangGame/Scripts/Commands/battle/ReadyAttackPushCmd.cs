/**
 * 处理服务器的 ReadyAttackPush
 *
 * Date: 2013/11/14
 * Author: zzc
 */
using System;
using UnityEngine;
using System.Collections;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TGN = TangGame.Net;
using TS = TangScene;
using TGV = TangGame.View;
using TGX = TangGame.Xml;
using TangEffect;

namespace TangGame
{
  public class ReadyAttackPushCmd : SimpleCommand
  {
    public static string NAME = TGN.ReadyAttackPush.NAME;

    public override void Execute (INotification notification)
    {
      TGN.ReadyAttackPush push = notification.Body as TGN.ReadyAttackPush;
      if( push != null )
	{
	  HandlePush( push );
	  
	}
    }


    /// <summary>
    ///   处理正常状态
    /// </summary>
    private void HandlePush(TGN.ReadyAttackPush push)
    {

      if( Config.skillTable.ContainsKey( push.skillId ) )
	{

	  // 如果是主角发起的攻击
	  if( push.actorId == ActorCache.leadingActorId )
	    {
	      HandleLeadingActor( push );
	    }

	  // 如果是其他角色（英雄／怪物）发起的攻击
	  else
	    {
	      HandleOtherHeros( push );
	    }


	  // 播放攻击动作
	  TS.TS.Attack ( new TS.SingleAttackBean (push.actorId, push.skillId, push.targetId) );


	  // 使用技能特效
	  TGX.SkillData skill = Config.skillTable[ push.skillId ];
	  int assetId = skill.Effect_shot;
	  int assetSetId = assetId;
	      
	  if( skill.Shotplay_type == Config.CLOSE_ATTACK &&  assetId != 0 )
	    {
		  
	      // 显示近身攻击特效
	      //TE.ActionBinding( TS.TS.ControlledActorId, TS.CharacterStatus.attack,
	      //assetSetId, assetId);
	      TE.Binding( push.actorId, assetSetId, assetSetId  );
		  
	    }
	}

    }


    /// <summary>
    ///   主角处理
    /// </summary>
    private void HandleLeadingActor(TGN.ReadyAttackPush push)
    {

      GameObject actorGobj = TS.TS.GetActorGameObject(push.actorId);
      if( actorGobj != null )
	{
	  // 走动状态下不能攻击
	  TS.CharacterStatusBhvr csb = actorGobj.GetComponent<TS.CharacterStatusBhvr>();
	  if( csb.Status != TS.CharacterStatus.run )
	    {
	      //xbhuang 2013/11/24 抛出一条技能使用的消息
	      SendNotification(NtftNames.TG_SKILL_USEED,push.skillId);
	      // 获取攻击令牌
	      AttackToken attackToken = BattleCache.GetAttackToken( push.actorId, push.tokenCode  );
	      if( attackToken != null )
		{
		  // 有攻击令牌
		      
		  // 修改状态
		  attackToken.status = AttackToken.Status.ready;
		  // 发送攻击请求
		  TangNet.TN.Send( new TGN.AttackRequest (push.skillId,
							  push.targetId, push.tokenCode ) );
		  // 进入指令暂存状态
		  InstructionCache.isInstructionCached = true;	      
		}
			  
	    }
	  else
	    {
	      // 删掉 BattleCache 里面的 attack token
	      BattleCache.RemoveAttackToken( push.actorId, push.tokenCode );
	    }
	}
      
    }

    private void HandleOtherHeros(TGN.ReadyAttackPush push)
    {
      AttackToken attackToken = new AttackToken( push.actorId, push.targetId,
						 push.tokenCode,
						 AttackToken.Status.ready,
						 push.skillId );
      BattleCache.PutAttackToken(attackToken);
      
    }


  }
}
