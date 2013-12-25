/// <summary>
/// Level up skill request.
/// xbhuang
/// 2013/12/5
/// </summary>
using System;
using TangNet;
namespace TangGame.Net
{
	public class LevelUpSkillRequest : Request
	{
		private int skillIndex;
		/// <summary>
		/// 请求升级某一个技能
		/// </summary>
		/// <param name="skillIndex">Skill index.</param>
		public LevelUpSkillRequest(int skillIndex)
		{
			this.skillIndex = skillIndex;
		}
		public NetData NetData
		{
			get
			{
				NetData data = new NetData(SkillProxy.S_UPLEVEL_SKILL);
				data.PutInt(skillIndex);
				return data;
			}
		}
	}
}

