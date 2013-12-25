/// <summary>
/// xbhuang
/// 2013/11/23
/// </summary>
using System;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TangGame.Net;
using System.Collections.Generic;
using UnityEngine;

namespace TangGame
{
  public class HeroUseSkillPushCmd : SimpleCommand
  {
    public static string NAME = TangGame.Net.HeroUseSkillPush.NAME;

    public override void Execute (INotification notification)
    {
      if (notification == null || notification.Body == null) {
        return;
      }
      TangGame.Net.HeroUseSkillPush push = notification.Body as TangGame.Net.HeroUseSkillPush;
      SkillsCache.heroUseSkills = push.skills;
      foreach (TangGame.Net.Skill skill in push.skills.Values) {
        if (skill.skillBarIndex == -1) {
          SkillsCache.leadingActorDefaultSkillId = skill.id;
        } else {
          SendNotification (NtftNames.TG_UPDATE_SKILL_BAR, new SkillBarBean (skill.skillBarIndex, skill.id));
        }
      }
    }
  }
}