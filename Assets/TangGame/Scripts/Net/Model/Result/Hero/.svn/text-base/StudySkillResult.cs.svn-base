/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/21
 * Time: 17:42
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of StudySkillResult.
/// </summary>
public class StudySkillResult : Response
{
    public const string NAME = "studySkill_RESULT";

    public short type;
    public int skillId;
    public short skillSort;
    public short skillFenlei;
    public short heroSkillUserBreath;
    public int heroCopper;
    public int heroBreath;
    public short heroSwordPoint;

    public StudySkillResult() : base(NAME)
    {
    }

    public static StudySkillResult Parse(MsgData data)
    {


        StudySkillResult result = new StudySkillResult();

        int index = 0;

        result.type = data.GetShort(0);
        if(data.Size > 1)
        {
            MsgData skillData = data.GetMsgData(1);
            result.skillId = skillData.GetInt(index++);
            result.skillSort = skillData.GetShort(index++);
            result.skillFenlei = skillData.GetShort(index++);
            result.heroSkillUserBreath = skillData.GetShort(index++);
            result.heroCopper = skillData.GetInt(index++);
            result.heroBreath = skillData.GetInt(index++);
            result.heroSwordPoint = skillData.GetShort(index++);
        }

        return result;

    }
}
}
