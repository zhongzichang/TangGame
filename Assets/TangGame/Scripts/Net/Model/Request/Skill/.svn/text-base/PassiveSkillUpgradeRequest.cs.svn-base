/// <summary>
/// xbhuang
/// 2013/12/5
/// </summary>
using System;
using UnityEngine;
using PureMVC.Patterns;
using TangNet;

namespace TangGame.Net
{
  public class PassiveSkillUpgradeRequest : Request
  {
    private int skillConfigId;
    /// <summary>
    /// 请求升级某一个技能
    /// </summary>
    /// <param name="skillIndex">Skill index.</param>
    public PassiveSkillUpgradeRequest(int skillConfigId)
    {
      this.skillConfigId = skillConfigId;
    }
    public NetData NetData
    {
      get
      {
        NetData data = new NetData(SkillProxy.S_UPLEVEL_PASSIVE_SKILL);
        data.PutInt(skillConfigId);
        return data;
      }
    }

  }
}

