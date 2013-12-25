/**
 * Show Battle Result Command
 *
 * Date: 2013/11/14
 * Author: zzc
 */

using System;
using System.Collections.Generic;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using UnityEngine;
using TGN = TangGame.Net;
using TS = TangScene;
using TGX = TangGame.Xml;
using TangEffect;
using zyhd.TEffect;

namespace TangGame
{
  public class ShowBattleResultCmd : SimpleCommand
  {
    public static string NAME = "TG_SHOW_BATTLE_RESULT";

    public override void Execute( INotification notification )
    {

      TGN.BattleResultPush push = notification.Body as TGN.BattleResultPush;
      if( push != null )
	{
	  List<TGN.BattleMsg> battleMsgList = push.battleMsgList;

	  List<long> stagnantActorIdList = new List<long>();

	  int hitEffectId = 0;
	  // attack token
	  AttackToken attackToken = BattleCache.GetAttackToken( push.sourceId, push.tokenCode);
	  if( attackToken != null && Config.skillTable.ContainsKey( attackToken.skillId ) )
	    {
	      TGX.SkillData skill = Config.skillTable[ attackToken.skillId ];
	      hitEffectId = Int32.Parse( skill.Hit_effect);
	    }

	  foreach (TGN.BattleMsg battleMsg in battleMsgList)
	    {

	      GameObject targetObj = TS.TS.GetActorGameObject( battleMsg.targetId );

	      // 如果目标对象不存在，则继续下一个
	      if(targetObj == null)
		continue;
				
	      // 判断被攻击者是否为自己，自己被打和别人被打冒字效果是不一样的
	      bool isLeadingActor = ( battleMsg.targetId == ActorCache.leadingActorId );
				
	      // 显示受到伤害冒值
	      this.ShowHurtNum( battleMsg, isLeadingActor, targetObj );
				
	      // 在此不更新自己的血条值，或者血量不大于0
	      if( !isLeadingActor || battleMsg.hp > 0 )
		this.ShowHitPointsBar( battleMsg, targetObj );

	      // 判断是否为暴击，如果暴击则震动镜头
	      if( push.sourceId == ActorCache.leadingActorId && battleMsg.isCrit )
		EffectManager.Instance.EnableCameraShake();

	      // 显示特效
	      if( hitEffectId != 0 )
		TE.Binding( battleMsg.targetId, hitEffectId, hitEffectId  );

	      // 接受伤害执行相关逻辑
	      switch ( (TangNet.ActorType) battleMsg.targetType )
		{
		case TangNet.ActorType.hero:
		  this.HeroBeingAttacked(battleMsg);
		  break;
		case TangNet.ActorType.monster:
		  this.MonsterBeingAttacked(battleMsg, push.sourceId, targetObj);
		  break;
		case TangNet.ActorType.npc:
		  break;
		case TangNet.ActorType.pet:
		  break;
		}
	    }// foreach

	  // 如果有被攻击僵直
	  // if(stagnantActorIdList.Count > 0){
	  //   long[] stagnantActorIds = stagnantActorIdList.ToArray();
	  //   TS.TS.Stagnant(stagnantActorIds,0.1f);
	  // }
	  


	}//if
    }

    /// <summary>
    /// 英雄被攻击到的伤害效果处理
    /// </summary>
    private void HeroBeingAttacked(TGN.BattleMsg battleMsg)
    {
      TGN.HeroNew heroActor = ActorCache.GetHeroById(battleMsg.targetId);
      if(heroActor == null)
	return;
      heroActor.hp = battleMsg.hp;
      heroActor.mp = battleMsg.mp;
      if(battleMsg.hp <= 0)
	{
	  heroActor.hp = 0;
	  //如果死亡者是自己则注销场景手势操作输入
	  if(heroActor.id == ActorCache.leadingActorId)
	    {
	      SendNotification(NtftNames.UN_REGISTER_GESTURE_INPUT);
	    }
	  TS.TS.ActorDie(heroActor.id);
	}
    }


    /// <summary>
    /// 怪物被攻击到的伤害效果处理
    /// </summary>
    private void MonsterBeingAttacked( TGN.BattleMsg battleMsg,long sourceId, GameObject targetObj )
    {
      TGN.Monster monsterActor = ActorCache.GetMonsterById(battleMsg.targetId);
      if( monsterActor == null )
	return;
      monsterActor.hp = battleMsg.hp;
      if(monsterActor.hp <= 0)
	{
	  monsterActor.hp = 0;
	  //击飞怪物并销毁
	  KnockIntoAirBehaviour knockIntoAir = targetObj.GetComponent<KnockIntoAirBehaviour>();
	  if(knockIntoAir == null)
	    {
	      knockIntoAir = targetObj.AddComponent<KnockIntoAirBehaviour>();
	    }
	  knockIntoAir.actorId = sourceId;
	  knockIntoAir.targetId = battleMsg.targetId;
	}
    }


    /// <summary>
    /// 显示血条值
    /// </summary>
    /// <param name="battleMsg"></param>
    private void ShowHitPointsBar( TGN.BattleMsg battleMsg, GameObject targetObj )
    {
      //如果血槽不存在创建一个血条TEffectDisappearAtAWhile
      if( !ActorCache.hitPointsDictionary.ContainsKey( battleMsg.targetId ) )
	{
	  TEffect tef = new TEffect( TEffectType.PlayerHpShow, new Vector3(0,110,0), targetObj );
	  ActorCache.hitPointsDictionary.Add( battleMsg.targetId, tef );
	}
      //更新血条值的信息
      TEffect nameLabel = null;
      TEffect hitPoints = null;
      if( ActorCache.hitPointsDictionary.ContainsKey( battleMsg.targetId) )
	hitPoints = ActorCache.hitPointsDictionary[ battleMsg.targetId ];
      if( ActorCache.nameLabelDictionary.ContainsKey( battleMsg.targetId) )
	nameLabel = ActorCache.nameLabelDictionary[ battleMsg.targetId ];

      if( nameLabel != null && hitPoints != null )
	{
	  if( battleMsg.hp <=0 )
	    {
	      ActorCache.nameLabelDictionary.Remove(battleMsg.targetId);
	      ActorCache.hitPointsDictionary.Remove(battleMsg.targetId);
	      hitPoints.Display();
	      nameLabel.Display();
	    }
	  else
	    {
	      hitPoints.SetNumber( (float)battleMsg.hp / (float) ActorCache.actors[battleMsg.targetId].hpMax );
	    }
	  
	}


    }


    /// <summary>
    /// 显示伤害冒值
    /// </summary>
    /// <param name="battleMsg"></param>
    private void ShowHurtNum( TGN.BattleMsg battleMsg, bool isLeadingActor, GameObject targetObj )
    {
      //伤害冒值挂点
      Vector3 effectsHangingPoints = targetObj.transform.localPosition + (Vector3.forward * 50);

      //如果是MISS
      if( battleMsg.hurt == 0 )
	{
	  new TEffect( TEffectType.Avoid, "avoid", effectsHangingPoints );
	}

      //如果攻击者是当前玩家角色
      else if( isLeadingActor )
	{
	  new TEffect( TEffectType.SelfHurt, battleMsg.hurt, effectsHangingPoints );
	}

      //如果是暴击
      else if( battleMsg.isCrit )
	{
	  new TEffect( TEffectType.DmgCrit, battleMsg.hurt, effectsHangingPoints );
	}

      //否则只是普通伤害
      else
	{
	  new TEffect( TEffectType.Dmg, battleMsg.hurt, effectsHangingPoints );
	}
    }



  }
}