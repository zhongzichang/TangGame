using System;
using UnityEngine;
using PureMVC.Patterns;
using TangNet;
namespace TangGame.Net
{
  public class SkillUpgradeRequest : Request
  {
    private int skillSort;
    
    [System.Obsolete("use LevelUpSkillRequest or StudySkillRequest!")]
    public SkillUpgradeRequest(int skillSort)
    {
      this.skillSort=skillSort;
    }
    public NetData NetData
    {
      get
      {
        NetData data = new NetData(HeroProxy.HERO_SKILL_UPGRADE);

        Debug.Log("SkillUpgrade skillSort = " + skillSort);
        data.PutShort(skillSort);
        return data;
      }
    }
  }
}
