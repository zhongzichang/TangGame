/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/6
 * Time: 21:17
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UnityEngine;
using TangNet;
using System.Collections.Generic;

namespace TangGame.Net
{
/// <summary>
/// Description of Skill.
/// </summary>
  public class Skill
  {
    /** 技能ID */
    public int id;
//    /** 技能种类 */
//    public short sort;
//
//    /** 技能名称 */
//    public string name;
//    /** 技能等级 */
//    public short level;
//    /** 前提技能 */
//    public int premissSkillId;
//    /** 下一技能 */
//    public int nextSkillId;
//    /** 技能类型(0:被动 1:主动攻击 2:主动辅助) */
//    public short type;
//
    /** 技能冷却时间 */
    public long cdTime;
    /// <summary>
    /// 技能所在的技能栏位置索引
    /// </summary>
    public short skillBarIndex;
    
//    /** 技能消费 */
//    public short mp;
//    /** 技能消耗内息 */
//    public short breath;
//
//    /** 可设置最大内力 */
//    public short brMax;
//    /** 修改内息攻击加成消耗内息单位 */
//    public short brcost;
//    /** 修改内息攻击提升 */
//    public short powup;
//
//
//    /** 攻击类型(-1:自己 1:单体攻击 2:直线攻击 3:区域攻击) */
//    public short shape;
//    /** 攻击距离 */
    public short distance;
//    /** 攻击范围 */
//    public short areaWidth;
//    /** 攻击范围 */
//    public short areaHeight;
//
//    /** 附加攻击 */
//    public int hurtValue;
//    /** 攻击加成 */
//    public short attackAddition;
//    /** 技能效果 */
//    public int[][] buffArray;
//
//    /** 升级消耗内息点 */
//    public short upgradeBreath;
//    /** 升级消耗Copper */
//    public int upgradeCopper;
//    /** 升级消耗武学点 */
//    public short upgradeSkillPoint;
//    /** 流派限制 */
//    public short genreLimit;
//    /** 武器限制 */
//    public short weaponLimit;
//    /** Hero等级限制 */
//    public short heroLevelLimit;
//    /** 悟性限制 */
//    public short savvyLimit;
//    /** 学习限制(1:NPC处学习) */
//    public short studyLimit;
//    /** 武器类型 */
//    public short fenlei;
//    /** 技能描述 */
//    public string memo;
//    /** 特效 */
//    public string tiexiao;
//    /** 升级熟练度 */
    public int upExp;

    public static Dictionary<int,Skill> Parse (MsgData data)
    {
      Dictionary<int,Skill> skills = new Dictionary<int,Skill> ();
      MsgData skillData;
      Skill skill;
      for (int i = 0; i < data.Size; i++) {
        skill = new Skill ();
        int index = 0;
        skillData = data.GetMsgData (i);
        skill.id = skillData.GetInt (index++);
        skill.cdTime = skillData.GetLong (index++);
        skill.skillBarIndex = skillData.GetShort (index++);
        skill.distance = skillData.GetShort (index++);
        skills.Add (skill.id, skill);
      }
      return skills;
    }

  }
}
