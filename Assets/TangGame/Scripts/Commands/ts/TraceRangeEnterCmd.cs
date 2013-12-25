/**
 * On trace range enter command
 * 进入跟踪范围
 * Date: 2013/11/14
 * Author: zzc
 */

using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using TN = TangNet;
using TS = TangScene;
using TGN = TangGame.Net;
using TGX = TangGame.Xml;

namespace TangGame
{
  public class TraceRangeEnterCmd : SimpleCommand
  {
    public const string NAME = TS.NtftNames.TRACE_RANGE_ENTER;

    public override void Execute( INotification notification )
    {
      
      // 中止寻路
      if( AutoNavCache.isActive )
        AutoNavHelper.Terminate();
      
      
      TS.TraceBean bean = notification.Body as TS.TraceBean;
      
      if (bean != null)
      {

        GameObject actorGobj = TS.TS.GetActorGameObject( bean.tracerId );

        if( actorGobj != null )
        {
          
          // 发送当前位置给服务器
          Vector3 pos = actorGobj.transform.localPosition;
          TangUtils.Point point = TangUtils.GridUtil.Vector3ToPoint (pos);
          TangNet.TN.Send (new TGN.HeroMoveRequest (point));


          switch (ActorCache.GetActorTypeById (bean.targetId))
          {
            case TS.ActorType.hero:
              break;
            case TS.ActorType.monster:
              TGX.SkillData skill = SkillsCache.GetLeadingActorCurrentSkill();
              if( skill != null )
                MonsterInteract( bean, skill.Skill_id );
              break;
            case TS.ActorType.npc:
              TN.TN.Send( new TGN.GetNpcInfoRequest( bean.targetId ) );
              break;
          }
          
          // 设置目标角色为选中
          if( TS.TS.SelectedActorId != bean.targetId )
            TS.TS.SwitchSelectedActor(bean.targetId);
          
        }
      }
    }

    private void MonsterInteract( TS.TraceBean bean, int skillId )
    {
      AttackToken token = BattleCache.NewLeadingAttackToken( skillId, bean.targetId);
      BattleCache.PutAttackToken(token);
      TN.TN.Send ( new TGN.ReadyAttackRequest ( skillId, bean.targetId, token.code ) );
      
    }

  }
}