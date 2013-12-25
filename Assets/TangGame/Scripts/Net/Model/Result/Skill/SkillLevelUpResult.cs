/*
 * Created by SharpDevelop.
 * User: huxiaobo
 * Date: 2013/12.6
 * Time: 17:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;
using UnityEngine;

namespace TangGame.Net
{
	/// <summary>
	/// 技能升级回复
	/// </summary>
	[Response(NAME)]
	public class SkillLevelUpResult : Response
	{
		public const string NAME = "skillUpgrade_RESULT";
		public short statusCode;
		public SkillLevelUpResult() : base(NAME)
		{
		}
		public static SkillLevelUpResult Parse(short statusCode, MsgData data)
		{
			SkillLevelUpResult result = new SkillLevelUpResult();
			result.statusCode = statusCode;
			return result;
		}
	}
}
