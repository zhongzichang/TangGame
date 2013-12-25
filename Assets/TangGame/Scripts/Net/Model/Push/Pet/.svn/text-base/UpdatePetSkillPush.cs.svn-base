/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 11:59
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of UpdatePetSkillPush.
/// </summary>
public class UpdatePetSkillPush : Response
{
    public const string NAME = "updatePetSkill_PUSH";

    public long petId;
    public int skillId; // pet skill
    public short skillSort;
    public short fenlei;
    public int exp;

    public UpdatePetSkillPush() : base(NAME)
    {
    }
    public static UpdatePetSkillPush Parse(MsgData data)
    {
        UpdatePetSkillPush push = new UpdatePetSkillPush();

        int index = 0;
        push.petId = (long)data.GetDouble(index++);
        push.skillId = data.GetInt(index++);
        push.skillSort = data.GetShort(index++);
        push.fenlei  = data.GetShort(index++);
        push.exp = data.GetInt(index++);

        return push;

    }
}
}
