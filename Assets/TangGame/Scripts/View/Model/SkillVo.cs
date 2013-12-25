using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TGN = TangGame.Net;

namespace TangGame.View
{

  public class SkillVo
  {
    ///内力伤害加成
    public int addBreath;

    /// 当前技能ID
    private int mSkillId;

    /// 默认技能ID
    public int defaultSkillId = 99999999;

    /// 技能类型
    public int skillType;

    /// 技能CD时间
    public long cdTime = 0;
	
    public int exp;
	
    /// 技能是否激活
    public bool IsActive()
    {
      return true;
    }

    public static SkillVo FormData(TGN.Skill[] skills)
    {
      
      return null;

    }
  }
}






