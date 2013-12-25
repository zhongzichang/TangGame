using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using TGN = TangGame.Net;
using TS = TangScene;

namespace TangGame
{
  public class HeroReliveCmd : SimpleCommand
  {
    public static string NAME = TGN.HeroRelivePush.NAME;
    public override void Execute (INotification notification)
    {
      TGN.HeroRelivePush push = notification.Body as TGN.HeroRelivePush;

      if(ActorCache.leadingActorId == push.heroId)
	return;

      TGN.HeroNew hero = ActorCache.GetHeroById(push.heroId);
      hero.hp = push.hp;
      hero.x = push.x;
      hero.y = push.y;
      //TODO i will write something !

    }

  }
}