using System;
using TangNet;
using System.Collections.Generic;
using UnityEngine;
namespace TangGame.Net{
  [Response(NAME)]
  public class HeroUseSkillPush : Response{
    public const string NAME = "herouseskill_PUSH";

    public Dictionary<int,Skill> skills;
    public HeroUseSkillPush() : base(NAME)
    {
      skills = new Dictionary<int,Skill>();
    }

    public static HeroUseSkillPush Parse(MsgData data){
      HeroUseSkillPush push = new HeroUseSkillPush();
      push.skills = Skill.Parse(data.GetMsgData(0));
      return push;
    }
  }
}