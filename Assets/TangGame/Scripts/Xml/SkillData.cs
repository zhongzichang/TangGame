using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using TangUtils;
using TGV = TangGame.View;

namespace TangGame.Xml
{
  public class SkillData
  {
    public string Name;
    public int Skill_id;
    public string Skill_icon;
    public int Level;
    public int Sort;
    public int Hero_Level;
    public int Skill_Group;
    public int Skill_type;
    public int Scope_type;
    public int Range;
    public int Length;
    public int Width;
    public int Bounce;
    public int Target;
    public int Dmg_type;
    public float Dmg_p;
    public int Dmg_c;
    public int Dmg_time;
    public int Dmg_interval;
    public int Release;
    public int Release_need;
    public float Cd_time;
    public int Buff_trigger;
    public int Monster_create;
    public int Amount;
    public int neili;
    public int Upgrade_item;
    public int Item_need;
    public int Gem_control;
    public int Gem_level;
    public int Next_skill;
    public int Effect_shot;
    public int Shotplay_type;
    public int Fly_speed;
    public string Hit_effect;
    public int Shock_mirror;
    public string Shot_bmg;
    public string Hit_bmg;
    public string Info;
    public int Hero_type;
		public int Really;

    /// <summary>
    /// Ises the max level.
    /// </summary>
    /// <returns><c>true</c>, if max level was ised, <c>false</c> otherwise.</returns>
    /// <param name="skillXml">Skill xml.</param>
    public bool isMaxLevel(){
      if(this.Next_skill <= 0 ){
        return true;
      }  
      return false;
    }
  }

  [XmlRoot("root")]
  [XmlLate("skill")]
  public class SkillRootNew
  {
    [XmlElement("T")]
    public List<SkillData> items = new List<SkillData>();

    public static void LateProcess(object obj)
    {

      SkillRootNew root = obj as SkillRootNew;
      
      foreach (SkillData item in root.items)
      {
        Config.skillTable[item.Skill_id] = item;
      }
    }
  }
}