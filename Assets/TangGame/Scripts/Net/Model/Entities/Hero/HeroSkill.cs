/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/11
 * Time: 16:53
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TangGame.Net
{
/// <summary>
/// Description of HeroSkill.
/// </summary>
public class HeroSkill
{
    public int skillId;
    public long lastUseTime;
    /** 技能消耗内息值 */
    public short useBreath;
    public Skill skill = new Skill();
}
}
