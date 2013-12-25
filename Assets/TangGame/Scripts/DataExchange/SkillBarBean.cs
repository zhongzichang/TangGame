/// <summary>
/// xbhuang
/// 2013/11/23
/// </summary>
using UnityEngine;
using System.Collections;

namespace TangGame
{
  public class SkillBarBean
  {
    /// <summary>
    /// 技能栏位置索引
    /// </summary>
    public int index;
    /// <summary>
    /// 技能ID
    /// </summary>
    public int skillId;

    public SkillBarBean (int index, int skillId)
    {
      this.index = index;
      this.skillId = skillId;
    }

  }
}