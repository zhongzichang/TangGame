using UnityEngine;
using System.Collections.Generic;
using TGV = TangGame.View;
using TangGame.Net;
using TangGame.Xml;

namespace TangGame
{
  public class SkillsCache
  {
    public class SkillCache
    {
      public bool isCd;
    }
    public static Dictionary<int,SkillCache> leadingActorSkills = new Dictionary<int, SkillCache> ();
    //    public static TGV.SkillBaseVoNew leadingActorDefaultSkill;
    /// <summary>
    /// 默认技能ID
    /// </summary>
    public static int leadingActorDefaultSkillId;

    /// <summary>
    /// 当前技能ID
    /// </summary>
    public static int currentActorSkillId = 0;
    public static Dictionary<int, SkillInfo> skillDic = new Dictionary<int, SkillInfo> ();


    /// <summary>
    /// 战斗和主界面技能框使用的数据
    /// </summary>
    public static Dictionary<int,Skill> heroUseSkills = new Dictionary<int,Skill>();

    /// <summary>
    /// 添加一个技能到本地缓存中，缓存里是按照sort来存的，也就是说是根据技能等级分类来做的，因为技能的每个等级都是不同的配置ID
    /// </summary>
    /// <returns><c>true</c>, if skill was added, <c>false</c> otherwise.</returns>
    /// <param name="info">Info.</param>
    public static bool AddSkill (SkillInfo info)
    {
      bool isAdd = true;
      if (Config.skillTable.ContainsKey (info.skillIndex)) {
        SkillData skillData = Config.skillTable [info.skillIndex];
        if (skillData != null) {
          int sort = skillData.Sort;

          if (skillDic.ContainsKey (sort)) {//说明之前有这个技能了
            isAdd = false;
          }
          skillDic [sort] = info;
        }
      } else
        Debug.LogError ("客户端技能配置表没有" + info.skillIndex + "技能");
      return isAdd;
    }

    public static SkillData GetLeadingActorCurrentSkill ()
    {

      if( currentActorSkillId == 0)
      {
        currentActorSkillId = leadingActorDefaultSkillId;
      }
      
      if (Config.skillTable.ContainsKey (currentActorSkillId)) {
        return Config.skillTable [currentActorSkillId];
      } else
        return null;
    }
  }
}