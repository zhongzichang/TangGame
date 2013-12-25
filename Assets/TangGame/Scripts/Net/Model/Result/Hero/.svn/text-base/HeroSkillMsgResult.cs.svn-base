/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/21
 * Time: 15:13
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of HeroSkillMsg.
/// </summary>
public class HeroSkillMsgResult : Response
{

    public const string NAME = "heroSkillMsg_RESULT";

    public List<HeroSkill> heroSkills;

    public HeroSkillMsgResult() : base(NAME)
    {
    }

    public static HeroSkillMsgResult Parse(MsgData data)
    {

        HeroSkillMsgResult result = new HeroSkillMsgResult();


        List<HeroSkill> heroSkills = new List<HeroSkill>();
//        for(int i=0; i<data.Size; i++)
//        {
//
//            HeroSkill heroSkill = new HeroSkill();
//
//            MsgData skillData = data.GetMsgData(i);
//            int index = 0;
//            heroSkill.skill.id = skillData.GetInt(index++);
//            heroSkill.skill.sort = skillData.GetShort(index++);
//            heroSkill.skill.fenlei = skillData.GetShort(index++);
//            heroSkill.useBreath = skillData.GetShort(index++);
//
//            heroSkills.Add(heroSkill);
//
//        }

        result.heroSkills = heroSkills;

        return result;

    }
}
}
