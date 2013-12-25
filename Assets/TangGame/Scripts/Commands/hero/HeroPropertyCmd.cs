using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using TGN = TangGame.Net;
using TE = TangEffect;

namespace TangGame
{
  /// <summary>
  /// 更新主角英雄的数据
  /// </summary>
  public class HeroPropertyCmd : SimpleCommand
  {

    public static string NAME = TGN.HeroPropertyPush.NAME;

    public override void Execute (INotification notification)
    {

      TGN.HeroPropertyPush push = notification.Body as TGN.HeroPropertyPush;

			
      if (push != null) {
	nh.ui.cache.UIActorCache.ChangeHeroData (notification.Body as TGN.HeroPropertyPush);
	foreach (KeyValuePair<short,object> item in push.heroPropertyList) {

	  TGN.HeroNew hero = ActorCache.GetLeadingHero ();
	  hero.UpdateHeroData (item);
	      

	  // 升级
	  if (item.Key == (short)HeroPropertyEnum.LV) 
	    {
	      // 播放升级特效
	      TE.TE.ActorUpgrade (ActorCache.leadingActorId);
	    }

	  else if( item.Key == (short)HeroPropertyEnum.HP )
	    {
	      if( (int)item.Value <= 0 )
		{
		  // 主角死亡
		  SendNotification(NtftNames.TG_LEADING_ACTOR_DIE);
		}
	    }
	}
      }

    }
  }
}