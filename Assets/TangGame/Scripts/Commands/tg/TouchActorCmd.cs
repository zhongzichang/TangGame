/**
 * 当点到场景中的角色
 * 
 * Date: ?
 * Author: hbx
 * 
 * Date: 2013/11/15
 * Edit: zzc
 * Desc: 目前没有办法对主角与角色的关系进行判断，只能根据角色的类型来进行处理
 */

using UnityEngine;
using System.Collections;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TGN = TangGame.Net;
using TGX = TangGame.Xml;
using TGV = TangGame.View;
using TS = TangScene;
using TangUtils;
using TangGame.Xml;

namespace TangGame
{
  public class TouchActorCmd : SimpleCommand
  {
    public static string NAME = "TG_TOUCH_ACTOR";

    public override void Execute (INotification notification)
    {
      long actorId = (long)notification.Body;
      TGN.HeroNew hero = ActorCache.GetLeadingHero();

      TS.ActorType actorType = ActorCache.GetActorTypeById( actorId );
      switch (actorType)
      {
        case TS.ActorType.npc:
          TouchNpc(actorId);
          break;
        case TS.ActorType.hero:
          TouchHero(actorId);
          break;
        case TS.ActorType.monster:
          TouchMonster(actorId);
          break;
        case TS.ActorType.pet:
          TouchPet(actorId);
          break;
      }
    }


    /// <summary>
    ///   当点击到 NPC
    /// </summary>
    private void TouchNpc(long actorId)
    {

      // 如果还没有被选中，则选中
      if( TS.TS.SelectedActorId != actorId )
        TS.TS.SwitchSelectedActor (actorId);

      TS.TS.ActorTrace (ActorCache.leadingActorId, actorId,
                        Config.defaultTraceDistance.x,
                        Config.defaultTraceDistance.y);
      

    }

    /// <summary>
    ///   当点击到 Hero
    /// </summary>
    private void TouchHero(long actorId)
    {
      
      // 如果还没有被选中，则选中
      if( TS.TS.SelectedActorId != actorId )
        TS.TS.SwitchSelectedActor (actorId);
      
      
    }

    /// <summary>
    ///   当点击到 Monster
    /// </summary>
    private void TouchMonster(long actorId)
    {

      // 如果还没有被选中，则选中
      if( TS.TS.SelectedActorId != actorId )
        TS.TS.SwitchSelectedActor (actorId);

      
      int skillId = SkillsCache.leadingActorDefaultSkillId;

      if( Config.skillTable.ContainsKey( skillId ) )
      {
        SkillData skill = Config.skillTable[ skillId ];
        float realRange = GridUtil.WIDTH * skill.Range;
        TS.TS.ActorTrace (ActorCache.leadingActorId, actorId, realRange, realRange+10F);
        
      }
      else
      {
        TS.TS.ActorTrace (ActorCache.leadingActorId, actorId,
                          Config.defaultTraceDistance.x,
                          Config.defaultTraceDistance.y);
        
      }
      
    }

    /// <summary>
    ///   当点击到 Pet
    /// </summary>
    private void TouchPet(long actorId)
    {
      
    }
  }
}